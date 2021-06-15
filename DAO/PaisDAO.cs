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
    /// Classe DAO Pais
    /// Contem todos os metodos Data Access Object da tabela tblPais
    /// </summary>
    public class PaisDAO : InterfaceDAO<tblPais> {
        private static  IConfiguration _conf;
         private string _connectionStrings = "";
      
        public PaisDAO(IConfiguration conf) {
            _conf = conf;
            this._connectionStrings = _conf.GetConnectionString("DbCliente");
        } 
         

        public tblPais GetById(tblPais data)
        {
            tblPais pais = new tblPais();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    pais = con.Query<tblPais>($"SELECT * FROM TesteDB.dbo.tblPais where CodPais = {data.CodPais}").FirstOrDefault();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return pais;
        }

        public List<tblPais> GetList()
        {
            List<tblPais> paises = new List<tblPais>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    paises = con.Query<tblPais>($"SELECT * FROM TesteDB.dbo.tblPais").ToList();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return paises;
        }

        public tblPais PostData(tblPais data)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"INSERT INTO TesteDB.dbo.tblPais VALUES ('{data.DescPais}')");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }

        public tblPais PutData(tblPais data)
        {
             try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"UPDATE TesteDB.dbo.tblPais  SET DescPais = '{data.DescPais}' where CodPais = {data.CodPais}");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }

        public tblPais DeleteData(tblPais data)
        {
         try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"DELETE TesteDB.dbo.tblPais WHERE CodPais = {data.CodPais}");
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