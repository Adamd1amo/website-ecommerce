#pragma checksum "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4fe8017a904e91d32bb524c333642c86252a5e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_MListProducts), @"mvc.1.0.view", @"/Views/Product/MListProducts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4fe8017a904e91d32bb524c333642c86252a5e7", @"/Views/Product/MListProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43da5b8a0c05820e6044dacf6ceed3ec2f937a09", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_MListProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DoAn1.ViewModels.ManagerProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Danh sách sản phẩm</h1>
<div class=""table-responsive"">
    <table class=""table"">
        <thead>
            <tr>
                <th>Tên sản phẩm</th>
                <th>Tên tiệm</th>
                <th>Giá</th>
                <th>Danh mục</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 20 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 594, "\"", 641, 2);
            WriteAttributeValue("", 601, "MDetailProduct?ProductId=", 601, 25, true);
#nullable restore
#line 24 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
WriteAttributeValue("", 626, item.ProductId, 626, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 24 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
                                                                      Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 27 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
                   Write(item.AgentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 30 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
                   Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 33 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 36 "/Users/namlhung/Downloads/final_pro/DoAn1/Views/Product/MListProducts.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DoAn1.ViewModels.ManagerProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591