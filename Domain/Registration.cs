using System;

namespace Domain
{
    public class Registration
    {
        public int Id {get; set;}
        public Owner Owner {get; set;}
        public string RegistrationNumber {get; set;}
        public bool Validation {get; set;}

    }
}
