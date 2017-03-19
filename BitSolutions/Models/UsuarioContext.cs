using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace BitSolutions.Models
{
    public class UsuarioContext
    {
        public List<TwitterETT> RetornaUsuario()
        {
            List<TwitterETT> lstRetorno = new List<TwitterETT>();

            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["GamaExp"].ConnectionString;
                String strProcedure = "Sp_Sel_Twitter";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.ConnectionString = connString;

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(strProcedure, conn);
                    comm.CommandType = CommandType.StoredProcedure;

                    MySqlDataReader dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        TwitterETT ett = new TwitterETT();
                        ett.Msg = dr["msg"].ToString();
                        ett.Dt = Convert.ToDateTime(dr["Dt"]);

                        lstRetorno.Add(ett);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstRetorno;
        }

        public void InsereUsuario(UsuarioETT Usuario)
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["GamaExp"].ConnectionString;
                String strProcedure = "SP_Ins_Usuario";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.ConnectionString = connString;

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(strProcedure, conn);
                    comm.CommandType = CommandType.StoredProcedure;

                    MySqlParameter _Email = new MySqlParameter("p_Email", MySqlDbType.VarChar, 200);
                    _Email.Value = Usuario.Email;
                    comm.Parameters.Add(_Email);

                    MySqlParameter p_Estado = new MySqlParameter("p_Estado", MySqlDbType.VarChar, 50);
                    p_Estado.Value = Usuario.Estado;
                    comm.Parameters.Add(p_Estado);

                    MySqlParameter p_Genero = new MySqlParameter("p_Genero", MySqlDbType.VarChar, 50);
                    p_Genero.Value = Usuario.Genero;
                    comm.Parameters.Add(p_Genero);

                    MySqlParameter p_Nome = new MySqlParameter("p_Nome", MySqlDbType.VarChar, 500);
                    p_Nome.Value = Usuario.Nome;
                    comm.Parameters.Add(p_Nome);

                    MySqlParameter p_Sobrenome = new MySqlParameter("p_Sobrenome", MySqlDbType.VarChar, 500);
                    p_Sobrenome.Value = Usuario.Sobrenome;
                    comm.Parameters.Add(p_Sobrenome);

                    MySqlParameter p_Idade = new MySqlParameter("p_Idade", MySqlDbType.VarChar, 50);
                    p_Idade.Value = Usuario.Idade;
                    comm.Parameters.Add(p_Idade);

                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsereTwitter(String msg)
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["GamaExp"].ConnectionString;
                String strProcedure = "SP_Ins_Twitter";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.ConnectionString = connString;

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(strProcedure, conn);
                    comm.CommandType = CommandType.StoredProcedure;

                    MySqlParameter p_msg = new MySqlParameter("p_msg", MySqlDbType.VarChar, 300);
                    p_msg.Value = msg;
                    comm.Parameters.Add(p_msg);
                    
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}