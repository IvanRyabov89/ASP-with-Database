using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд.AuthTelephoneDescriptionApp
{
    public class UserLogin
    {
        [Required,MaxLength(256)]
        public string LoginProp { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
