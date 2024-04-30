using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ResponseInfo
    {
        public string ResponseMsg { get; set; }
        public DataSet ResponseData { get; set; }
    }
}