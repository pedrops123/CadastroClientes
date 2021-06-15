#pragma checksum "C:\Users\pvfurlan\Desktop\Sistema Cadastro Clientes\Views\MainPage\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7abaee41764ca4bf33dc0313be9d2b8350a67d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MainPage_index), @"mvc.1.0.view", @"/Views/MainPage/index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7abaee41764ca4bf33dc0313be9d2b8350a67d1", @"/Views/MainPage/index.cshtml")]
    public class Views_MainPage_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\pvfurlan\Desktop\Sistema Cadastro Clientes\Views\MainPage\index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\pvfurlan\Desktop\Sistema Cadastro Clientes\Views\MainPage\index.cshtml"
Write(Html.Partial("../Shared/header/_header.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"content\">\r\n   ");
#nullable restore
#line 8 "C:\Users\pvfurlan\Desktop\Sistema Cadastro Clientes\Views\MainPage\index.cshtml"
Write(Html.Partial("ModalCadastro/ModalCadastro.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""row-button"">
        <div></div>
        <div class=""content-button""><button><span class=""fa fa-plus""></span>&nbsp;&nbsp;NOVO</button></div>
    </div>
    <div class=""grid-content"">
        <div id=""cabecalho_grid"">
            <div class=""title_grid"">Nome</div>
            <div class=""title_grid"" >Email</div>
            <div class=""title_grid"">Telefone</div>
            <div class=""title_grid"">Endereço</div>
            <div class=""title_grid"">Cidade</div>
            <div class=""title_grid"">Ações</div>
        </div>
        <div id=""result-grid""></div>
    </div>
</div>

");
#nullable restore
#line 26 "C:\Users\pvfurlan\Desktop\Sistema Cadastro Clientes\Views\MainPage\index.cshtml"
Write(Html.Partial("../Shared/footer/_footer.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script>

    // Seta Valores e parametros ao iniciar a pagina 
    $(document).ready(()=>{
        
        // Inicia datatable
        AppendData();
        AppendSexo();
        AppendPais();
        $(""#idCliente"").val(0);
        // Seta mascaras 
        $('#cmp_telefone').mask('(00) 00000-0000');

        //Inicia tooltips 
         $('[data-toggle=""tooltip""]').tooltip() 
    })
        
    
    // Click event botão novo
    $("".content-button button"").click(()=>{
         showModal();
    });


    // Coleta registros cadastrados para o datatable
    function AppendData(){
        $(""#result-grid .tile_result_grid"").remove()
        $.ajax({
            method:'GET',
            url:'Cliente/GetListaClientes',
            contentType: ""application/json"",
            success: (data)=> {
                 data.map((r)=>{
                    $(""#result-grid"").append(`
                
                    <div class=""tile_result_grid"">${ r.descCliente }</div>
      ");
            WriteLiteral(@"              <div class=""tile_result_grid"" >${ r.email }</div>
                    <div class=""tile_result_grid"">(${ r.ddd }) ${r.fone}</div>
                    <div class=""tile_result_grid"">${ r.endereco == null ? '' : r.endereco }</div>
                    <div class=""tile_result_grid"">${ r.cidade == null ? '' : r.cidade}</div>
                    <div class=""tile_result_grid"">
                        <span data-toggle=""tooltip"" data-placement=""top""  onclick=""UpdateCliente(${r.codCliente})"" title=""Editar"" id=""pencil-action action-datatable"" class=""fa fa-pencil fa-2x action-datatable""></span> &nbsp;&nbsp;&nbsp;&nbsp;
                        <span data-toggle=""tooltip"" data-placement=""top""  onclick=""deleteCliente(${r.codCliente})""  title=""Excluir"" id=""trash-action"" class=""fa fa-trash fa-2x action-datatable""></span>
                    </div>
                
                    `)});
            },
            error: (er) => {
                console.log(er);
            }
        });
    }
");
            WriteLiteral(@"
    function UpdateCliente(codCliente){
         $.ajax({
            method:'GET',
            url: 'Cliente/GetClienteByID?idCliente='+codCliente,
            contentType: ""application/json"",
                success: (data) => {
                     SetValoresForm({
                        codCliente:data.codCliente,
                        DescCliente:data.descCliente,
                        TelefoneCompleto: data.ddd + data.fone,
                        Cidade:data.cidade == null ? '' :data.cidade ,
                        CodPais:data.codPais,
                        CodSexo:data.codSexo,
                        Email:data.email,
                        Endereco:data.endereco == null ? '' : data.endereco
                    });
                   
                    showModal();
                },
                error:(er) => {
                    console.log(er);
                }
            });

    }



    function deleteCliente(codCliente){
            $.ajax({
  ");
            WriteLiteral(@"          method:'GET',
            url: 'Cliente/DeletaCliente?id='+codCliente,
            contentType: ""application/json"",
                success: (data) => {
                    AppendData();
                },
                error:(er) => {
                    console.log(er);
                }
            });

    }


    var showModal = ()=>{
           $(""#modal"").removeAttr(""hidden"");
           $(""#modal"").removeClass(""modal hide"");
           $(""#modal"").addClass(""modal"");
           $(""#fundo_backdrop"").removeClass(""backdrop hide"");
           $(""#fundo_backdrop"").addClass(""backdrop"");
           $(""#area-form"").animate({scrollTop:'0px'})
    }

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
