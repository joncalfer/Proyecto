using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Response<T>
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        
    }
}
