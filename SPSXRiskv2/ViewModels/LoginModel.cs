using SPSXRiskv2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.ViewModels
{
    public class LoginModel
    {
        public int cabid {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }

        #region Constructores
        public LoginModel()
        {

        }// Constructor por defecto

        public LoginModel(XRSKUser user)
        {
            Username = user.UserName;
        }
        #endregion

    }
}
