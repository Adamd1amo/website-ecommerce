#pragma checksum "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07c46e139032ecda1f75b4d77dd5e764fd930f3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_DisplayProducts), @"mvc.1.0.view", @"/Views/Customer/DisplayProducts.cshtml")]
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
#line 1 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/_ViewImports.cshtml"
using DoAn1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/_ViewImports.cshtml"
using DoAn1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07c46e139032ecda1f75b4d77dd5e764fd930f3e", @"/Views/Customer/DisplayProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43da5b8a0c05820e6044dacf6ceed3ec2f937a09", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_DisplayProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DoAn1.ViewModels.CSProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 3 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
Write(ViewBag.Ordermess);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
<h1>Danh sách sản phẩm</h1>
<div class=""table-responsive"">
    <table class=""table"">
        <thead>
            <tr>
                <th>Tên sản phẩm</th>
                <th>Tên tiệm</th>
                <th>Mô tả</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 15 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 495, "\"", 549, 2);
            WriteAttributeValue("", 502, "Customer/InforProduct?ProductId=", 502, 32, true);
#nullable restore
#line 19 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
WriteAttributeValue("", 534, item.ProductId, 534, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
                                                                             Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 22 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
                   Write(item.AgentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 25 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 28 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
                   Write(string.Format("{0:0,0}VND", item.Unitprice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 31 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Customer/DisplayProducts.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DoAn1.ViewModels.CSProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
