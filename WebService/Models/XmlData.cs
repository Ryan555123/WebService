using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebService.Models
{
    public class XmlData
    {
        [AllowHtml]
        public string XmlIP { get; set; }

        [AllowHtml]
        public string XmlStr { get; set; }
    }
}