using System;
using FluentValidation;
using Sistema_Cadastro_Clientes.Models;

namespace Sistema_Cadastro_Clientes.Validations
{

    public class ClienteValidator:AbstractValidator<tblCliente> {

        public ClienteValidator()
        {
            RuleFor(r=>r.DescCliente).NotEmpty().WithMessage("Descrição cliente não pode ser vazio .");
            RuleFor(r=>r.CodPais).Custom((cod , context)=>{
                if(cod == 0){
                    context.AddFailure("Codigo Pais não pode ser zero.");
                }
            });
            RuleFor(r=>r.DDD).NotEmpty().WithMessage("DDD Não pode ser vazio.");
            RuleFor(r=>r.Fone).NotEmpty().WithMessage("Telefone  Não pode ser vazio.");
            RuleFor(r=>r.CodSexo).Custom((cod , context)=>{
                if(cod == 0){
                    context.AddFailure("Codigo Sexo não pode ser zero.");
                }
            });
            RuleFor(r=>r.Email).NotEmpty().WithMessage("E-mail Não pode ser vazio.");
            RuleFor(r=>r.Cidade).NotEmpty().WithMessage("Cidade Não pode ser vazio.");

            // Valida formatacao telefone
             RuleFor(r=>r.TelefoneCompleto).Custom((telefone,context)=>{
                 if(telefone.Length < 15){
                      context.AddFailure("Formato de telefone incorreto !");
                 }
             });

        }

    }
    
}