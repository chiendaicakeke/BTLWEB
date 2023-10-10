using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    internal class AuthenticateUsersModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }

    }
}
