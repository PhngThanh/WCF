using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Response
{
    public class StoreResponse<T>
    {
       
            //[DataMember(Name = "success")]
            //public bool Success { get; set; }
            //[DataMember(Name = "status")]
            //public int Status { get; set; }
            //[DataMember(Name = "message")]
            //public string Message { get; set; }
            //[DataMember(Name = "data")]
            public T Data { get; set; }
       
    }
}
