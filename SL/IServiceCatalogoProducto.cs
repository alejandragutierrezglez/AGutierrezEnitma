using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace SL
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCatalogoProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCatalogoProducto
    {
        [OperationContract]
        [ServiceKnownType(typeof(Proyecto_ENT.CatalogoProducto))]
        Proyecto_ENT.Result RecuperarCatalogo();


        [OperationContract]
        [ServiceKnownType(typeof(Proyecto_ENT.CatalogoProducto))]
        Proyecto_ENT.Result RecuperarCatalogoGetById(int IdProducto);

        [OperationContract]
        Proyecto_ENT.Result AgregarProducto(Proyecto_ENT.CatalogoProducto catalogoProducto);

        [OperationContract]
        Proyecto_ENT.Result ActualizarProducto(Proyecto_ENT.CatalogoProducto catalogoProducto);
    }
}
