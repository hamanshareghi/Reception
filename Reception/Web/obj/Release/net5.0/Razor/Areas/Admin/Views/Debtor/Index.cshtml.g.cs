#pragma checksum "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Debtor_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Debtor/Index.cshtml")]
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
#line 1 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\_ViewImports.cshtml"
using Model.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
using Common.Library;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6295ef007f12ada1c4350b1c00e5ef5eb46c04ee", @"/Areas/Admin/Views/Debtor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16b7a628962594125e77e46d2747242ec02be011", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Debtor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<Model.Entities.Debtor>, int>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Debtor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-icon-warning font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("ویرایش"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-icon-info font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("شرح"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-icon-danger font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("حذف"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Send", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-icon-success font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_17 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("پیامک"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
  
    int row = 1;
    string query = " ";
    if (ViewBag.Search != null)
    {
        query = ViewBag.Search.ToString();
    }
    int sum =Convert.ToInt32(ViewData["Sum"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <h1 class=\"alert alert-success font-weight-bold\"> جمع مبلغ بدهی مشتریان : ");
#nullable restore
#line 13 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                                                                         Write(sum.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان </h1>\r\n    <div class=\"mb-7\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee10418", async() => {
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
            WriteLiteral("\r\n    </div>\r\n    <hr />\r\n    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee13505", async() => {
                WriteLiteral("ثبت بدهی اشخاص");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </p>
    <table class=""table table-responsive"">
        <thead>
            <tr>
                <th>
                    #
                </th>
                <th>
                    مشتری
                </th>
                <th>
                    تماس
                </th>
                <th>
                    عنوان
                </th>
                <th>
                    مبلغ
                </th>
                <th>
                    بروزرسانی
                </th>
                <th>
                    شرح
                </th>
");
            WriteLiteral("                <th>دستورات</th>\r\n                <th>عملیات</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 74 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
             foreach (var item in Model.Item1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 78 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                   Write(row);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 81 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.User.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 84 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 87 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"text-dark font-weight-bold\">\r\n                            ");
#nullable restore
#line 91 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                       Write(item.Price.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان\r\n                        </p>\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"text-primary \">\r\n                            ");
#nullable restore
#line 96 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                       Write(item.InsertDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 100 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                   Write(Html.Raw(item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee18924", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 115 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                                                                                                            WriteLiteral(item.DebtorId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee21373", async() => {
                WriteLiteral("<i class=\"fas fa-info-circle\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                                                                                                         WriteLiteral(item.DebtorId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 117 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                        if (User.IsInRole("SuperAdmin"))
                       {

#line default
#line hidden
#nullable disable
            WriteLiteral("                           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee24118", async() => {
                WriteLiteral("<i class=\"fas fa-trash\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 119 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                                                                                                             WriteLiteral(item.DebtorId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 120 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"

                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6295ef007f12ada1c4350b1c00e5ef5eb46c04ee26865", async() => {
                WriteLiteral("<i class=\"fas fa-comment-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_15.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_17);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 125 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                                                                                                           WriteLiteral(item.DebtorId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 129 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                row += 1;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td colspan=\"4\" class=\"text-black-50 font-weight-bold\">مجموع مبالغ</td>\r\n                <td colspan=\"1\" class=\"text-center font-weight-bold text-primary\">");
#nullable restore
#line 133 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                                                                             Write(Model.Item1.Sum(c => c.Price).ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n\r\n\r\n\r\n</div>\r\n<div class=\"container\">\r\n");
#nullable restore
#line 142 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
     if (Model.Item2 > 1)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <nav aria-label=\"Page navigation example\">\r\n            <ul class=\"pagination justify-content-center\">\r\n");
#nullable restore
#line 146 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                 for (int i = 1; i <= Model.Item2; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\">\r\n");
#nullable restore
#line 149 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                         if (!string.IsNullOrEmpty(query))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5692, "\"", 5742, 4);
            WriteAttributeValue("", 5699, "/Admin/Debtor/Index?pageId=", 5699, 27, true);
#nullable restore
#line 151 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
WriteAttributeValue("", 5726, i, 5726, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5728, "&search=", 5728, 8, true);
#nullable restore
#line 151 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
WriteAttributeValue("", 5736, query, 5736, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 152 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n");
#nullable restore
#line 154 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5948, "\"", 5984, 2);
            WriteAttributeValue("", 5955, "/Admin/Debtor/Index?pageId=", 5955, 27, true);
#nullable restore
#line 157 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
WriteAttributeValue("", 5982, i, 5982, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 158 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n");
#nullable restore
#line 160 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 162 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </ul>\r\n        </nav>\r\n");
#nullable restore
#line 167 "D:\1Haman\Code\Asp.Net Core\Reception\Reception\Web\Areas\Admin\Views\Debtor\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<Model.Entities.Debtor>, int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
