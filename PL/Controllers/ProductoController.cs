using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            //ML.Result result = BL.Producto.GetAll();
            ML.Result resultApi = new ML.Result();
            string Uri = ConfigurationManager.AppSettings["WebApi"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);

                var responseTask = client.GetAsync("producto/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    resultApi.Objects = new List<object>();
                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultMateria = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        resultApi.Objects.Add(resultMateria);
                    }
                }
            }
            producto.Productos = resultApi.Objects;
            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            if (IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                //ML.Result result = BL.Producto.GetById(IdProducto.Value);

                //if (result.Correct)
                //{
                //    producto = (ML.Producto)result.Object;
                //    return View(producto);
                //}
                //else
                //{
                //    return View("Modal");
                //}
                ML.Result resultApi = new ML.Result();
                string Uri = ConfigurationManager.AppSettings["WebApi"].ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Uri);

                    var responseTask = client.GetAsync("api/GetById/?IdProducto=" + IdProducto);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        resultApi.Object = new ML.Result();
                        var resultItem = readTask.Result.Object;

                        ML.Producto resultProducto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        resultApi.Object = resultProducto;
                    }
                }
                return View(producto);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            if (producto.IdProducto == 0)
            {
                string Uri = ConfigurationManager.AppSettings["WebApi"].ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Uri);
                    var postTask = client.PostAsJsonAsync<ML.Producto>("producto/Add", producto);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Registro exitoso.";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "No se pudo registrar la materia.";
                        return PartialView("Modal");
                    }
                }
            }
            else
            {
                //ML.Result result = BL.Producto.Update(producto);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "Registro exitoso.";
                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un problema.";
                //}
                string Uri = ConfigurationManager.AppSettings["WebApi"].ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Uri);
                    var postTask = client.PostAsJsonAsync<ML.Producto>("producto/Update", producto);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Exito en la actualización.";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un problema.";
                        return PartialView("Modal");
                    }
                }
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;
            if (producto.IdProducto>0)
            {
                //ML.Result result = BL.Producto.Delete(IdProducto);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "El registro fue eliminado.";
                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un error.";
                //}
                string Uri = ConfigurationManager.AppSettings["WebApi"].ToString();
                using (var client=new HttpClient())
                {
                    client.BaseAddress = new Uri(Uri);
                    var responseTask = client.GetAsync("producto/Delete/?IdProducto="+IdProducto);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se elimino el registro exitosamente.";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error.";
                    }
                }
            }
            return View("Modal");
        }
    }
}