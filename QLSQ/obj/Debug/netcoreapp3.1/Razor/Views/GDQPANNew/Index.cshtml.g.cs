#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a77392ac86d52304a0f87b33eb84a21af0470b1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GDQPANNew_Index), @"mvc.1.0.view", @"/Views/GDQPANNew/Index.cshtml")]
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
#line 1 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\_ViewImports.cshtml"
using QLSQ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\_ViewImports.cshtml"
using QLSQ.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a77392ac86d52304a0f87b33eb84a21af0470b1c", @"/Views/GDQPANNew/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ab331e237f2848e11015b6778e13650d871b876", @"/Views/_ViewImports.cshtml")]
    public class Views_GDQPANNew_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLSQ.WebApp.Models.GDQPANNewViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DetailNew", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row mt-5\">\r\n    <div class=\"col-sm-12\">\r\n        <h5 class=\"text-muted font-weight-medium mb-3\">Giáo dục quốc phòng và an ninh</h5>\r\n    </div>\r\n</div>\r\n<div class=\"row mb-4\">\r\n");
#nullable restore
#line 13 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
     foreach (var news in Model.ListGDQPANNew)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-sm-3  mb-5 mb-sm-2\">\r\n            <div class=\"position-relative image-hover\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 530, "\"", 591, 3);
#nullable restore
#line 17 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
WriteAttributeValue("", 536, Configuration["BaseAddress"], 536, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 565, "/new-image/", 565, 11, true);
#nullable restore
#line 17 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
WriteAttributeValue("", 576, news.ImagePath, 576, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                     class=\"img-fluid\"\r\n                     alt=\"world-news\" />\r\n                <span class=\"thumb-title\">");
#nullable restore
#line 20 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
                                     Write(news.NewCatetoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <h5 class=\"font-weight-600 mt-3\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a77392ac86d52304a0f87b33eb84a21af0470b1c5813", async() => {
#nullable restore
#line 23 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
                                                                                                            Write(news.NewName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-NewID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 23 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
                                                                      WriteLiteral(news.NewID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NewID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-NewID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NewID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </h5>\r\n            <p class=\"fs-15 font-weight-normal\">\r\n                ");
#nullable restore
#line 27 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
           Write(Html.Raw(news.NewContent.Substring(0, 50)));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ...\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 30 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\GDQPANNew\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLSQ.WebApp.Models.GDQPANNewViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591