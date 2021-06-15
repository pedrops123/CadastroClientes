using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sistema_Cadastro_Clientes.DAO;
using Sistema_Cadastro_Clientes.Models;

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
            
            if(cliente.CodCliente == 0){
                _context.PostData(cliente);
            }
            else
            {
                _context.PutData(cliente);
            }
            return Json(cliente);
        }


        [HttpGet]
        public JsonResult DeletaCliente(int id){
            tblCliente deleteCliente = new tblCliente();
            deleteCliente.CodCliente = id;
            if(id != 0 ){
                _context.DeleteData(deleteCliente);
            }
            return Json(deleteCliente);
        }

    }

}