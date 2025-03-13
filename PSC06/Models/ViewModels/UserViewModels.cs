using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PSC06.Models.ViewModels
{
	public class QueryViewModels
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
        public int? Edad { get; set; }
	}

	public class AddUserViewModels
	{
		[Required]
        [Display(Name = "Nombre de Usuario")]
		public string Nombre { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="Introduzco su correo", MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirma password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }

    public class EditUserViewModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Introduzco su correo", MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirma password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }
}