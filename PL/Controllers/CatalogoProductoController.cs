using Proyecto_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CatalogoProductoController : Controller
    {
        // GET: CatalogoProducto
        public ActionResult GetAll()
        {
            Proyecto_ENT.Result result = new Proyecto_ENT.Result();
            Proyecto_ENT.CatalogoProducto catalogoProducto = new Proyecto_ENT.CatalogoProducto();

            ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient serviceCatProd = new ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient();
            result = serviceCatProd.RecuperarCatalogo();

            if (result.Correct)
            {
                catalogoProducto.CatalogosProductos = result.Objects;
            }
            else
            {
                result.Correct = false;
            }

            return View(catalogoProducto);
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            Proyecto_ENT.Result resultCatProd = Proyecto_BLL.CatalogoProducto.RecuperarCatalogo();

            Proyecto_ENT.CatalogoProducto catalogoProducto = new Proyecto_ENT.CatalogoProducto();

            if (resultCatProd.Correct)
            {

                catalogoProducto.CatalogosProductos = resultCatProd.Objects;
            }
            if (IdProducto == null)
            {
                //add //formulario vacio
                return View(catalogoProducto);
            }
            else
            {
                //Proyecto_ENT.Result result = Proyecto_BLL.CatalogoProducto.RecuperarCatalogoGetById(IdProducto.Value); //2
                Proyecto_ENT.Result result = new Proyecto_ENT.Result();
                ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient serviceCatProd = new ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient();
                result = serviceCatProd.RecuperarCatalogoGetById(IdProducto.Value); 
                
                if (result.Correct)
                {

                    catalogoProducto = (Proyecto_ENT.CatalogoProducto)result.Object;//unboxing
                    catalogoProducto.CatalogosProductos = resultCatProd.Objects;
                    //update
                    return View(catalogoProducto);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información de la aseguradora";
                    return View("Modal");
                }
            }
        }


        [HttpPost] //Hacer el registro
        public ActionResult Form(Proyecto_ENT.CatalogoProducto catalogoProducto)
        {
            Proyecto_ENT.Result result = new Proyecto_ENT.Result();


            if (catalogoProducto.IdProducto != null)
            {

                //UPDATE
                //result = Proyecto_BLL.CatalogoProducto.ActualizarProducto(catalogoProducto);
               
                ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient serviceCatProd = new ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient();
                result = serviceCatProd.ActualizarProducto(catalogoProducto);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                //Add
                //result = Proyecto_BLL.CatalogoProducto.AgregarProducto(catalogoProducto);
                ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient serviceCatProd = new ServiceReferenceCatalogoProducto.ServiceCatalogoProductoClient();
                result = serviceCatProd.AgregarProducto(catalogoProducto);
                ViewBag.Message = "Se ha agregado el registro";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }
    }


}