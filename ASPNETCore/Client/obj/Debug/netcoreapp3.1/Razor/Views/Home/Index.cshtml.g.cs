#pragma checksum "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c068ddaeb1cab00d8ff1d2889830cc00a791c3d6"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c068ddaeb1cab00d8ff1d2889830cc00a791c3d6", @"/Views/Home/Index.cshtml")]
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

<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>

<table id=""PlanetsTable"" class=""display"" style=""width:100%"">
    <thead>
        <tr>
            <th>Name</th>
            <th>Diameter</th>
            <th>Terrain</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>

<table id=""EmployeesTable"" class=""display"" style=""width:100%"">
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Birth Date</th>
            <th>Gender</th>
            <th>Email</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    
    <script src=""https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js""></script>




    <script>
        $(document).ready(function () {
            $.ajax({
                url: ""https://swapi.dev/api/planets/"",
                type: ""GET""
            }).done((result) => {
                console.log(result.results)
                let planets = result.results.map((planet) => {
                    return {
                        name: planet.name,
                        diameter: planet.diameter,
                        terrain: planet.terrain
                    }
                })
                $('#PlanetsTable').DataTable({
                    ""aaData"": planets,
                    columns: [
                        {""data"": ""name""},
                        {""data"": ""diameter""},
                        {""data"": ""terrain""}
                    ]
                })
                console.log(planets)
                // success
            }).fail((error) ");
                WriteLiteral(@"=> {
                //fail
                console.log(error)
            })
        });
    </script>

    <script>
        $(document).ready(function () {
            $.ajax({
                url: ""https://localhost:44320/api/Employee"",
                type: ""GET""
            }).done((result) => {
                console.log(result.results)
                let employees = result.map((employee) => {
                    return employee;
                })
                $('#EmployeesTable').DataTable({
                    ""aaData"": employees,
                    columns: [
                        {""data"": ""id""},
                        {""data"": ""name""},
                        {""data"": ""birthDate""},
                        {""data"": ""gender""},
                        {""data"": ""email""}
                    ]
                })
                console.log(employees)
                // success
            }).fail((error) => {
                //fail
                console.log(error");
                WriteLiteral(")\r\n            })\r\n        });\r\n    </script>\r\n");
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
