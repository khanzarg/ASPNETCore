#pragma checksum "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4db8715cfd1175d1bab4955351794417450e89be"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4db8715cfd1175d1bab4955351794417450e89be", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\alfat\source\repos\ASPNETCore\ASPNETCore\ASPNETCore\Client\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>Hello from our View Template!</p>\r\n\r\n<div id=\"chart\"></div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@" 
    <script src=""https://cdn.jsdelivr.net/npm/apexcharts""></script>

    <script>
        $(document).ready(function () {
            var url = 'https://localhost:44320/api/Employee';

            //Get Employee From API
            $.getJSON(url, response => {
                console.log(response)
                let employees = response.map(employee => {
                    return {
                        gender: employee.gender,
                        year: employee.birthDate.substr(0,4)
                    }
                })
                // get Employee Birth Year
                let employeesBirthYear = []
                employees.map(employee => {
                    if (employeesBirthYear.includes(employee.year)) {
                        return false
                    } else {
                        employeesBirthYear.push(employee.year)
                    }
                })
                employeesBirthYear.sort((a, b) => a - b)               
              ");
                WriteLiteral(@"  console.log(employeesBirthYear)

                // push to array
                let menBirthYear = [], womenBirthYear = []
                employeesBirthYear.forEach(yearEl => {
                    let menCount = 0, womenCount = 0
                    employees.forEach(employeeEl => {
                        if (employeeEl.gender == ""Pria"" && employeeEl.year == yearEl) {
                            menCount++
                        }
                        else if (employeeEl.gender == ""Wanita"" && employeeEl.year == yearEl) {
                            womenCount++
                        }
                    })
                    menBirthYear.push(menCount)
                    womenBirthYear.push(womenCount)
                    //console.log(menBirthYear)
                    //console.log(womenBirthYear)
                })
                var options = {
                    series: [
                        {
                            name: ""Pria"",
                           ");
                WriteLiteral(@" data: menBirthYear
                        },
                        {
                            name: ""Wanita"",
                            data: womenBirthYear
                        }
                    ],
                    chart: {
                        height: 350,
                        type: 'line',
                        dropShadow: {
                            enabled: true,
                            color: '#000',
                            top: 18,
                            left: 7,
                            blur: 10,
                            opacity: 0.2
                        },
                        toolbar: {
                            show: false
                        }
                    },
                    colors: ['#77B6EA', '#545454'],
                    dataLabels: {
                        enabled: true,
                    },
                    stroke: {
                        curve: 'smooth'
                    },
       ");
                WriteLiteral(@"             title: {
                        text: 'Total Employee per Year',
                        align: 'left'
                    },
                    grid: {
                        borderColor: '#e7e7e7',
                        row: {
                            colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                            opacity: 0.5
                        },
                    },
                    markers: {
                        size: 1
                    },
                    xaxis: {
                        categories: employeesBirthYear,
                        title: {
                            text: 'Year'
                        }
                    },
                    yaxis: {
                        title: {
                            text: 'Total'
                        },
                        min: 0,
                        max: 10
                    },
                    legend: {
");
                WriteLiteral(@"                        position: 'top',
                        horizontalAlign: 'right',
                        floating: true,
                        offsetY: -25,
                        offsetX: -5
                    }
                };

                var chart = new ApexCharts(
                    document.querySelector(""#chart""),
                    options
                );

                //$.getJSON(url, function (response) {
                //    console.log(response)
                //    chart.updateSeries([{
                //        name: 'High - 2013',
                //        data: [40, 29, 33, 36, 32, 32, 33]
                //    }])
                //});

                chart.render();
            })
            
        })

        
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
