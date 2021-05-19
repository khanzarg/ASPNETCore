#pragma checksum "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8b4666dee93d65ecf71251e3bd8ccea8004702e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8b4666dee93d65ecf71251e3bd8ccea8004702e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link href=""https://cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css"" rel=""stylesheet"" />

<div class=""container"">

    <button type=""button"" class=""btn btn-success my-3"" data-toggle=""modal"" data-target=""#add"" data-placement=""top"" title=""Add Data"">
        <i class=""fas fa-plus-square""></i>
    </button>

    <table id=""EmployeesTable"" class=""display"" style=""width:100%"">
        <thead>
            <tr>
                <th>No</th>
                <th>Name</th>
                <th>Birth Date</th>
                <th>Gender</th>
                <th>Email</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>

</div>

<!-- Modal Add-->
<div class=""modal fade"" id=""add"" tabindex=""-1"" role=""dialog"" aria-labelledby=""add"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""add"">Data Emp");
            WriteLiteral(@"loyee</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                
                    <div class=""mb-3"">
                        <label for=""name"" class=""form-label"">Name</label>
                        <input type=""text"" class=""form-control"" id=""name"" required>
                        <label for=""email"" class=""form-label"">Email</label>
                        <input type=""text"" class=""form-control"" id=""email"" required>
                        
                        <label for=""birthdate"" class=""form-label"">Birth Date</label>
                        <input type=""date"" class=""form-control"" id=""birthdate"" required><br />
                        <label for=""male"">Male</label>
                        <input type=""radio"" id=""male"" name=""gender"" value=""Pria"" required><br />
                        <labe");
            WriteLiteral(@"l for=""female"">Female</label>
                        <input type=""radio"" id=""female"" name=""gender"" value=""Wanita"" required><br />
                        <div class=""modal-footer"">
                            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                            <button type=""submit"" class=""btn btn-primary"" onclick=""insert()"">Save changes</button>
                        </div>
                    </div>

                
            </div>

        </div>
    </div>
</div>


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js""></script>

    <script>
        $(document).ready(function () {
            $(""#EmployeesTable"").DataTable({
                ajax: {
                    url: ""https://localhost:44320/api/Employee"",
                    dataSrc: """"
                },
                columns: [
                    {
                        ""data"": null,
                        ""render"": (data, type, row, meta) => {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    { ""data"": ""name"" },
                    {
                        ""render"": function (data, type, row) {
                            var date = moment(row[""birthDate""]).format(""DD MMMM YYYY"");
                            return date;
                        }
                    },
      ");
                WriteLiteral(@"              { ""data"": ""gender"" },
                    { ""data"": ""email"" },
                    {
                        ""data"": null,
                        ""render"": function (data, type, row) {
                            return `<button type=""button"" class=""btn btn-warning"" data-toggle=""modal"" data-target=""#add"" data-placement=""top"" title=""Update Data"" onclick=""update(${row[""id""]})""><i class=""fas fa-pen""></i> </button>  <button type=""button"" class=""btn btn-danger"" onclick=""Delete(${row[""id""]})"" data-placement=""top"" title=""Delete Data""><i class=""far fa-minus-square""></i></button>`;
                        },
                        ""orderable"": false,
                        ""searchable"": false
                    }
                ]
            });
        })

        let Delete = (Id) => {
            swal({
                title: ""Are you sure?"",
                text: ""Once deleted, you will not be able to recover this data!"",
                icon: ""warning"",
                button");
                WriteLiteral(@"s: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        $.ajax({
                            url: `/Employee/Delete/${Id}`,
                            type: ""DELETE""
                        }).done((result) => {
                            if (result == 200) {
                                swal({
                                    title: ""Success"",
                                    text: ""Data succsess deleted"",
                                    icon: ""success"",
                                    button: ""Ok""
                                }).then(() => { location.reload() })
                            }
                        }).fail((error) => {
                            console.log(error);
                            swal(""Failed Deleted Data"", "" "", ""error"");
                        })
                    } else {
                        swal(""Your data is safe!"");
  ");
                WriteLiteral(@"                  }

                });
        }

        let insert = () => {
            let emp = new Object();

            emp.name = $(""#name"").val();
            emp.birthDate = $(""#birthdate"").val();
            emp.gender = $('input[name=""gender""]:checked').val();
            emp.email = $(""#email"").val();


            $.ajax({
                url: '/Employee/AddEmployee',
                type: ""POST"",
                data: emp
            }).done(result => {
                if (result == 200) {
                    swal({
                        title: ""Good job!"",
                        text: ""You clicked the button!"",
                        icon: ""success"",
                        button: ""Aww yiss!"",
                    }).then(() => { location.reload() })
                }
            }).fail(result => {
                alert(""failed"")
            })
        }

        let getById = id => {
            console.log(""mulai"");
            $.ajax({
            ");
                WriteLiteral(@"    url: `/Employee/GetById/${id}`,
                type: ""GET""
            }).done(result => {
                
                return result;
            }).fail(result => {
                return result;
            })
        }

        let update = id => {
            $.ajax({
                url: `/Employee/GetById/${id}`,
                type: ""GET""
            }).done(result => {
                console.log(result);
                $(""#name"").val(result.name);
                $(""#birthdate"").val(result.birthDate);
                $(""#gender"").val(result.gender);
                $(""#email"").val(result.email);
                return result;
            }).fail(result => {
                return result;
            })
            
            
            
            
           
        }
    </script>

    
");
            }
            );
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
