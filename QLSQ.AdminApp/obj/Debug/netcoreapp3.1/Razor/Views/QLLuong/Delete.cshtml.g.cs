#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd837da97909bcdbe2763319c2550add18d28e5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QLLuong_Delete), @"mvc.1.0.view", @"/Views/QLLuong/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd837da97909bcdbe2763319c2550add18d28e5c", @"/Views/QLLuong/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3a2936caf1d554385f875525e5982e491311c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_QLLuong_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLSQ.ViewModel.Catalogs.QLLuong.QLLuongDeleteRequest>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-12"">
                <h1 class=""m-0 text-dark"">Xóa quản lý lương</h1>
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
                        <h3 class=""card-title"">DataTable with minimal features & hover style</h3>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <div>
                            <dl class=""row"">
                                <dt class=""col-sm-2"">
                                    ");
#nullable restore
#line 30 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 33 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 36 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.HoTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 39 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.HoTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 42 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDSQ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 45 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDSQ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 48 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 51 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 54 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.TenQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 57 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.TenQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 60 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDHeSoLuongQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 63 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDHeSoLuongQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 66 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.HeSoLuongQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 69 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.HeSoLuongQH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 72 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 75 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 78 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.TenCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 81 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.TenCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 84 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDHeSoPhuCapCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 87 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDHeSoPhuCapCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 90 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.HeSoPhuCapCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 93 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.HeSoPhuCapCV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 96 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.IDLuongCB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 99 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.IDLuongCB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 102 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.LuongCB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 105 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.LuongCB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 108 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Luong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 111 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Luong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                            </dl>\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd837da97909bcdbe2763319c2550add18d28e5c16730", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bd837da97909bcdbe2763319c2550add18d28e5c17021", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 116 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\QLLuong\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IDLuong);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd837da97909bcdbe2763319c2550add18d28e5c18846", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLSQ.ViewModel.Catalogs.QLLuong.QLLuongDeleteRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591