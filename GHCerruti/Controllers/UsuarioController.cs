using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHCerruti.Models;
using GHCerruti.Conexao;
using MySql.Data.MySqlClient;

namespace GHCerruti.Controllers
{
    public class UsuarioController : Controller
    {
        AcoesUsuario ac = new AcoesUsuario();
        Conexao.Conexao connection = new Conexao.Conexao();
        
        // GET: Usuario
        public ActionResult Usuario()
        {
            return View();
        }




        [AllowAnonymous]
        [HttpPost]
        public JsonResult CodExiste(int codigo)
        {
            return Json(!IsAlreadySigned(codigo));

        }


        private bool IsAlreadySigned(int codigo)
        {
            MySqlCommand select = new MySqlCommand("SELECT ID_User FROM tbUsuario WHERE ID_User = @codigo", connection.ConectarBD());
            select.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader leitor;
            leitor = select.ExecuteReader();

            bool IsAlreadySigned = leitor.HasRows;



            leitor.Close();
            connection.DesconectarBD();
            return (IsAlreadySigned);
        }


        [HttpPost]
        public ActionResult Usuario(Usuario Cadastro)
        {

            if (ModelState.IsValid && !IsAlreadySigned(Cadastro.codigo))
            {
                ac.CadastroUsuario(Cadastro);
                return RedirectToAction("UsuarioCadastrado", "Usuario");
            }
            return View(Cadastro);
        }

        public ActionResult UsuarioCadastrado()
        {
            ViewBag.Message = "Cadastrados";
            var ExibirFun = new AcoesUsuario();
            var AllFun = ExibirFun.ListarUsuarios();
            return View(AllFun);

        }
    }
}