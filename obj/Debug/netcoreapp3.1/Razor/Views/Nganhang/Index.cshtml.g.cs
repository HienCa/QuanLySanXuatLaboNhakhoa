#pragma checksum "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b2792496ae6e00eb34396ffcbda180595198939"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nganhang_Index), @"mvc.1.0.view", @"/Views/Nganhang/Index.cshtml")]
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
#line 1 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\_ViewImports.cshtml"
using QuanLySanXuat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\_ViewImports.cshtml"
using QuanLySanXuat.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
using QuanLySanXuat.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b2792496ae6e00eb34396ffcbda180595198939", @"/Views/Nganhang/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4916b992cd2137ba256fd5b3eb4a94d6f8a0136", @"/Views/_ViewImports.cshtml")]
    public class Views_Nganhang_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLySanXuat.Entities.Nganhang>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateOrEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Nganhang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return onSubmitFormNH()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("formDelete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
  
    Layout = "_Layout";



#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b2792496ae6e00eb34396ffcbda1805951989395523", async() => {
                WriteLiteral(@"
    <input id=""action"" type=""hidden"" name=""action"" />
    <input id=""Idnh"" type=""hidden"" name=""Idnh"" />
    <div class=""bg-light p-1 border border-secondary rounded"">
        <h2>Quản Lý Nhà Cung Cấp</h2>

        <div class=""row"">
            <div class=""col-md-4 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-2 col-sm-12"">
                        Tên NH
                    </div>
                    <div class=""col-md-10 col-sm-12"">
                        <input name=""Tennh"" id=""Tennh"" maxlength=""255"" onfocus=""this.value=''"" type=""text"" class=""form-control"">
                        <span id=""checkTennh"" class=""text-danger""></span>

                    </div>
                </div>
            </div>

            <div class=""col-md-4 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-2 col-sm-12"">
                        Địa Chỉ
                    </div>
     ");
                WriteLiteral(@"               <div class=""col-md-10 col-sm-12"">
                        <input type=""text"" name=""Diachi"" onfocus=""this.value=''"" maxlength=""255"" id=""Diachi"" class=""form-control"">
                        <span id=""checkDiachi"" class=""text-danger""></span>

                    </div>
                </div>
            </div>

            <div class=""col-md-4 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-2 col-sm-12"">
                        Email
                    </div>
                    <div class=""col-md-10 col-sm-12"">
                        <input id=""Email"" name=""Email"" onfocus=""this.value=''"" maxlength=""255"" type=""text"" class=""form-control"">
                        <span id=""checkEmail"" class=""text-danger""></span>

                    </div>
                </div>
            </div>
            
        </div>

        <div class=""row mt-2"">
            <div class=""col-md-4 col-sm-12"">
                <div class");
                WriteLiteral(@"=""row d-flex align-items-center"">
                    <div class=""col-md-2 col-sm-12"">
                        Số Thuế
                    </div>
                    <div class=""col-md-10 col-sm-12"">
                        <input type=""text"" name=""Masothue"" onfocus=""this.value=''"" maxlength=""255"" id=""Masothue"" class=""form-control"">
                        <span id=""checkMasothue"" class=""text-danger""></span>

                    </div>
                </div>
            </div>
            <div class=""col-md-4 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-2 col-sm-12"">
                        Ghi chú
                    </div>
                    <div class=""col-md-10 col-sm-12"">
                        <textarea name=""Ghichu"" id=""Ghichu"" onfocus=""this.value=''""");
                BeginWriteAttribute("row", " row=\"", 3129, "\"", 3135, 0);
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""4000"" style=""height:10px;"" class=""form-control""></textarea>
                    </div>
                </div>
            </div>
            <div class=""col-md-4 col-sm-12 "">
                <button type=""submit"" style=""float: right;"" class=""btn btn-primary w-50"" id=""btnAddNh"" onsubmit=""onSubmitFormNH()"">Thêm</button>
                <div class=""d-flex"">
                    <button type=""button"" style=""display:none;"" class=""btn btn-light w-50"" id=""btnCancelNh"">Hủy</button>
                    <button type=""submit"" class=""btn btn-primary w-50"" onclick=""onEditNH()"" id=""btnUpdateNh"" style=""display:none; float: right;"">
                        Cập
                        nhật
                    </button>
                </div>
            </div>
        </div>
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""x_content"">
    <div class=""row"">
        <div class=""col-sm-12"" style=""height:60vh;overflow-y:scroll"">
            <div class=""card-box table-responsive"">


                <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap""
                       cellspacing=""0"" width=""100%"">
                    <thead>
                        <tr  class=""text-center"">
                            <th>Tên NH</th>
                            <th>Dịa Chỉ</th>
                            <th>Email</th>
                            <th>Mã Số Thuế</th>
                            <th>Ghi Chú</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class=""d-none"">
                            <td>.</td>
                            <td>.</td>
                            <td>.</td>
                            <td>.</td>
                            <td>");
            WriteLiteral(".</td>\r\n                            <td>.</td>\r\n\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 124 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 127 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                               Write(item.Tennh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 128 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                               Write(item.Diachi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 129 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 130 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                               Write(item.Masothue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 131 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                               Write(item.Ghichu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"d-none\">");
#nullable restore
#line 132 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                                              Write(item.Idnh);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>


                                <td class=""table-td-center d-flex"">
                                    <a class=""btn  btn-sm btn-warning "" onclick=""onEditNH(this)""><i class=""fas fa-edit text-white""></i></a>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b2792496ae6e00eb34396ffcbda18059519893915017", async() => {
                WriteLiteral("\r\n                                        <button type=\"submit\" class=\"btn  btn-sm btn-danger \"><i class=\"fas fa-trash text-white\"></i></button>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 137 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                                                                                   WriteLiteral(item.Idnh);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 143 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Nganhang\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </tbody>
                </table>

            </div>
        </div>
    </div>

</div>
<script>
    let deleteBtns = document.querySelectorAll('.formDelete');
    deleteBtns.forEach(function (deleteBtn) {
        deleteBtn.addEventListener('submit', function (e) {

            var form = this;

            e.preventDefault();

            swal({
                title: 'Bạn có chắc chắn muốn xóa?',

                icon: 'warning',
                buttons: ['Hủy bỏ!', 'Xác nhận'],
                dangerMode: true,
            }).then(function (isConfirm) {
                if (isConfirm) {

                    form.submit();
                    swal({
                        title: 'Đã xóa!',
                        icon: 'success',
                        timer: 1500,
                        button: false,
                    });

                } else {
                    swal({
                        title: 'Đã hủy!',
                        butt");
            WriteLiteral(@"on: false,
                        icon: 'error',
                        timer: 500,
                    });
                }
            });
        });
    })



    function onSubmitFormNH() {
        let isSubmit = false;
        let Tennh = document.getElementById(""Tennh"").value;
        let Diachi = document.getElementById(""Diachi"").value;
        let Email = document.getElementById(""Email"").value;
        let Masothue = document.getElementById(""Masothue"").value;
       
        let checkTennh = document.getElementById(""checkTennh"");
        let checkDiachi = document.getElementById(""checkDiachi"");
        let checkEmail = document.getElementById(""checkEmail"");
        let checkMasothue = document.getElementById(""checkMasothue"");
        let errorMessage = ""Vui lòng cung cấp thông tin!"";

        if (Tennh.length == 0 && Diachi.length == 0 && Email.length == 0 && Masothue.length == 0) {
            checkTennh.innerText = errorMessage;
            checkDiachi.innerText = error");
            WriteLiteral(@"Message;
            checkEmail.innerText = errorMessage;
            checkMasothue.innerText = errorMessage;

        }
        if (Tennh.length == 0) {
            checkTennh.innerText = errorMessage;

        }
        if (Diachi.length == 0) {
            checkDiachi.innerText = errorMessage;

        }
       
        if (Masothue.length == 0) {
            checkMasothue.innerText = errorMessage;

        }
        if (!validateEmail(Email)) {
            checkEmail.innerText = ""Email không hợp lệ!"";


        }
        else {
            isSubmit = true;
        }
        return isSubmit;
    }


    let btnAddNh = document.getElementById(""btnAddNh"");
    let btnUpdateNh = document.getElementById(""btnUpdateNh"");
    let btnCancelNh = document.getElementById(""btnCancelNh"");
    let action = document.getElementById(""action"");

    btnCancelNh.addEventListener(""click"", function () {
        btnUpdateNh.style.display = ""none"";
        btnCancelNh.style.display = ""none"";");
            WriteLiteral(@"
        btnAddNh.style.display = ""block"";
    })


    btnAddNh.addEventListener(""click"", function () {
        action.value = ""addItem"";
    })
    btnUpdateNh.addEventListener(""click"", function () {
        action.value = ""editItem"";
    })


    function onEditNH(td) {

        selectedRow = td.parentElement.parentElement;
        document.getElementById(""Tennh"").value = selectedRow.cells[0].innerHTML;
        document.getElementById(""Diachi"").value = selectedRow.cells[1].innerHTML;
        document.getElementById(""Email"").value = selectedRow.cells[2].innerHTML;
        document.getElementById(""Masothue"").value = selectedRow.cells[3].innerHTML;
        document.getElementById(""Ghichu"").value = selectedRow.cells[4].innerHTML;
        document.getElementById(""Idnh"").value = selectedRow.cells[5].innerHTML;
        


        btnAddNh.style.display = ""none"";
        btnUpdateNh.style.display = ""block"";
        btnCancelNh.style.display = ""block"";

    }
    btnUpdateNh.addEventLis");
            WriteLiteral("tener(\"click\", function () {\r\n        btnAddNh.style.display = \"block\";\r\n        btnUpdateNh.style.display = \"none\";\r\n        btnCancelNh.style.display = \"none\";\r\n\r\n    })\r\n</script>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLySanXuat.Entities.Nganhang>> Html { get; private set; }
    }
}
#pragma warning restore 1591
