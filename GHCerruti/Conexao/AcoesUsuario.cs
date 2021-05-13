using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using GHCerruti.Models;
using System.Web.Mvc;

namespace GHCerruti.Conexao
{
    public class AcoesUsuario
    {
        Conexao connection = new Conexao();

        public void CadastroUsuario(Usuario user)
        {


            MySqlCommand insert = new MySqlCommand("insert into tbUsuario(ID_User, Nome_User, Observacao_User, DataNascimento_User, Email_User, Login_User, Senha_User) values(@codigo, @nome, @observacao, @datanascimento, @email, @login, @senha)", connection.ConectarBD());
            insert.Parameters.Add("@codigo", MySqlDbType.Int32).Value = user.codigo;
            insert.Parameters.Add("@nome", MySqlDbType.Text).Value = user.nome;
            insert.Parameters.Add("@observacao", MySqlDbType.VarChar).Value = user.observacao;
            insert.Parameters.Add("@datanascimento",MySqlDbType.DateTime).Value = Convert.ToDateTime(user.datanascimento);
            insert.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            insert.Parameters.Add("@login", MySqlDbType.Text).Value = user.login;
            insert.Parameters.Add("@senha", MySqlDbType.Text).Value = user.senha;
          

            insert.ExecuteNonQuery();
            connection.DesconectarBD();


        }




        public Usuario ListarUsuario(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT ID_user FROM tbUsuario WHERE ID_User = {0}", connection.ConectarBD());

            var DadosUsuarios = cmd.ExecuteReader();
            return ListarUsuario(DadosUsuarios).FirstOrDefault();
        }

     

        public List<Usuario> ListarUsuario(MySqlDataReader dt)
        {
            var AltAL = new List<Usuario>();
            while (dt.Read())
            {
                var AlTemp = new Usuario()
                {
                    codigo = Convert.ToInt32(dt["ID_User"]),
                    nome = dt["Nome_User"].ToString(),
                    observacao = dt["Observacao_User"].ToString(),
                    datanascimento = Convert.ToDateTime(dt["DataNascimento_User"]),
                    email = dt["Email_User"].ToString(),
                    login = dt["Login_User"].ToString(),
                    senha = dt["Senha_User"].ToString()

                };
                AltAL.Add(AlTemp);
            }
            dt.Close();
            return AltAL;
        }

        public List<Usuario> ListarUsuarios()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbUsuario", connection.ConectarBD());
            var DadosUsuarios = cmd.ExecuteReader();
            return ListarUsuario(DadosUsuarios);
        }

    }
}