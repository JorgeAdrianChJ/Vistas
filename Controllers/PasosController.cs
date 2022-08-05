using Microsoft.AspNetCore.Mvc;
using Registro_Efectos_Adversos.Models;

namespace Vistas.Controllers
{
    public class PasosController : Controller
    {
        public static Solicitud? GlobalSolicitud;
        //Scaffold-DbContext "Server=.;Database=registro_efectos_adversos;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
        public IActionResult Paso1()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Paso1([Bind("Identificacion,CodigoProfesional,NombreCompleto,Correo,Pais,Estado,Id")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var postTask = client.PostAsJsonAsync<Medico>("Medicos", medico);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Medico>();
                            readTask.Wait();

                            medico = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    var solicitud = new Solicitud();
                    solicitud.IdMedico = medico.Id;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var postTask = client.PostAsJsonAsync<Solicitud>("Solicituds", solicitud);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Solicitud>();
                            readTask.Wait();

                            GlobalSolicitud = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    return RedirectToAction(nameof(Paso2));
                }
                catch
                {
                    return BadRequest();
                }
            }
            return View(medico);
        }
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> AutoCompletadoMedico(string Identificacion, string CodigoProfesional)
        {
            Medico medico = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7123/api/");
                    var url = String.Format("Medicos/GetMedicoByIdAndCod/{0}/{1}", Identificacion, CodigoProfesional);
                    //HTTP GET
                    var responseTask = client.GetAsync(url);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<Medico>();
                        readTask.Wait();

                        medico = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return Ok(medico);
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult Paso2()
        {
            ViewBag.Solicitud = GlobalSolicitud.Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Paso2([Bind("Nombre,CedulaJurica,Pais,Provincia,Distrito,Telefono,Correo,Web")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var postTask = client.PostAsJsonAsync<Clinica>("Clinicas", clinica);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Clinica>();
                            readTask.Wait();

                            clinica = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    GlobalSolicitud.IdClinica = clinica.Id;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var url = String.Format("Solicituds/{0}", GlobalSolicitud.Id);
                        var postTask = client.PutAsJsonAsync<Solicitud>(url, GlobalSolicitud);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Solicitud>();
                            readTask.Wait();

                            GlobalSolicitud = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    return RedirectToAction(nameof(Paso3));
                }
                catch
                {
                    return BadRequest();
                }
            }
            return View(clinica);
        }
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> AutoCompletadoClinica(string Nombre, string CedulaJurica)
        {
            Clinica clinica = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7123/api/");
                    var url = String.Format("Clinicas/GetClinicaByNameAndCed/{0}/{1}", Nombre, CedulaJurica);
                    //HTTP GET
                    var responseTask = client.GetAsync(url);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<Clinica>();
                        readTask.Wait();

                        clinica = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return Ok(clinica);
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult Paso3()
        {
            ViewBag.Solicitud = GlobalSolicitud.Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Paso3([Bind("Identificacion,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Sexo,NumeroContacto,Pais,Provincia,Distrito,EstadoCivil,Telefono,Correo,FechaRegistro,Ocupacion")] Paciente paciente)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var postTask = client.PostAsJsonAsync<Paciente>("Pacientes", paciente);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Paciente>();
                            readTask.Wait();

                            paciente = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    GlobalSolicitud.IdPaciente = paciente.Id;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var url = String.Format("Solicituds/{0}", GlobalSolicitud.Id);
                        var postTask = client.PutAsJsonAsync<Solicitud>(url, GlobalSolicitud);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Solicitud>();
                            readTask.Wait();

                            GlobalSolicitud = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    return RedirectToAction(nameof(Paso4));
                }
                catch
                {
                    return BadRequest();
                }
            }
            return View(paciente);

        }
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> AutoCompletadoPaciente(string Identificacion)
        {
            Paciente paciente = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7123/api/");
                    var url = String.Format("Pacientes/{0}", Identificacion);
                    //HTTP GET
                    var responseTask = client.GetAsync(url);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<Paciente>();
                        readTask.Wait();

                        paciente = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return Ok(paciente);
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult Paso4()
        {
            ViewBag.Solicitud = GlobalSolicitud.Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Paso4([Bind("Nombre,Marca,FechaAplicacion,Lote,FechaVencimiento,LugarAplicacion,Observaciones,Respuesta1,Respuesta2,Respuesta3,Respuesta4,Respuesta5,Respuesta6,Respuesta7,Respuesta8,Respuesta9")] Vacuna vacuna)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var postTask = client.PostAsJsonAsync<Vacuna>("Vacunas", vacuna);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Vacuna>();
                            readTask.Wait();

                            vacuna = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            return View(vacuna);
                        }
                    }
                    GlobalSolicitud.IdVacuna = vacuna.Id;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var url = String.Format("Solicituds/{0}", GlobalSolicitud.Id);
                        var postTask = client.PutAsJsonAsync<Solicitud>(url, GlobalSolicitud);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Solicitud>();
                            readTask.Wait();

