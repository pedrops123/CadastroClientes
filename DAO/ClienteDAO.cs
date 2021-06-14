using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Sistema_Cadastro_Clientes.Models;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace  Sistema_Cadastro_Clientes.DAO
{
    public class ClienteDAO
    {
        private static  IConfiguration _conf;
        public ClienteDAO(IConfiguration conf)
        {
            _conf = conf;
        }
        private string _connectionStrings = _conf.GetSection("ConnectionStrings").GetConnectionString("DbCliente");
        
        
        
        public tblCliente getClienteById(int id){
            tblCliente cliente = new tblCliente();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    cliente = con.Query<tblCliente>($"SELECT * FROM TesteDB.dbo.tblCliente WHERE CodCliente = {id}").FirstOrDefault();
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return cliente;
        }

        
        public List<tblCliente> getClientes(){
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

        public tblCliente PostCliente(tblCliente cliente){
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"INSERT INTO TesteDB.dbo.tblCliente VALUES('{cliente.DescCliente}', {cliente.CodPais} ,'{cliente.DDD}','{cliente.Fone}',{cliente.CodSexo},'{cliente.Email}','{cliente.Endereco}','{cliente.Cidade}')");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return cliente;
        }


        public tblCliente PutCliente(tblCliente cliente){
             try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    var retorno =  con.Execute($"UPDATE TesteDB.dbo.tblCliente SET DescCliente = '{cliente.DescCliente}' , CodPais = {cliente.CodPais} , DDD = '{cliente.DDD}' , Fone = '{cliente.Fone}' , CodSexo = {cliente.CodSexo} , Email = '{cliente.Email}' , Endereco = '{cliente.Endereco}' ,Cidade = '{cliente.Cidade}' WHERE CodCliente = {cliente.CodCliente}");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return cliente;
        }


        public tblCliente DeleteCliente(tblCliente cliente){
             try
            {
                using (SqlConnection con = new SqlConnection(_connectionStrings)){
                    con.Open();
                    con.Execute($"DELETE FROM TesteDB.dbo.tblCliente where CodCliente = ${cliente.CodCliente}");
                    con.Close();
                }
            }
            catch(Exception e){
                throw e;
            }
            return cliente;
        }


    }
}