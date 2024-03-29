#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73e73d88f133736b1e5f4345257283c3e90b5326"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Pager_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Pager/Default.cshtml")]
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
#line 1 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\_ViewImports.cshtml"
using QLSQ.AdminApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\_ViewImports.cshtml"
using QLSQ.AdminApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73e73d88f133736b1e5f4345257283c3e90b5326", @"/Views/Shared/Components/Pager/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3a2936caf1d554385f875525e5982e491311c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Pager_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLSQ.ViewModel.Common.PagedResultBase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
   
    var urlTemplate = Url.Action() + "?pageIndex={0}";
    var request = ViewContext.HttpContext.Request;
    foreach (var key in request.Query.Keys)
    {
        if(key == "pageIndex")
        {
            continue;
        }
        if (request.Query[key].Count>1)
        {
            foreach (var item in (string[])request.Query[key])
            {
                urlTemplate += "&" + key + "=" + item;
            }
        }
        else
        {
            urlTemplate += "&" + key + "=" + request.Query[key];
        }
    }
    var starIndex = Math.Max(Model.PageIndex - 5,1);
    var finishIndex = Math.Min(Model.PageIndex + 5, Model.PageCount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
 if(Model.PageCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<ul class=\"pagination\">\r\n");
#nullable restore
#line 29 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
     if (Model.PageIndex != starIndex)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\" title=\"1\"");
            BeginWriteAttribute("href", " href=\"", 913, "\"", 953, 2);
#nullable restore
#line 32 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 920, urlTemplate.Replace("{0}", "1"), 920, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 952, ")", 952, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 954, "\"", 989, 1);
#nullable restore
#line 32 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 962, Model.PageCount.ToString(), 962, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Đầu</a>\r\n        </li>\r\n        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1079, "\"", 1145, 1);
#nullable restore
#line 35 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1086, urlTemplate.Replace("{0}", (Model.PageIndex-1).ToString()), 1086, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trước</a>\r\n        </li>\r\n");
#nullable restore
#line 37 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
     for (var i = starIndex; i <= finishIndex; i++)
    {
        if (i == Model.PageIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item active\">\r\n                <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 44 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
                                         Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n            </li>\r\n");
#nullable restore
#line 46 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 1533, "\"", 1560, 2);
            WriteAttributeValue("", 1541, "Trang", 1541, 5, true);
#nullable restore
#line 49 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue(" ", 1546, i.ToString(), 1547, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1561, "\"", 1608, 1);
#nullable restore
#line 49 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1568, urlTemplate.Replace("{0}",i.ToString()), 1568, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 49 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                                              Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 50 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
     if (Model.PageIndex != finishIndex)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1754, "\"", 1819, 1);
#nullable restore
#line 55 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1761, urlTemplate.Replace("{0}",(Model.PageIndex+1).ToString()), 1761, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >Sau</a>\r\n        </li>\r\n        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1910, "\"", 1973, 1);
#nullable restore
#line 58 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1917, urlTemplate.Replace("{0}",(Model.PageCount.ToString())), 1917, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1974, "\"", 2009, 1);
#nullable restore
#line 58 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1982, Model.PageCount.ToString(), 1982, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Cuối</a>\r\n        </li>\r\n");
#nullable restore
#line 60 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
#nullable restore
#line 62 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLSQ.ViewModel.Common.PagedResultBase> Html { get; private set; }
    }
}
#pragma warning restore 1591
