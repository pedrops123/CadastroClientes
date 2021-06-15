using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sistema_Cadastro_Clientes.Models;

namespace Sistema_Cadastro_Clientes.Controllers{
    public class PaisController:Controller {
         private readonly ILogger<PaisController> _logger;
         PaisDAO _context;
        public PaisController(ILogger<PaisController> logger , IConfiguration configuration)
        {
            _logger = logger;
            _context = new PaisDAO(configuration);
        }

        [HttpGet]
        public JsonResult GetPaisByID(int idPais){
            tblPais pais = new tblPais();
            pais.CodPais = idPais;
            return Json(_context.GetById(pais));
        }

        [HttpGet]
        public JsonResult GetListaPais(){
            return Json(_context.GetList());
        }


        [HttpPost]
        public JsonResult SalvaAtualizaPais(tblPais pais){
            
            if(pais.CodPais == 0){
                _context.PostData(pais);
            }
            else
            {
                _context.PutData(pais);
            }
            return Json(pais);
        }


        [HttpGet]
        public JsonResult DeletaPais(int id){
            tblPais deletePais = new tblPais();
            deletePais.CodPais = id;
            if(id != 0 ){
                _context.DeleteData(deletePais);
            }
            return Json(deletePais);
        }

        
    }
}