#pragma checksum "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "426f691982f4b771f0f17938263cf3f5472c3d19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Home_RequestCustomer), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Home/RequestCustomer.cshtml")]
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
#line 1 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\_ViewImports.cshtml"
using Model.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
using Common.Library;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"426f691982f4b771f0f17938263cf3f5472c3d19", @"/Areas/UserPanel/Views/Home/RequestCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fd061011d3ff4e112a2ad4771d3ee1dc9e49622", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    public class Areas_UserPanel_Views_Home_RequestCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Model.Entities.RequestDevice>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "UserPanel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RequestCustomer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
  
    ViewData["Title"] = "Index";
    int row = 1;
    string query = " ";
    if (ViewBag.Search != null)
    {
        query = ViewBag.Search.ToString();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <h1>لیست درخواست ها</h1>\r\n    <div class=\"mb-7\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "426f691982f4b771f0f17938263cf3f5472c3d195169", async() => {
                WriteLiteral(@"
            <div class=""row align-items-center"">

                <div class=""col-lg-10 col-xl-10"">
                    <div class=""row align-items-center"">
                        <div class=""col-md-10 my-2 my-md-0"">
                            <div class=""input-icon"">
                                <input type=""text"" name=""search"" class=""form-control"" placeholder=""جستجو..."" id=""kt_datatable_search_query"">
                                <span>
                                    <i class=""flaticon2-search-1 text-muted""></i>
                                </span>
                            </div>
                        </div>

                    </div>
                </div>
                <div class=""col-lg-2 col-xl-2 mt-5 mt-lg-0"">
                    <button type=""submit"" class=""btn btn-light-primary px-6 font-weight-bold"">
                        جستجو
                    </button>
                </div>

            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <hr />

    <table class=""table  table-responsive "">
        <thead>
            <tr>
                <th>
                    #
                </th>
                <th>
                    مشتری
                </th>
                <th>
                    شماره تماس
                </th>
                <th>
                    بروزرسانی
                </th>
                <th>
                    دستگاه
                </th>
                <th>
                    کاربر
                </th>
                <th>
                    شرح
                </th>
                <th>
                    وضعیت
                </th>

            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 75 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 79 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(row);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 82 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(Html.DisplayFor(modelItem => item.User.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 85 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(Html.DisplayFor(modelItem => item.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"font-weight-bold text-success\">\r\n                            ");
#nullable restore
#line 89 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                       Write(item.UpDateTime?.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n");
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 94 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 97 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(Html.DisplayFor(modelItem => item.User.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 100 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(Html.Raw(item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 103 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViewStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 107 "E:\Code\Reception\Reception\Web\Areas\UserPanel\Views\Home\RequestCustomer.cshtml"
                row++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    \r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Model.Entities.RequestDevice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
