using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sistema_Cadastro_Clientes.DAO;
using Sistema_Cadastro_Clientes.Models;
using Sistema_Cadastro_Clientes.Validations;

namespace Sistema_Cadastro_Clientes.Controllers
{

    public class ClienteController:Controller {
        private readonly ILogger<ClienteController> _logger;
        private readonly ILogger<ClienteDAO> _loggerDAO;
        ClienteDAO _context;
        public ClienteController(ILogger<ClienteController> logger , ILogger<ClienteDAO> loggerDAO ,  IConfiguration configuration)
        {
            _logger = logger;
            _loggerDAO = loggerDAO;
            _context = new ClienteDAO(configuration);
        }


        [HttpGet]
        public JsonResult GetClienteByID(int idCliente){
            tblCliente cliente = new tblCliente();
            cliente.CodCliente = idCliente;
            return Json(_context.GetById(cliente));
        }

        [HttpGet]
        public JsonResult GetListaClientes(){
            return Json(_context.GetList());
        }


        [HttpPost]
        public JsonResult SalvaAtualizaCliente(tblCliente cliente){
            object[] retorno = new object[2];
            try
            {
                var splitTelefone = cliente.TelefoneCompleto.Split(' ');
                cliente.DDD = splitTelefone[0].Replace("(","").Replace(")","");
                cliente.Fone = splitTelefone[1].Replace("-","");
            }
            catch(Exception e)
            {
                throw new Exception("Formato de telefone inválido !");
            }
            ClienteValidator validator = new ClienteValidator();
            var result = validator.Validate(cliente);

            if (result.IsValid){
                if(cliente.CodCliente == 0){
                    _context.PostData(cliente);
                }
                else
                {
                    _context.PutData(cliente);
                }
                retorno[0] = true;
                retorno[1] = "Dados Cadastrados com sucesso !";
            }
            else {
                retorno[0] = false;
                retorno[1] = "<b>Erro ao cadastrar dado:</b> <br/>";
                result.Errors.ToList().ForEach(r=>{
                   retorno[1] += $"* { r.ToString() } <br/><br/>"; 
                });
            }

            return Json(retorno);
        }


        [HttpGet]
        public JsonResult DeletaCliente(int id){
            tblCliente deleteCliente = new tblCliente();
            try
            {
                deleteCliente.CodCliente = id;
                if(id != 0 ){
                    _context.DeleteData(deleteCliente);
                }
            }
            catch(Exception e){
                throw e;
            }
            
            return Json(deleteCliente);
        }

    }

}