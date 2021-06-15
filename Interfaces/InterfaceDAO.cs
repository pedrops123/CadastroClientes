using System.Collections.Generic;

namespace Sistema_Cadastro_Clientes.Interfaces
{
     /// <summary>
    /// Interface DAO
    /// Interface de padronização das DAO'S
    /// </summary>
    public interface InterfaceDAO<T>{

        /// <summary>
        /// [ Get By Id ] 
        /// Coleta os dados por Id do registro
        /// </summary>
         T GetById(T data);
        /// <summary>
        /// [ GET ]  
        /// Coleta lista de dados do registro
        /// </summary>
         List<T> GetList();
        /// <summary>
        /// [ POST ] 
        /// Insere um registro do tipo T na  base
        /// </summary>
         T PostData(T data);
        /// <summary>
        /// [ PUT ] 
        /// Atualiza um registro do tipo T na  base
        /// </summary>
         T PutData(T data);
        /// <summary>
        /// [ DELETE ]  
        /// DELETA um registro do tipo T na base com base no parametro Cod
        /// </summary>
         T DeleteData(T data);
    }
}