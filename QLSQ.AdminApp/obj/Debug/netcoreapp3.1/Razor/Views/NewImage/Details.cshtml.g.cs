#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "506dd2e5878654ebe4fcf6360befe378f48fc3a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewImage_Details), @"mvc.1.0.view", @"/Views/NewImage/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"506dd2e5878654ebe4fcf6360befe378f48fc3a7", @"/Views/NewImage/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3a2936caf1d554385f875525e5982e491311c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_NewImage_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLSQ.ViewModel.Catalogs.NewImage.NewImageDetailsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-12"">
                    <h1 class=""m-0 text-dark"">Chi tiết ảnh tin tức</h1>
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
                                <h4>NewImageDetailsModel</h4>
                                <hr />
                                <dl class=""row"">
                       ");
            WriteLiteral("             <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 32 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewImageID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 35 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.NewImageID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 38 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 41 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.NewID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 44 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.NewName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 47 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.NewName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 50 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.ImagePath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 2642, "\"", 2704, 3);
#nullable restore
#line 53 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
WriteAttributeValue("", 2648, Configuration["BaseAddress"], 2648, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2677, "/new-image/", 2677, 11, true);
#nullable restore
#line 53 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
WriteAttributeValue("", 2688, Model.ImagePath, 2688, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"350\" height=\"350\"/>\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 56 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 59 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 62 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.FileSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 65 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.FileSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                </dl>\r\n                            </div>\r\n                            <div>\r\n                                ");
#nullable restore
#line 70 "D:\Project\QL_SQ\QLSQ\QLSQ.AdminApp\Views\NewImage\Details.cshtml"
                           Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506dd2e5878654ebe4fcf6360befe378f48fc3a710585", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLSQ.ViewModel.Catalogs.NewImage.NewImageDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
