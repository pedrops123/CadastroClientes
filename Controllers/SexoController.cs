using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sistema_Cadastro_Clientes.Models;

namespace Sistema_Cadastro_Clientes.Controllers
{
    public class SexoController:Controller {
         private readonly ILogger<SexoController> _logger;
         SexoDAO _context;
        public SexoController(ILogger<SexoController> logger , IConfiguration configuration)
        {
            _logger = logger;
            _context = new SexoDAO(configuration);
        }

        [HttpGet]
        public JsonResult GetSexoByID(int idSexo){
            tblSexo sexo = new tblSexo();
            sexo.CodSexo = idSexo;
            return Json(_context.GetById(sexo));
        }

        [HttpGet]
        public JsonResult GetListaSexo(){
            return Json(_context.GetList());
        }


        [HttpPost]
        public JsonResult SalvaAtualizaSexo(tblSexo Sexo){
            
            if(Sexo.CodSexo == 0){
                _context.PostData(Sexo);
            }
            else
            {
                _context.PutData(Sexo);
            }
            return Json(Sexo);
        }


        [HttpGet]
        public JsonResult DeletaSexo(int id){
            tblSexo deleteSexo = new tblSexo();
            deleteSexo.CodSexo = id;
            if(id != 0 ){
                _context.DeleteData(deleteSexo);
            }
            return Json(deleteSexo);
        }



    }
}