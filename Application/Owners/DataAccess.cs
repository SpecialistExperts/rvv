namespace Application.Owners
{
    using System.Collections.Generic;
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

        public async void CreateEncrypedOwner(Owner owner, string AdressToRegister)
        {

            // Get Gemeentenummer
            var gemeentes = _context.Gemeentes.Where(b => b.GemeenteNaam.Equals(owner.Gemeente)).ToList();
            var gemeente = gemeentes.FirstOrDefault().Code;

            // Create registrationnumber    
            var instance = new Application.HesEncryption.HesEncryptions();
            var encryptedNumber = instance.Encrypt(owner.BSN).Substring(0, 16);
            var RegistrationNumber = Application.FormatNumbers.FormatNumber(encryptedNumber, gemeente);
            var encryptedRegistrationNumber = Application.Encryption.Encryption.Encrypt(RegistrationNumber);

            Owner EncryptedOwner = new Owner
            {
                Adress = Application.Encryption.Encryption.Encrypt(owner.Adress),
                BSN = Application.Encryption.Encryption.Encrypt(owner.BSN),
                Email = Application.Encryption.Encryption.Encrypt(owner.Email),
                Gemeente = Application.Encryption.Encryption.Encrypt(owner.Gemeente),
                Name = Application.Encryption.Encryption.Encrypt(owner.Name),
                PhoneNumber = Application.Encryption.Encryption.Encrypt(owner.PhoneNumber),
                ValidInfo = owner.ValidInfo,
                Registrations = owner.Registrations
            };

            // Create registration
            var randomNumberInstance = new Application.RegisterRegistration.RegisterRegistration();
            var registration = randomNumberInstance.CreateRegistration(EncryptedOwner, RegistrationNumber, AdressToRegister);

            // Add encrypted registration to encrypted owner
            EncryptedOwner.Registrations.Append(registration);

            // Add data to database
            _context.Registrations.Add(registration);
            _context.Owners.Add(EncryptedOwner);
            await _context.SaveChangesAsync();
        }

        public Owner GetDecrypedOwner(Owner owner)
        {
            Owner DecryptedOwner = new Owner
            {
                Adress = Application.Encryption.Encryption.Decrypt(owner.Adress),
                BSN = Application.Encryption.Encryption.Decrypt(owner.BSN),
                Email = Application.Encryption.Encryption.Decrypt(owner.Email),
                Gemeente = Application.Encryption.Encryption.Decrypt(owner.Gemeente),
                Name = Application.Encryption.Encryption.Decrypt(owner.Name),
                PhoneNumber = Application.Encryption.Encryption.Decrypt(owner.PhoneNumber),
                ValidInfo = owner.ValidInfo,
                Registrations = new List<Registration>()
            };

            // iterate through registrations to encrypt all registrations
            foreach (var registration in owner.Registrations)
            {
                Registration decryptedRegistration = GetDecryptedRegistration(registration, DecryptedOwner);
                DecryptedOwner.Registrations.Add(decryptedRegistration);
            }


            return DecryptedOwner;
        }

        public Registration GetDecryptedRegistration(Registration registration, Owner decryptedOwner)
        {
            Registration decryptedRegistration = new Registration
            {
                Adress = Application.Encryption.Encryption.Decrypt(registration.Adress),
                RegistrationNumber = registration.RegistrationNumber,
                OwnerId = registration.OwnerId,
                Owner = decryptedOwner,
                Validation = registration.Validation
            };

            return decryptedRegistration;
        }

        public void AddAdress(Owner owner, string AdressToAdd)
        {
            var Encryptioninstance = new Application.HesEncryption.HesEncryptions();
            var Registrationinstance = new Application.RegisterRegistration.RegisterRegistration();


            // Get Gemeentenummer
            var decryptedgemeente = Application.Encryption.Encryption.Decrypt(owner.Gemeente);
            var gemeentes = _context.Gemeentes.Where(b => b.GemeenteNaam.Equals(decryptedgemeente)).ToList();
            var gemeente = gemeentes.FirstOrDefault().Code;

            // Create registrationnumber
            var BSN = Application.Encryption.Encryption.Decrypt(owner.BSN);
            var encryptedNumber = Encryptioninstance.Encrypt(BSN).Substring(0, 16);
            var RegistrationNumber = Application.FormatNumbers.FormatNumber(encryptedNumber, gemeente);
            var encryptedRegistrationNumber = Application.Encryption.Encryption.Encrypt(RegistrationNumber);

            // Create new registration
            Registration registration = Registrationinstance.CreateRegistration(owner, RegistrationNumber, AdressToAdd);

            owner.Registrations.Append(registration);

            // Add data to database
            _context.Registrations.Add(registration);
            _context.Owners.Update(owner);
            _context.SaveChangesAsync();
        }

    }
}