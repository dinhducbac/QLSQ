#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd12594df760601742f2242b2d135539ec2e5aea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LuongCoBan_Index), @"mvc.1.0.view", @"/Views/LuongCoBan/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
using QLSQ.ViewModel.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd12594df760601742f2242b2d135539ec2e5aea", @"/Views/LuongCoBan/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3a2936caf1d554385f875525e5982e491311c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_LuongCoBan_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PageResult<QLSQ.ViewModel.Catalogs.LuongCoBan.LuongCoBanViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        setTimeout(function () {\r\n            $(\'#msgAlert\').fadeOut(\'slow\');\r\n        }, 2000);\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"<div class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-12"">
                <h1 class=""m-0 text-dark"">Quản lý chức vụ sĩ quan</h1>

            </div><!-- /.col -->

        </div><!-- /.row -->
    </div><!-- /.container-fluid -->
</div>

<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""row"">
                            <div class=""col-md-6 col-xl-12"">
                                <!--<p>
                                        <a class=""btn btn-primary"" asp-action=""Create"">Create New</a>
                                    </p>-->
                            </div>
                            <div class=""col-md-6 col-xl-12"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd12594df760601742f2242b2d135539ec2e5aea5566", async() => {
                WriteLiteral("\r\n                                    <div class=\"row\">\r\n                                        <!--<div class=\"col-md-9\">\r\n                                                <input type=\"text\" value=\"");
#nullable restore
#line 44 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                                                                     Write(ViewBag.Keyword);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" name=""keyword"" class=""form-control"" />
                                            </div>
                                            <div class=""col-md-3"">
                                                <button type=""submit"" class=""btn btn-primary"">Tìm</button>
                                                <button type=""reset"" onclick=""window.location.href='/LuongCoBan/Index'"" class=""btn btn-dark"">Resest</button>
                                            </div>-->
                                    </div>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.card-header -->\r\n                    <div class=\"card-body\">\r\n");
#nullable restore
#line 57 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                         if (ViewBag.Success == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div id=\"msgAlert\" class=\"alert alert-success\" role=\"alert\">\r\n                                ");
#nullable restore
#line 60 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                           Write(ViewBag.SuccessMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                            </div>\r\n");
#nullable restore
#line 62 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>
                                    ID lương cơ bản
                                </th>
                                <th>
                                    Lương cơ bản
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 76 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                             foreach (var item in Model.Items)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 80 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.IDLuongCB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 83 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.LuongCB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 86 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                                   Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                        ");
#nullable restore
#line 87 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                                   Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                        <!--");
#nullable restore
#line 88 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                                       Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 91 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n\r\n                        ");
#nullable restore
#line 95 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\LuongCoBan\Index.cshtml"
                   Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>



");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PageResult<QLSQ.ViewModel.Catalogs.LuongCoBan.LuongCoBanViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
