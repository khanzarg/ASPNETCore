#pragma checksum "C:\Users\Alpha\source\repos\ASPNETCore\ASPNETCore\Client\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f17f9de818c8e1de9d92a99dc077347d06ef681a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\Alpha\source\repos\ASPNETCore\ASPNETCore\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alpha\source\repos\ASPNETCore\ASPNETCore\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f17f9de818c8e1de9d92a99dc077347d06ef681a", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "all", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Alpha\source\repos\ASPNETCore\ASPNETCore\Client\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>

<div class=""container"">
    <label for=""year"">Years</label>
    <select class=""form-control"" id=""year"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f17f9de818c8e1de9d92a99dc077347d06ef681a3907", async() => {
                WriteLiteral("ALL");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </select>\r\n    <div id=\"chart\">\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
<script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
<script src=""https://cdn.jsdelivr.net/npm/apexcharts""></script>
<script type=""text/javascript"">

    $(document).ready(function () {
        let urlEmployee = ""https://localhost:44320/api/Employee/"";
        let url = 'https://my-json-server.typicode.com/apexcharts/apexcharts.js/yearly';
        $.ajax({
            url: urlEmployee,
            type: ""GET"",
        }).done((result) => {

            const monthNames = [""January"", ""February"", ""March"", ""April"", ""May"", ""June"",
                ""July"", ""August"", ""September"", ""October"", ""November"", ""December""
            ];

            let all = result.map((r) => {
                return r;
            });

            let allDateBirth = all.map((r) => {
                let day = parseInt(r.birthDate.substr(6, 9));
                let month = parseInt(r.birthDate.substr(5, 7));
                let year = parseInt(r.birthDate.substr(0, 4));

                r.birthDate =");
                WriteLiteral(@" day + '/' + month + '/' + year
                return r.birthDate
            });

            let birthYears = all.map((r) => {
                r.birthDate = parseInt(r.birthDate.substr(4, 8));
                return {
                    gender : r.gender,
                    year : r.birthDate
                }
            });

            console.log(allDateBirth)
            console.log(birthYears)
            //minimum dan maksimum tahun
            let allYears = birthYears.map(r => {
                return r.year;
            }).sort();

            let minYears = allYears[0];
            let maxYears = allYears[allYears.length-1];
            let years = [];
            // dapetin seluruh tahun
            for (let i = minYears; i <= maxYears; i++) {
               years.push(i)
            }
        
            function populate(selector) {
                years.forEach((item, index,arr) => {
                    $(selector).append(`<option value=""${item}"">${item}</opti");
                WriteLiteral(@"on>`)
                })
            }
       
            let selected = """";
            console.log(""option "" + $(""#year"").val());
            $(""#year"").change(function () {
                selected = $(this).children(""option:selected"").val();
                console.log(selected);
            })
            populate('#year');
            console.log(years);

            //data pria
            let pria = birthYears.filter((r) => {
                return (r.gender == ""pria"")
            }).map((r) => {
                return r.year
            }).sort();

            //data wanita
            let wanita = birthYears.filter((r) => {
                return (r.gender == ""wanita"")
            }).map((r) => {
                return r.year
            }).sort();


            console.log(pria)
            console.log(wanita)

            //dari youtube https://www.youtube.com/watch?v=P3gJr_Rd80g
            const count = (arr, val) => {
                return arr.reduce((acc, ele");
                WriteLiteral(@"m) => {
                    return (val === elem ? acc + 1 : acc)
                }, 0)
            }

            let chartPria = [];
            let chartWanita = [];
            let chartPriaO = [];
            let chartWanitaO = [];

            for (let i = 0; i < years.length; i++)
            {
                let resultPria = count(pria, years[i]);
                let resultWanita = count(wanita, years[i]);
                chartPria.push(resultPria);
                chartWanita.push(resultWanita);
            }

            console.log(chartPria)
            console.log(chartWanita)
            var options = {
                series: [{
                    name: 'Pria',
                    data: chartPria
                }, {
                    name: 'Wanita',
                    data: chartWanita
                }],
                chart: {
                    selection: {
                        enabled: true,
                        type: 'x',
                    },");
                WriteLiteral(@"
                    type: 'bar',
                    height: 350,
                    toolbar: {
                        show: true
                    },
                    zoom: {
                        enabled: true,
                        autoScaleYaxis: true,
                    },
                },
                colors: [""#247BA0"",""#FF1654""],
                responsive: [{
                    breakpoint: 480,
                    options: {
                        legend: {
                            position: 'bottom',
                            offsetX: -10,
                            offsetY: 0
                        }
                    }
                }],
                plotOptions: {
                    bar: {
                        borderRadius: 8,
                        columnWidth: '100%',
                        horizontal: false,
                    },
                },
                stroke: {
                    show: true,
                  ");
                WriteLiteral(@"  width: 2,
                    colors: ['transparent']
                },
                labels: allDateBirth,
                xaxis: {
                    type: 'datetime',
                    //categories: years,
                },
                yaxis: {
                    title: {
                        text: 'Jumlah'
                    }
                },
                legend: {
                    position: 'right',
                    offsetY: 40
                },
                fill: {
                    opacity: 1
                },
            };

            var chart = new ApexCharts(document.querySelector(""#chart""), options);
            chart.render();


        }).fail((error) => {
            //failed
            console.log(""request gagal"");
        });
    });

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
