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
    }
}
