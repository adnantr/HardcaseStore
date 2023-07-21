using Microsoft.AspNetCore.Identity;

namespace Menu.Models
{
    public class CustomIdentityValidation:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int lenght)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Parola en az 6 karakter olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code="PasswordRequiresUpper",
                Description="Parola en az 1 büyük harf içermelidir."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parola en az 1 küçük harf içermelidir."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az 1 alfanümarik karakter içermelidir."
            };
        }
    }
}