                            GlobalSolicitud = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    return RedirectToAction(nameof(Paso5));
                }
                catch
                {
                    return BadRequest();
                }
            }
            return View(vacuna);

        }
        public IActionResult Paso5()
        {
            ViewBag.Solicitud = GlobalSolicitud.Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Paso5([Bind("Id,IdMedico,IdClinica,IdPaciente,IdVacuna,Respuesta1,Respuesta2,Respuesta3,Respuesta4,Respuesta5,Respuesta6,Respuesta7,Respuesta8,Respuesta9,Respuesta10,Respuesta11,Respuesta12,Respuesta13,Respuesta14,Respuesta15,Respuesta16,Respuesta17,Respuesta18,Respuesta19,Respuesta21,Respuesta22,Respuesta23,Respuesta24,Respuesta25,Respuesta26,Respuesta27,Respuesta28,Respuesta29,Respuesta30,Respuesta31,Respuesta32,Respuesta33,Respuesta34,Respuesta35,Respuesta36,Respuesta37,Respuesta38,Respuesta39,Respuesta40,Respuesta41,Respuesta42,Respuesta43,Respuesta44,Respuesta45,Respuesta46,Respuesta47,Respuesta48,Respuesta49,Respuesta50,Respuesta51,Respuesta52,Respuesta53,Respuesta54,Respuesta55,Respuesta56,Respuesta57,Respuesta58,Respuesta59,Respuesta60,Respuesta61,Respuesta62,Respuesta63,Respuesta64,Respuesta65,Respuesta66,Respuesta67,Respuesta68,Respuesta69,Respuesta70,Respuesta71,Respuesta72,Respuesta73,Respuesta74,Respuesta75,Respuesta76,Respuesta77,Respuesta78,Respuesta79,Respuesta80,Respuesta81,Respuesta82,Respuesta83,Respuesta84,Respuesta85,Respuesta86,Respuesta87,Respuesta88,Respuesta89")] Solicitud solicitud)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    solicitud.Id = GlobalSolicitud.Id;
                    solicitud.IdMedico = GlobalSolicitud.IdMedico;
                    solicitud.IdClinica = GlobalSolicitud.IdClinica;
                    solicitud.IdPaciente = GlobalSolicitud.IdPaciente;
                    solicitud.IdVacuna = GlobalSolicitud.IdVacuna;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:7123/api/");
                        //HTTP GET
                        var url = String.Format("Solicituds/{0}", solicitud.Id);
                        var postTask = client.PutAsJsonAsync<Solicitud>(url, solicitud);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<Solicitud>();
                            readTask.Wait();

                            solicitud = readTask.Result;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                    return RedirectToAction(nameof(Paso6));
                }
                catch
                {
                    return BadRequest();
                }
            }
            return View(solicitud);
        }
        public IActionResult Paso6()
        {
            return View();
        }
    }
}
