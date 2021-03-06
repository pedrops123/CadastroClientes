using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Sistema_Cadastro_Clientes.Models;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Logging;
using Sistema_Cadastro_Clientes.Interfaces;


namespace  Sistema_Cadastro_Clientes.DAO
{

    /// <summary>
    /// Classe DAO Cliente
    /// Contem todos os metodos Data Access Object da tabela tblCliente
    /// </summary>
    public class ClienteDAO :InterfaceDAO<tblCliente> 
    {
        private static  IConfiguration _conf;
        private string _connectionStrings = "";
        public ClienteDAO(IConfiguration conf) {  
            _conf = conf;
            this._connectionStrings = _conf.GetConnectionString("DbCliente");
        } 
        
        public tblCliente GetById(tblCliente data)
        {
           tblCliente cliente = new tblCliente();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    cliente = con.Query<tblCliente>($"SELECT * FROM TesteDB.dbo.tblCliente WHERE CodCliente = { data.CodCliente }").FirstOrDefault();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return cliente;
        }

        public List<tblCliente> GetList()
        {
            List<tblCliente> clientes = new List<tblCliente>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    clientes = con.Query<tblCliente>($"SELECT * FROM TesteDB.dbo.tblCliente").ToList();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return clientes;
        }

        public tblCliente PostData(tblCliente data)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"INSERT INTO TesteDB.dbo.tblCliente VALUES('{data.DescCliente}', {data.CodPais} ,'{data.DDD}','{data.Fone}',{data.CodSexo},'{data.Email}','{data.Endereco}','{data.Cidade}')");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }

        public tblCliente PutData(tblCliente data)
        {
             try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"UPDATE TesteDB.dbo.tblCliente SET DescCliente = '{data.DescCliente}' , CodPais = {data.CodPais} , DDD = '{data.DDD}' , Fone = '{data.Fone}' , CodSexo = {data.CodSexo} , Email = '{data.Email}' , Endereco = '{data.Endereco}' ,Cidade = '{data.Cidade}' WHERE CodCliente = {data.CodCliente}");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return data;
        }

        public tblCliente DeleteData(tblCliente data)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    con.Execute($"DELETE FROM TesteDB.dbo.tblCliente where CodCliente = ${data.CodCliente}");
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