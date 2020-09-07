using System;

namespace Domain
{
    public class Owner
    {
        public int Id {get; set;}
        public string Name {get; set;}

        public string Adress {get; set;}
        public string Email {get; set;}
        public string VacationAdress {get; set;}

        public string PhoneNumber {get; set;}
        public bool ValidInfo {get; set;}
        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}
    }
}
