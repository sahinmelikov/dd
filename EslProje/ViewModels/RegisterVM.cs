using System.ComponentModel.DataAnnotations;

namespace EslProje.ViewModels
{
    public class RegisterVM
    {
        [Required,MaxLength(30),]
        public string Name { get; set; }
        [Required,MaxLength(30),DataType(DataType.EmailAddress)]
        public string Email { get; set;}
        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MinLength(8), DataType(DataType.Password),Compare(nameof(Password))]

        public string ConfirmPassWord { get; set; }
    }
}
