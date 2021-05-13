using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GHCerruti.Models
{
    public class Funcionario
    {
        
        [Required(ErrorMessage = "O campo Código é obrigatório")]
        [Display(Name = "Código")]
        [Remote("CodExiste", "Funcionario", HttpMethod = "POST", ErrorMessage = "Código ja cadastrado.")]
        public int codigo { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Nome do Funcionário")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Cargo é obrigatório")]
        [Display(Name = "Cargo")]
        public string cargo { get; set; }
    }
}