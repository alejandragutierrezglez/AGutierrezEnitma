using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCatalogoProducto" en el código y en el archivo de configuración a la vez.
    public class ServiceCatalogoProducto : IServiceCatalogoProducto
    {
        public Proyecto_ENT.Result RecuperarCatalogo()
        {
            Proyecto_ENT.Result result = Proyecto_BLL.CatalogoProducto.RecuperarCatalogo();
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }            
        }

        public Proyecto_ENT.Result AgregarProducto(Proyecto_ENT.CatalogoProducto catalogoProducto)
        {
            Proyecto_ENT.Result result = Proyecto_BLL.CatalogoProducto.AgregarProducto(catalogoProducto);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public Proyecto_ENT.Result ActualizarProducto(Proyecto_ENT.CatalogoProducto catalogoProducto)
        {
            Proyecto_ENT.Result result = Proyecto_BLL.CatalogoProducto.ActualizarProducto(catalogoProducto);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public Proyecto_ENT.Result RecuperarCatalogoGetById(int IdProducto)
        {
            Proyecto_ENT.Result result = Proyecto_BLL.CatalogoProducto.RecuperarCatalogoGetById(IdProducto);
            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
