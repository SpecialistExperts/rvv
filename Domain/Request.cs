using System;
using System.Collections.Generic;

namespace Domain
{
    public class Request
    {
        public int Id {get; set;}
        public string Name {get; set;}

        public string BSN {get; set;}
        public string Adress {get; set;}
        public string Email {get; set;}
        public string AdressToRegister {get; set;}

        public string PhoneNumber {get; set;}
        public bool ValidInfo {get; set;}
        public string Gemeente {get; set;}
        public virtual List<Registration> Registrations {get; set;}
    }
}
