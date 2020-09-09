namespace Application.Owners
{
    using System;
    using System.Linq;
    using Domain;
    using Persistence;
    public class DataAccess
    {
        private DataContext _context;
        public DataAccess(DataContext context)
        {
            this._context = context;
        }
        public async void CreateOwner(Owner owner)
        {
            // Update created/updated with DateTime
            owner.created_at = DateTime.Now;
            owner.updated_at = DateTime.Now;

            // Get Gemeentenummer
            var gemeentes = _context.Gemeentes.Where(b => b.GemeenteNaam.Equals(owner.Gemeente)).ToList();
            var gemeente = gemeentes.FirstOrDefault().Code;

            // Create registrationnumber    
            var instance = new Application.HesEncryption.HesEncryptions();
            var encryptedNumber = instance.Encrypt(owner.BSN).Substring(0, 12);
            var RegistrationNumber = Application.FormatNumbers.FormatNumber(encryptedNumber, gemeente);

            // Create registration
            var randomNumberInstance = new Application.RandomNumber.RandomNumbers();
            var registration = randomNumberInstance.CreateRegistration(owner, RegistrationNumber);
            Console.WriteLine(registration);
            // Add RegistrationNumber to owner
            owner.Registrations.Append(registration);

            // Add data to database
            _context.Registrations.Add(registration);
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
        }

        public async void AddAdress(Owner owner, string vacationAdress)
        {   
            // Update created/updated with DateTime
            owner.updated_at = DateTime.Now;
            owner.VacationAdress = vacationAdress;

            // Get Gemeentenummer
            var gemeentes = _context.Gemeentes.Where(b => b.GemeenteNaam.Equals(owner.Gemeente)).ToList();
            var gemeente = gemeentes.FirstOrDefault().Code;

            // Create registrationnumber    
            var instance = new Application.HesEncryption.HesEncryptions();
            var encryptedNumber = instance.Encrypt(owner.BSN).Substring(0, 12);
            var RegistrationNumber = Application.FormatNumbers.FormatNumber(encryptedNumber, gemeente);

            // Create registration
            var randomNumberInstance = new Application.RandomNumber.RandomNumbers();
            var registration = randomNumberInstance.CreateRegistration(owner, RegistrationNumber);
            Console.WriteLine(registration.Adress);
            // Add RegistrationNumber to owner
            owner.Registrations.Append(registration);

            // Add data to database
            _context.Registrations.Add(registration);
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }
        
    }
}