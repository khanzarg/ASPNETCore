#pragma checksum "D:\Visual Studio Source\ASPNETCore\ASPNETCore\Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "162ba3a63912c9bc1bc322b50202252c41949f5c"
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
#line 1 "D:\Visual Studio Source\ASPNETCore\ASPNETCore\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Visual Studio Source\ASPNETCore\ASPNETCore\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"162ba3a63912c9bc1bc322b50202252c41949f5c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Visual Studio Source\ASPNETCore\ASPNETCore\Client\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>
<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css"">
<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"">

<div class=""my-3"">
    <!--Tombol Add-->
    <button type=""button"" class=""btn btn-success my-3"" data-bs-toggle='modal' data-bs-target=""#add"">
        <i class=""fa fa-plus""></i>
        Add Data
    </button>
    <table id=""tb_API"" class=""display"" style=""width:100%"">
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Gender</th>
                <th>Action</th>
            </tr>
        </thead>
    </table>

</div>

<!--Modal Add-->
<div ");
            WriteLiteral(@"class=""modal fade"" id=""add"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1""
     aria-labelledby=""add"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""add"">Register Account</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "162ba3a63912c9bc1bc322b50202252c41949f5c5663", async() => {
                WriteLiteral(@"
                    <div class=""mb-3"">
                        <label for=""add"" class=""form-label"">Insert Data</label>
                        <input type=""text"" class=""form-control"" id=""name"" placeholder=""Name"">
                        <input type=""email"" class=""form-control"" id=""email"" placeholder=""Email"">
                        <input type=""password"" class=""form-control"" id=""password"" placeholder=""Password"">
                        <input type=""date"" class=""form-control"" id=""birthDate"" placeholder=""Birthdate"">
                        <input type=""text"" class=""form-control"" id=""gender"" placeholder=""Gender"">
                        <input type=""text"" class=""form-control"" id=""phone"" placeholder=""Phone"">
                        <input type=""text"" class=""form-control"" id=""roleId"" placeholder=""RoleId"">
                    </div>
                    <button type=""submit"" class=""btn btn-primary"" onclick=""InsertSAlert();"">Submit</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<!--Modal Update-->
<div class=""modal fade"" id=""update"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1""
     aria-labelledby=""update"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""update"">Editting Data</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "162ba3a63912c9bc1bc322b50202252c41949f5c8848", async() => {
                WriteLiteral(@"
                    <div class=""mb-3"">
                        <label for=""update"" class=""form-label"">Edit Name</label>
                        <input type=""text"" class=""form-control"" id=""editname"">
                        <label for=""update"" class=""form-label"">Edit Gender</label>
                        <input type=""text"" class=""form-control"" id=""editgender"">
                        <label for=""update"" class=""form-label"">Edit Email</label>
                        <input type=""text"" class=""form-control"" id=""editemail"">
                    </div>
                    <button type=""submit"" class=""btn btn-primary"">Submit</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script src=""https://code.jquery.com/jquery-3.5.1.js""></script>
    <script src=""https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js""
            integrity=""sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf"" crossorigin=""anonymous""></script>
    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
    <script>
        $(document).ready(function () {
            //Ajax
            $.ajax({
                url: ""https://localhost:44320/api/Employee"",
                type: ""GET""

            }).done((resultGet) => {
                //table
                $('#tb_API').DataTable({
                    ajax: {
                        url: ""https://localhost:44320/api/Employee"",
                        type: ""GET"",
                        dataSrc: ''
                    },
                    columns: [
                      ");
                WriteLiteral(@"  { ""data"": ""name"" },
                        { ""data"": ""email"" },
                        { ""data"": ""gender"" },
                        {
                            ""data"": null,
                            ""render"": function () {
                                return '<button class=""btn btn-primary"" data-bs-toggle=""modal"" data-bs-target=""#update""><i class=""fa fa-edit""></i>Edit Data</button>' +
                                    ' <button id=""deleteTable"" class=""btn btn-danger"" onclick=""sAlert()""><i class=""fa fa-trash""></i>Delete Data</button>';
                            },
                            ""orderable"": false,
                            ""searchable"": false
                        },
                    ]

                })

                console.log(""Get All"");
                console.log(resultGet);
            }).fail((error) => {
                //error
                console.log(error)
            })//End Ajax
        })
    </script>
    <script>
        let");
                WriteLiteral(@" sAlert = () => {
            swal({
                title: ""Are you sure?"",
                text: ""Once deleted, you will not be able to recover this data!"",
                icon: ""warning"",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        swal(""Data successfully deleted."", {
                            icon: ""success"",
                        });
                    } else {
                        swal(""Your data is still save."");
                    }
                });
        }
    </script>
    <script>
        let sAlertAdd = () => {
            swal({
                title: ""Done"",
                text: ""Data successfully added."",
                icon: ""success"",
                button: ""Ok"",
            })


        }
    </script>
    <script>
        let Insert = () => {
            let obj = new Object();

            obj.name = $");
                WriteLiteral(@"(""#name"").val();
            obj.email = $(""#email"").val();
            obj.password = $(""#password"").val();
            obj.birthDate = $(""#birthDate"").val();
            obj.gender = $(""#gender"").val();
            obj.phone = $(""#phone"").val();
            obj.roleId = parseInt($(""#roleId"").val());

            console.log(obj);

            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                url: ""https://localhost:44320/api/Account/register"",
                type: ""POST"",
                data: JSON.stringify(obj)
            }).done((result) => {
                console.log(result);
                alert(""berhasil"");
            }).fail((error) => {
                console.log(error);
                alert(""gagal"");
            })

            //location.reload(true);
            //window.history.forward(1);

        }
    </script>
    <script>
     ");
                WriteLiteral("   let InsertSAlert = () => {\r\n            sAlertAdd();\r\n            Insert();\r\n            location.reload(true);\r\n        }\r\n    </script>\r\n    \r\n\r\n");
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
