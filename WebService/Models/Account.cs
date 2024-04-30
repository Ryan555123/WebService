using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Account
    {
        private string _id = "WebServiceRoot";
        private string _password = "qwerty";

        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }

        public bool CheckAccount(string Id , string Password)
        {
            if(Id.Equals(_id) && Password.Equals(_password))
                return true;
            else
                return false;
        }
    }
}