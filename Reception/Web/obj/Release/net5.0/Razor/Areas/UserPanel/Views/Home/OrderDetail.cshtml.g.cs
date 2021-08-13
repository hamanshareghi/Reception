#pragma checksum "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bb588913541307e16b41278ea5dc26026a347c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Home_OrderDetail), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Home/OrderDetail.cshtml")]
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
#line 1 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\_ViewImports.cshtml"
using Model.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
using Common.Library;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bb588913541307e16b41278ea5dc26026a347c7", @"/Areas/UserPanel/Views/Home/OrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fd061011d3ff4e112a2ad4771d3ee1dc9e49622", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    public class Areas_UserPanel_Views_Home_OrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Model.Entities.Reception>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
  
    ViewData["Title"] = "Details";
    var listDefect = ViewData["Defects"] as List<DeviceDefect>;
    var listDuty = ViewData["Duty"] as List<Duty>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <!--begin::نمونه-->
            <!--begin::Card-->
            <div class=""card card-custom"">
                <div class=""card-header ribbon ribbon-clip ribbon-right"">
                    <div class=""ribbon-target"" style=""top: 12px;"">
                        <span class=""ribbon-inner bg-success""></span>پذیرش
                    </div>
                    <div class=""card-title"">
                        <h3 class=""card-label"">
                            اطلاعات پذیرش
");
            WriteLiteral("                        </h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <dl class=\"row\">\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 30 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.Serial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 33 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayFor(model => model.Serial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 36 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 39 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 42 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.ReceptionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 45 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Model.ReceptionDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 48 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 51 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 54 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.Product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 57 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayFor(model => model.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 60 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 63 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayFor(model => model.Customer.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 66 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayNameFor(model => model.Customer.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 69 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Html.DisplayFor(model => model.Customer.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ثبت\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 75 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Model.InsertDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            بروزرسانی\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 81 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                       Write(Model.UpDateTime?.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </dd>
                    </dl>
                </div>
            </div>
            <!--end::Card-->


        </div>
        <div class=""col-lg-6"">

            <div class=""card card-custom"">
                <div class=""card-header ribbon ribbon-clip ribbon-right"">
                    <div class=""ribbon-target"" style=""top: 12px;"">
                        <span class=""ribbon-inner bg-warning""></span>ایرادات
                    </div>
                    <div class=""card-title"">
                        <h3 class=""card-label"">
                            شرح ایرادات دستگاه به گفته مشتری
");
            WriteLiteral("                        </h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"card-body\">\r\n");
#nullable restore
#line 105 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                     foreach (var item in listDefect)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""d-flex align-items-center mb-10"">
                            <!--begin::سیمبل-->
                            <div class=""symbol symbol-40 symbol-light-primary mr-5"">
                                <i class="" fas fa-check text-info mr-5""></i>
                            </div>
                            <!--end::سیمبل-->
                            <!--begin::متن-->
                            <div class=""d-flex flex-column font-weight-bold"">
                                <span class=""text-dark text-hover-primary mb-1 font-size-lg"">");
#nullable restore
#line 115 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                                                                        Write(item.Defect.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            WriteLiteral("                            </div>\r\n                            <!--end::متن-->\r\n                        </div>\r\n");
#nullable restore
#line 120 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>

        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-12 col-md-12 col-sm-12"">

            <div class=""card card-custom gutter-b"">
                <div class=""card-header ribbon ribbon-clip ribbon-right"">
                    <div class=""ribbon-target"" style=""top: 12px;"">
                        <span class=""ribbon-inner bg-info""></span>خدمات
                    </div>
                    <div class=""card-title"">
                        <h3 class=""card-label"">لیست خدمات پذیرش :");
#nullable restore
#line 136 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                                            Write(Model.ReceptionId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h3>
                    </div>
                </div>
                <div class=""card-body"">
                    <!--begin::نمونه-->
                    <div class=""example example-basic"">
                        <div class=""example-preview"">
                            <div class=""timeline timeline-justified timeline-4"">
                                <div class=""timeline-bar""></div>
                                <div class=""timeline-items"">
");
#nullable restore
#line 146 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                     foreach (var item in listDuty)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""timeline-item"">
                                            <div class=""timeline-badge"">
                                                <div class=""bg-danger""></div>
                                            </div>

                                            <div class=""timeline-label"">
                                                <span class=""text-primary font-weight-bold"">");
#nullable restore
#line 154 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                                                                       Write(item.ActionDate.ToShamsiDot());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </div>\r\n\r\n                                            <div class=\"timeline-content\">\r\n                                                ");
#nullable restore
#line 158 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                           Write(item.Service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 158 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                                                Write(item.Price.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان  - ");
#nullable restore
#line 158 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                                                                                     Write(Html.Raw(item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 162 "D:\Code\Receptions\Reception\Web\Areas\UserPanel\Views\Home\OrderDetail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end::نمونه-->

                </div>
            </div>
        </div>
    </div>
</div>




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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Model.Entities.Reception> Html { get; private set; }
    }
}
#pragma warning restore 1591
