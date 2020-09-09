using System;
using System.Collections.Generic;
using Domain;

namespace Application
{
    public class RandomNumber
    {
        public string RandomNumberGenerator(){
            Random random = new Random();
            int RandomNumber = random.Next(0, 1000);

            return RandomNumber.ToString();
        }

        public List<Registration> CreateRegistration(Owner owner){
            var registration = new Registration{
                Owner = owner,
                RegistrationNumber = RandomNumberGenerator(),
                Validation = owner.ValidInfo
            };
            
            var registrations = new List<Registration>();
            registrations.Add(registration);
            return registrations;
        }

        // public string CreateNumber(string gemeente){
        //     char[] array = gemeente.ToCharArray();

        //     var instance = new FormatNumber();
        //     string registrationnumber = instance.GetRandomHexNumber(3) + array[0] + " " + instance.GetRandomHexNumber(3) + array[1] +" " +  
        //                                 instance.GetRandomHexNumber(1) + array[2] + instance.GetRandomHexNumber(2) + " " + array[3] + 
        //                                 instance.GetRandomHexNumber(3);
        //     return registrationnumber;
        // }
    }
}
