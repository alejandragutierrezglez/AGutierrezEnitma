using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_BLL
{
    public class CatalogoProducto
    {
        public static Proyecto_ENT.Result RecuperarCatalogo()

        {
            Proyecto_ENT.Result result = new Proyecto_ENT.Result();
            try
            {
                using (Proyecto_DAL.AGutierrezEnitmaEntities context = new Proyecto_DAL.AGutierrezEnitmaEntities())

                {
                    var query = context.sp_GetAllCatalogoProd().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var resultCatProd in query)
                        {
                            Proyecto_ENT.CatalogoProducto catalogoProducto = new Proyecto_ENT.CatalogoProducto();
                            catalogoProducto.IdProducto = resultCatProd.IdProducto;
                            catalogoProducto.Descripcion = resultCatProd.Descripcion;
                            catalogoProducto.IdUsuario = resultCatProd.IdUsuario.Value;
                            catalogoProducto.FechaCreacion = resultCatProd.FechaCreacion.Value;

                            result.Objects.Add(catalogoProducto);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;

            }
            return result;
        }
        public static Proyecto_ENT.Result RecuperarCatalogoGetById(int IdProducto)

        {
            Proyecto_ENT.Result result = new Proyecto_ENT.Result();
            try
            {
                using (Proyecto_DAL.AGutierrezEnitmaEntities context = new Proyecto_DAL.AGutierrezEnitmaEntities())

                {
                    var query = context.sp_GetByIdCatalogoProducto(IdProducto).FirstOrDefault();
                    if (query != null)
                    {
                        Proyecto_ENT.CatalogoProducto catalogoProducto = new Proyecto_ENT.CatalogoProducto();
                        catalogoProducto.IdProducto = query.IdProducto;
                        catalogoProducto.Descripcion = query.Descripcion;
                        catalogoProducto.IdUsuario = query.IdUsuario.Value;
                        catalogoProducto.FechaCreacion = query.FechaCreacion.Value;

                        result.Object = catalogoProducto;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;

            }
            return result;
        }

        public static Proyecto_ENT.Result AgregarProducto(Proyecto_ENT.CatalogoProducto catalogoProducto)
        {
            Proyecto_ENT.Result result = new Proyecto_ENT.Result();
            try
            {
                using (Proyecto_DAL.AGutierrezEnitmaEntities context = new Proyecto_DAL.AGutierrezEnitmaEntities())
                {
                    int query = context.sp_InsCatalogoProd(catalogoProducto.Descripcion);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static Proyecto_ENT.Result ActualizarProducto(Proyecto_ENT.CatalogoProducto catalogoProducto)
        {
            Proyecto_ENT.Result result = new Proyecto_ENT.Result();
            try
            {
                using (Proyecto_DAL.AGutierrezEnitmaEntities context = new Proyecto_DAL.AGutierrezEnitmaEntities())
                {
                    int query = context.sp_ActCatalogoProd(catalogoProducto.IdProducto, catalogoProducto.Descripcion);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
