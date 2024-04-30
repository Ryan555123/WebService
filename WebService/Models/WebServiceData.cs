namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("WebServiceData")]
    public partial class WebServiceData
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Type { get; set; }


        [Required]
        [StringLength(255)]
        [AllowHtml]
        public string IP { get; set; }


        [Required]
        [StringLength(255)]
        [AllowHtml]
        public string XMLString { get; set; }
    }
}
