using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SistemaBorrador.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBorrador.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="El campo Usuario es requerido")]
        public string Usuario { get; set; }
        [BindProperty]
        [Display(Name="Contraseña")]
        [Required(ErrorMessage ="El campo Contaseña es requerido")]
        public string Password { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string nombre = "Pepe";
            string saludo = "Hola como estas";
            this.Usuario = saludo;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                var usuario = this.Usuario;
                var pass = this.Password;              
            }

            return Page();

            var repo = new LoginRepository();
            bool resultado = repo.UsuarioExist(Usuario, Password);
            if (repo.UsuarioExist(usuario, pass))
            {
                Guid guidsession = Guid.NewGuid();
                HttpContext.Session.SetString("sessionId", guidsession.ToString());
                Response.Cookies.Append("sessionId", guidsession.ToString());

                return RedirectToPage("./Test");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o contrasela Incorrectos");
                return Page();
            }
            //validar si estan en la DB

            
        }

    }
}
