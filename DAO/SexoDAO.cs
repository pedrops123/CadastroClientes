using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Sistema_Cadastro_Clientes.Interfaces;

namespace Sistema_Cadastro_Clientes.Models
{
     /// <summary>
    /// Classe DAO Sexo
    /// Contem todos os metodos Data Access Object da tabela tblSexo
    /// </summary>
    public class SexoDAO : InterfaceDAO<tblSexo>
    {
        private static  IConfiguration _conf;
         private string _connectionStrings = "";
        public SexoDAO(IConfiguration conf){
            _conf = conf;
            this._connectionStrings = _conf.GetConnectionString("DbCliente");
        } 
        
        public tblSexo GetById(tblSexo data)
        {
            tblSexo sexo = new tblSexo();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    sexo = con.Query<tblSexo>($"SELECT * FROM TesteDB.dbo.tblSexo where CodSexo = {data.CodSexo}").FirstOrDefault();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return sexo;
        }

        public List<tblSexo> GetList()
        {
           List<tblSexo> sexos = new List<tblSexo>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    sexos = con.Query<tblSexo>($"SELECT * FROM TesteDB.dbo.tblSexo").ToList();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return sexos;
        }
     
        public tblSexo PostData(tblSexo data)
        {
           try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"INSERT INTO TesteDB.dbo.tblSexo VALUES('{data.DescSexo}')");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }

        public tblSexo PutData(tblSexo data)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"UPDATE TesteDB.dbo.tblSexo SET DescSexo = '{data.DescSexo}' WHERE CodSexo = {data.CodSexo}");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }

        public tblSexo DeleteData(tblSexo data)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"DELETE FROM TesteDB.dbo.tblSexo WHERE CodSexo = {data.CodSexo}");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }
    }
}