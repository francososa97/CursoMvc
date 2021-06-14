using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMvc.Models.TableVM
{
    public class UsersVM
    {
        /// <summary>
        /// Id usuario con el cual se referencia dentro de la base de datos
        /// </summary>
        public int? id { get; set; }
        public string email { get; set; }
        public int? edad { get; set; }


    }
}