namespace Domain
{
    public class Registration
    {
        public int Id {get; set;}
        public string Adress {get; set;}
        public string RegistrationNumber {get; set;}
        public bool Validation {get; set;}
       public int OwnerId {get; set;}       
       public Owner Owner {get; set;}
    }
}
