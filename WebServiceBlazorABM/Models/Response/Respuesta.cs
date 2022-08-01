using System.Collections.Generic;

namespace WebServiceBlazorABM.Models.Response
{
    public class Respuesta
    {
        public int Success { get; set; }
        public string ErrCode { get; set; }

        public List<Producto> Data { get; set; }
        public Respuesta()
        {
            this.Success = 0;  
        }
    }
}
