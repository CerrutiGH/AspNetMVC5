using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace GHCerruti.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "O campo Código é obrigatório")]
        [Display(Name = "Código")]
        [Remote("CodExiste", "Usuario", HttpMethod = "POST", ErrorMessage = "Código ja cadastrado.")]
        [Range(1, 200, ErrorMessage = "O id deve ser entre 1 e 200")]
        public int codigo { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Nome do usuário")]
        public string nome { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Insira informação de 5 até 50 caracteres")]
        [Required(ErrorMessage = "O campo Observação é obrigatório")]
        [Display(Name = "Observação")]
        public string observacao { get; set; }

        
       
        [Required(ErrorMessage = "O campo Data de nascimento é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de nascimento")]
        public DateTime datanascimento { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
       // [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Somente letras, no mínimo 5 e máximo 15 caracteres")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Somente letras, no mínimo 5 e máximo 15 caracteres")]
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        [Display(Name = "Login")]
        public string login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Required(ErrorMessage = "O campo Confirma senha é obrigatório")]
        [Display(Name = "Confirma senha")]
        [DataType(DataType.Password)]
        [Compare("senha", ErrorMessage ="As senhas são diferentes!")]
        public string confirmasenha { get; set; }

    }
}