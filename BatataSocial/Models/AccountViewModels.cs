using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BatataSocial.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Lembrar esse browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        
        [Required]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [StringLength(25, ErrorMessage = "O nome de usuario deve ter no minimo 5 caracteres e no maximo 25 caracteres.", MinimumLength = 5)]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "A senha deve ter no minimo 8 caracteres e no maximo 20 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }

       


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "O nome de usuario deve ter no minimo 5 caracteres e no maximo 25 caracteres.", MinimumLength = 5)]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "A senha deve ter no minimo 8 caracteres e no maximo 20 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class PerfilViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdUser { get; set; }

        public string UserName { get; set;}

        public string UserPhoto { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "coloque a data no modelo dd/mm/yyyy")]
        public DateTime BirthDate { get; set; }

        [StringLength(40)]
        public string StreetName { get; set; }

        [StringLength(40)]
        public string neighborhood { get; set; }

        [StringLength(40)]
        public string EstadoCivil { get; set; }

        [StringLength(40)]
        public string WorkPlace { get; set; }

        [StringLength(40)]
        public string School { get; set; }

    }

    public class ScrapViewModel
    {
        [Key]
        public int Id { get; set; }

        public string IdUser { get; set; }

        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Scrap { get; set; }

        public string Image { get; set; }
    }

   

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "O nome de usuario deve ter no minimo 5 caracteres e no maximo 25 caracteres.", MinimumLength = 5)]
        [Display(Name = "Usuario")]
        public string User { get; set; }
    }
}
