using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMvc.Models.Files
{
    public class FileVm
    {
        [Required]
        [DisplayName("Mi archivo")]
        public HttpPostedFileBase Archivo1 { get; set; }
        [Required]
        [DisplayName("Mi archivo 2")]
        public HttpPostedFileBase Archivo2 { get; set; }
        [Required]
        [DisplayName("cadena")]
        public string Cadena { get; set; }

    }
}