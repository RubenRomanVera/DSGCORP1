using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("api/Producto/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Producto.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Producto/GetById")]
        public IHttpActionResult GetById(int IdProducto)
        {
            var result = BL.Producto.GetById(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Producto/Add")]
        public IHttpActionResult Add(ML.Producto producto)
        {
            var result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Producto/Update")]
        public IHttpActionResult Update(ML.Producto producto)
        {
            var result = BL.Producto.Update(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Producto/Delete")]
        public IHttpActionResult Delete(int IdProducto)
        {
            var result = BL.Producto.Delete(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
