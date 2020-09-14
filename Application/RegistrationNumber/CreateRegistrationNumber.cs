namespace Application.RandomNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;

    public class RandomNumbers
    {
        public string RandomNumberGenerator()
        {
            Random random = new Random();
            int RandomNumber = random.Next(0, 1000);

            return RandomNumber.ToString();
        }

        public Registration CreateRegistration(Owner owner, string RegistrationNumber)
        {
            var registration = new Registration
            {
                OwnerId = owner.Id,
                Owner = owner,
                Adress = owner.AdressToRegister,
                RegistrationNumber = RegistrationNumber,
                Validation = owner.ValidInfo
            };

            return registration;
        }
    }
}
