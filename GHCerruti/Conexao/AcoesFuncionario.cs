using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using GHCerruti.Models;
using System.Web.Mvc;

namespace GHCerruti.Conexao
{
    public class AcoesFuncionario
    {
        Conexao connection = new Conexao();
        
        public void CadastroFuncionario(Funcionario funcionario)
        {

               
                MySqlCommand insert = new MySqlCommand("insert into tbFuncionario(ID_Func, Nome_Func, Cargo_Func) values(@codigo, @nome, @cargo)", connection.ConectarBD());
                insert.Parameters.Add("@codigo", MySqlDbType.Int32).Value = funcionario.codigo;
                insert.Parameters.Add("@nome", MySqlDbType.Text).Value = funcionario.nome;
                insert.Parameters.Add("@cargo", MySqlDbType.Text).Value = funcionario.cargo;
                insert.ExecuteNonQuery();
                connection.DesconectarBD();
          
                
        }


        public Funcionario ListarFuncionario(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT ID_Func FROM tbFuncionario WHERE ID_Func = {0}", connection.ConectarBD());

            var DadosFuncionarios = cmd.ExecuteReader();
            return ListarFuncionario(DadosFuncionarios).FirstOrDefault();
        }

        public List<Funcionario> ListarFuncionario(MySqlDataReader dt)
        {
            var AltAL = new List<Funcionario>();
            while (dt.Read())
            {
                var AlTemp = new Funcionario()
                {
                    codigo = Convert.ToInt32(dt["ID_Func"]),
                    nome = dt["Nome_Func"].ToString(),
                    cargo = dt["Cargo_Func"].ToString(),
                    
                };
                AltAL.Add(AlTemp);
            }
            dt.Close();
            return AltAL;
        }
        public List<Funcionario> ListarFuncionario()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario", connection.ConectarBD());
            var DadosFuncionarios = cmd.ExecuteReader();
            return ListarFuncionario(DadosFuncionarios);
        }




    }
}