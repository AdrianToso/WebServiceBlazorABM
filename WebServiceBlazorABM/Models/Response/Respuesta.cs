using System.Collections.Generic;

namespace WebServiceBlazorABM.Models.Response
{
    public class Respuesta<T>
    {
        public int Success { get; set; }
        public string ErrCode { get; set; }

        public T Data { get; set; }
        public Respuesta()
        {
            this.Success = 0;  
        }
    }
}
