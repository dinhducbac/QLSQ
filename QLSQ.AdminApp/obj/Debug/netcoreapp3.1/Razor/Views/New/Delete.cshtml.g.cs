#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fadd041b0b289058c26cc26620087a89cfa9cf7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_New_Delete), @"mvc.1.0.view", @"/Views/New/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fadd041b0b289058c26cc26620087a89cfa9cf7b", @"/Views/New/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3a2936caf1d554385f875525e5982e491311c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_New_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLSQ.ViewModel.Catalogs.New.NewDeleteRequest>
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
#nullable restore
#line 3 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-12"">
                    <h1 class=""m-0 text-dark"">Xóa tin tức</h1>
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
#line 31 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 34 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 37 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewCatetoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 40 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewCatetoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 43 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewCatetoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 46 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewCatetoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 49 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 52 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n");
#nullable restore
#line 54 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                     if (!string.IsNullOrEmpty(Model.ImagePath))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <dt class=\"col-sm-2\">\r\n                                            ");
#nullable restore
#line 57 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                       Write(Html.DisplayNameFor(model => model.ImagePath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </dt>\r\n                                        <dd class=\"col-sm-10\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 3058, "\"", 3120, 3);
#nullable restore
#line 60 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
WriteAttributeValue("", 3064, Configuration["BaseAddress"], 3064, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3093, "/new-image/", 3093, 11, true);
#nullable restore
#line 60 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
WriteAttributeValue("", 3104, Model.ImagePath, 3104, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"350\" width=\"350\" />\r\n                                        </dd>\r\n");
#nullable restore
#line 62 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 64 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 67 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 70 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewDatePost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 73 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewDatePost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 76 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 79 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
                                   Write(Html.DisplayFor(model => model.NewCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                </dl>\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fadd041b0b289058c26cc26620087a89cfa9cf7b13137", async() => {
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fadd041b0b289058c26cc26620087a89cfa9cf7b13432", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 84 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\New\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.NewID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fadd041b0b289058c26cc26620087a89cfa9cf7b15258", async() => {
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
                WriteLiteral("\r\n                                ");
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
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLSQ.ViewModel.Catalogs.New.NewDeleteRequest> Html { get; private set; }
    }
}
#pragma warning restore 1591
