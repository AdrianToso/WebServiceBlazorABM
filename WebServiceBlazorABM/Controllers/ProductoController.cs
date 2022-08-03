using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServiceBlazorABM.Models;
using WebServiceBlazorABM.Models.Request;
using WebServiceBlazorABM.Models.Response;

namespace WebServiceBlazorABM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController :ControllerBase
    {
        [HttpGet]
       public IActionResult Get()
        {
            Respuesta<List<Producto>> _respuesta = new Respuesta<List<Producto>>();
            try
            {
                using (BlazorABMContext db = new BlazorABMContext())
                {
                    var lst = db.Productos.ToList();
                    _respuesta.Success = 1;
                    _respuesta.Data = lst;

                }
            }
            catch(Exception ex )
            {
                _respuesta.ErrCode= ex.Message; 
            }
            return Ok(_respuesta);
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Producto> _respuesta = new Respuesta<Producto>();
            try
            {
                using (BlazorABMContext db = new BlazorABMContext())
                {
                    var lst = db.Productos.Find(Id);
                    _respuesta.Success = 1;
                    _respuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                _respuesta.ErrCode = ex.Message;
            }
            return Ok(_respuesta);
        }
        [HttpPost]
        public IActionResult Add(ProductoRequest model)
        {
            Respuesta<object> _respuesta = new Respuesta<object>();
            try
            {
                using (BlazorABMContext db = new BlazorABMContext())
                {
                   Producto prod= new Producto();
                    prod.Nombre=model.Nombre;
                    prod.Marca=model.Marca;
                    db.Productos.Add(prod);
                    db.SaveChanges();
                    _respuesta.Success=1;  

                }
            }
            catch (Exception ex)
            {
                _respuesta.ErrCode = ex.Message;
            }
            return Ok(_respuesta);
        }
        [HttpPut]
        public IActionResult Edit(ProductoRequest model)
        {
            Respuesta<object> _respuesta = new Respuesta<object>();
            try
            {
                using (BlazorABMContext db = new BlazorABMContext())
                {
                    Producto prod = db.Productos.Find(model.Id);
                    prod.Nombre = model.Nombre;
                    prod.Marca = model.Marca;
                    db.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    _respuesta.Success = 1;

                }
            }
            catch (Exception ex)
            {
                _respuesta.ErrCode = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Respuesta<object> _respuesta = new Respuesta<object>();
            try
            {
                using (BlazorABMContext db = new BlazorABMContext())
                {
                    Producto prod = db.Productos.Find(id);
                    db.Remove(prod);
                    db.SaveChanges();
                    _respuesta.Success = 1;

                }
            }
            catch (Exception ex)
            {
                _respuesta.ErrCode = ex.Message;
            }
            return Ok(_respuesta);
        }
    }
}
