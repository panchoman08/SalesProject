using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Transversal.Common
{
    public class ResponseError
    {
        public ResponseError(string message) 
        {
            Message = new string[] {message};
        }
        public string[] Message { get; set; }
    }
}
