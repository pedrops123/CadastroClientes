using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Cadastro_Clientes.Models {
    public class tblCliente {
        public int CodCliente { get; set; }
        public string DescCliente { get; set; }
        public int CodPais { get; set; }
        public string DDD { get; set; }
        public string Fone { get; set; }
        public int CodSexo { get; set; }
        public string Email { get; set; }

    }
}