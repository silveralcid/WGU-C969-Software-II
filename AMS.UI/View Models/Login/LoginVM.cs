using AMS.UI.View_Models.Components;
using AMS.UI.View_Models.Interfaces;

namespace AMS.UI.View_Models.Login
{
    internal class LoginVM : IViewModel
    {
        public Field UserName { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Username",
            IsRequired = true,
        };

        public Field Password { get; set; } = new Field()
        {
            FieldType = FieldType.STRING,
            Name = "Password",
            IsRequired = true,
        };

        public bool IsValid()
        {
            Validator.ValidateRequired(UserName);
            Validator.ValidateRequired(Password);

            return (
                UserName.IsValid &&
                Password.IsValid
            );
        }
    }
}
