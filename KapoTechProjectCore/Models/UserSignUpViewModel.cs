using System.ComponentModel.DataAnnotations;

namespace KapoTechProjectCore.Models
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz...!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz...!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Giriniz...!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz...!")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz...!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz...!")]
        [Compare("Password",
            ErrorMessage = "Şifreler Uyumlu Değil, Lütfen Tekrar Deneyiniz...!")]
        public string ConfirmPassword { get; set; }
    }
}
