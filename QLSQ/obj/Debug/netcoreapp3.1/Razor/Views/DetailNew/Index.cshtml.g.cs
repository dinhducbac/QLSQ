#pragma checksum "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55e4f392c84808143f55c8cb59bdac1ab0dcad41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DetailNew_Index), @"mvc.1.0.view", @"/Views/DetailNew/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55e4f392c84808143f55c8cb59bdac1ab0dcad41", @"/Views/DetailNew/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ab331e237f2848e11015b6778e13650d871b876", @"/Views/_ViewImports.cshtml")]
    public class Views_DetailNew_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLSQ.WebApp.Models.DetailNewViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DetailNew", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight-bold text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"row\">     \r\n        <div class=\"col-lg-9 col-sm-6 mb-5 mb-sm-2\">\r\n            <div class=\"row\">\r\n                <h2 class=\"col-lg-12 col-sm-6 font-weight-600 mt-3 mb-3\">\r\n                    ");
#nullable restore
#line 11 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
               Write(Model.NewName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h2>\r\n                <div class=\"col-lg-12 col-sm-6 mb-3 mt-3\">\r\n                    <p class=\"fs-15 font-weight-normal mt-3\">\r\n                        Ngày đăng: ");
#nullable restore
#line 15 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                              Write(Model.NewDatePost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </div>            \r\n                <div class=\"col-lg-12 col-sm-6 position-relative image-hover mt-3 mb-3\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 764, "\"", 826, 3);
#nullable restore
#line 19 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
WriteAttributeValue("", 770, Configuration["BaseAddress"], 770, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 799, "/new-image/", 799, 11, true);
#nullable restore
#line 19 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
WriteAttributeValue("", 810, Model.ImagePath, 810, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                         class=\"img-fluid\"\r\n                         alt=\"world-news\" />\r\n                </div>\r\n                <div class=\"col-lg-12 col-sm-6\">\r\n                    <p class=\"fs-15 font-weight-normal mt-3\">\r\n                        ");
#nullable restore
#line 25 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                   Write(Html.Raw(Model.NewContent));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
                
            </div>
            <div class=""row"">
                <div class=""row col-lg-12 col-sm-6"">
                    <div class=""col-lg-12 col-sm-6"">
                       <div class=""d-flex position-relative float-left"">
                           <h3 class=""section-title"">Tin liên quan</h3>
                       </div>
                    </div>
                </div>
                <div class=""row col-lg-12 col-sm-6"">
");
#nullable restore
#line 39 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                     foreach (var relatedNews in Model.ListRelatedNew)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-4 col-sm-6 grid-margin mb-5 mb-sm-1\">\r\n                            <div class=\"position-relative image-hover\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1906, "\"", 1974, 3);
#nullable restore
#line 43 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
WriteAttributeValue("", 1912, Configuration["BaseAddress"], 1912, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1941, "/new-image/", 1941, 11, true);
#nullable restore
#line 43 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
WriteAttributeValue("", 1952, relatedNews.ImagePath, 1952, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                     class=\"img-fluid\"");
            BeginWriteAttribute("alt", "\r\n                                     alt=\"", 2031, "\"", 2075, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                <span class=\"thumb-title\">");
#nullable restore
#line 46 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                                                     Write(relatedNews.NewCatetoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                            <h5 class=\"font-weight-bold mt-3\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55e4f392c84808143f55c8cb59bdac1ab0dcad419016", async() => {
#nullable restore
#line 49 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                                                                                                                                   Write(relatedNews.NewName);

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
#line 49 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                                                                                      WriteLiteral(relatedNews.NewID);

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
            WriteLiteral("\r\n                            </h5>\r\n                            <p class=\"fs-15 font-weight-normal\">\r\n                                ");
#nullable restore
#line 52 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                           Write(Html.Raw(relatedNews.NewContent.Substring(0, 55)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n");
#nullable restore
#line 55 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-sm-3 mb-5 mb-sm-2"">
            <div class=""row"">
                <div class=""col-sm-12 mt-3 mb-0"">
                    <div class=""d-flex position-relative float-left"">
                        <h3 class=""section-title"">Xem nhiều nhất</h3>
                    </div>
                </div>
");
#nullable restore
#line 66 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                 foreach (var listmostviewnew in Model.ListMostViewNew)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-sm-12\">\r\n                        <div class=\"border-bottom pt-1 pb-3\">\r\n                            <h5 class=\"font-weight-600 mt-0 mb-0\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55e4f392c84808143f55c8cb59bdac1ab0dcad4113294", async() => {
#nullable restore
#line 71 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                                                                                                                                                        Write(listmostviewnew.NewName);

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
#line 71 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                                                                                      WriteLiteral(listmostviewnew.NewID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NewID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-NewID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NewID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </h5>\r\n                            <p class=\"text-color m-0 d-flex align-items-center\">\r\n                                <span class=\"fs-10 mr-1\">");
#nullable restore
#line 74 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                                                    Write(listmostviewnew.NewDatePost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <i class=\"mdi mdi-bookmark-outline mr-3\"></i>\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 79 "D:\Project\QL_SQ\QLSQ\QLSQ\Views\DetailNew\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLSQ.WebApp.Models.DetailNewViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
