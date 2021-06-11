using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Sistema_Cadastro_Clientes.Models;

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
            return new tblCliente();
        }

        
        public List<tblCliente> getClientes(){
            return new List<tblCliente>();
        }

        public tblCliente PostCliente(){
            return new tblCliente();
        }


        public tblCliente PutCliente(){
            return new tblCliente();
        }


        public tblCliente DeleteCliente(){
            return new tblCliente();
        }


    }
}