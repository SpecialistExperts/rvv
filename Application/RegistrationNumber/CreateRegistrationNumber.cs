namespace Application.RegisterRegistration
{
    using Domain;

    public class RegisterRegistration
    {

        public Registration CreateRegistration(Owner owner, string RegistrationNumber, string AdressToRegister)
        {
            var registration = new Registration
            {
                OwnerId = owner.Id,
                Owner = owner,
                Adress = Application.Encryption.Encryption.Encrypt(AdressToRegister),
                RegistrationNumber = RegistrationNumber,
                Validation = owner.ValidInfo
            };

            return registration;
        }
    }
}
