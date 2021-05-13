using System;
using GHCerruti.Conexao;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GHCerruti.Models;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GHCerruti.Controllers
{
    public class FuncionarioController : Controller
    {
        Funcionario func = new Funcionario();
        Conexao.Conexao connection = new Conexao.Conexao();
        AcoesFuncionario ac = new AcoesFuncionario();
        // GET: Funcionario
        public ActionResult Funcionario()
        {
            ViewBag.Message = "Cadastro de Funcionário";
            return View();
        }



        /*============================== VERIFICAÇÃO ================================*/
        [AllowAnonymous]
        [HttpPost]
        public JsonResult CodExiste(int codigo)
        {
            return Json(!IsAlreadySigned(codigo));

        }


        private bool IsAlreadySigned(int codigo) {
            MySqlCommand select = new MySqlCommand("SELECT ID_Func FROM tbFuncionario WHERE ID_Func = @codigo", connection.ConectarBD());
            select.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader leitor;
            leitor = select.ExecuteReader();

            bool IsAlreadySigned = leitor.HasRows;



            leitor.Close();
            connection.DesconectarBD();
            return (IsAlreadySigned);
        }


        [HttpPost]
        public ActionResult Funcionario(Funcionario Cadastro)
        {

            if (ModelState.IsValid && !IsAlreadySigned(Cadastro.codigo))
            {
                ac.CadastroFuncionario(Cadastro);
                return RedirectToAction("FuncionarioCadastrado", "Funcionario");
            }
            return View(Cadastro);
        }
        /*============================== VERIFICAÇÃO FINAL ================================*/

        public ActionResult FuncionarioCadastrado()
        {
            ViewBag.Message = "Cadastrados";
            var ExibirFun = new AcoesFuncionario();
            var AllFun = ExibirFun.ListarFuncionario();
            return View(AllFun);
            
        }

    }
}




