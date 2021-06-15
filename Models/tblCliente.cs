using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Cadastro_Clientes.Models {
    public class tblCliente {
        
        [DisplayName("Codigo Cliente")]
        public int CodCliente { get; set; }
        [DisplayName("Nome")]
        public string DescCliente { get; set; }
        [DisplayName("Pais")]
        public int CodPais { get; set; }
        public string DDD { get; set; }
        public string Fone { get; set; }
        [DisplayName("Sexo")]
        public int CodSexo { get; set; }
         [DisplayName("E-Mail")]
        public string Email { get; set; }
         [DisplayName("Telefone")]
        public string TelefoneCompleto {get;set;}
         [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Cidade { get; set; }

    }
}