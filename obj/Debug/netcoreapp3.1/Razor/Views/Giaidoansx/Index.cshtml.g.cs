#pragma checksum "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64fd9ec9724d0bd155f0410659be24aa64528adf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Giaidoansx_Index), @"mvc.1.0.view", @"/Views/Giaidoansx/Index.cshtml")]
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
#line 2 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
using QuanLySanXuat.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64fd9ec9724d0bd155f0410659be24aa64528adf", @"/Views/Giaidoansx/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4916b992cd2137ba256fd5b3eb4a94d6f8a0136", @"/Views/_ViewImports.cshtml")]
    public class Views_Giaidoansx_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLySanXuat.Entities.Giaidoansx>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateOrEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Giaidoansx", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return onSubmitFormGD()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
  
    Layout = "_Layout";



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64fd9ec9724d0bd155f0410659be24aa64528adf5576", async() => {
                WriteLiteral(@"
    <input id=""action"" type=""hidden"" name=""action"" />
    <input id=""Idgdsx"" type=""hidden"" name=""Idgdsx"" />
    <div class=""bg-light p-1 border border-secondary rounded"">
        <h2>Quản Lý Giai Đoạn Sản Xuất</h2>

        <div class=""row"">
            <div class=""col-md-2 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-4 col-sm-12"">
                        Mã GĐ
                    </div>
                    <div class=""col-md-8 col-sm-12"">
                        <input name=""Magdsx"" id=""Magdsx"" maxlength=""255"" onfocus=""this.value=''"" type=""text"" class=""form-control"">
                        <span id=""checkMagd"" class=""text-danger""></span>

                    </div>
                </div>
            </div>

            <div class=""col-md-4 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-2 col-sm-12"">
                        Tên GĐ
                    </div");
                WriteLiteral(@">
                    <div class=""col-md-10 col-sm-12"">
                        <input type=""text"" name=""Tengdsx"" onfocus=""this.value=''"" maxlength=""255"" id=""Tengdsx"" class=""form-control"">
                        <span id=""checkTengd"" class=""text-danger""></span>

                    </div>
                </div>
            </div>

            <div class=""col-md-3 col-sm-12"">
                <div class=""row d-flex align-items-center"">
                    <div class=""col-md-3 col-sm-12"">
                        Ghi chú
                    </div>
                    <div class=""col-md-9 col-sm-12"">
                        <textarea name=""Ghichu"" id=""Ghichu"" onfocus=""this.value=''""");
                BeginWriteAttribute("row", " row=\"", 1960, "\"", 1966, 0);
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""4000"" style=""height:10px;"" class=""form-control""></textarea>
                    </div>
                </div>
            </div>
            <div class=""col-md-3 col-sm-12 "">
                <button type=""submit"" style=""float: right;"" class=""btn btn-primary w-50"" id=""btnAddGD"" onsubmit=""onSubmitFormGD()"">Thêm</button>
                <div class=""d-flex"">
                    <button type=""button"" style=""display:none;"" class=""btn btn-light w-50"" id=""btnCancelGD"">Hủy</button>
                    <button type=""submit"" class=""btn btn-primary w-50"" onclick=""onEditGD()"" id=""btnUpdateGD"" style=""display:none; float: right;"">
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
                        <tr class=""text-center"">
                            <th>Mã giai đoạn</th>
                            <th>Tên gia đoạn</th>
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
                            
                        </tr>
");
#nullable restore
#line 92 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 95 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
                               Write(item.Magdsx);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 96 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
                               Write(item.Tengdsx);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 97 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
                               Write(item.Ghichu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"d-none\">");
#nullable restore
#line 98 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
                                              Write(item.Idgdsx);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>


                                <td class=""table-td-center d-flex"">
                                    <a class=""btn  btn-sm btn-warning "" onclick=""onEditGD(this)""><i class=""fas fa-edit text-white""></i></a>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64fd9ec9724d0bd155f0410659be24aa64528adf13065", async() => {
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
#line 103 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
                                                                                   WriteLiteral(item.Idgdsx);

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
#line 109 "D:\ĐH-08CNTT1\HienCa\NetFramework\QuanLySanXuat\Views\Giaidoansx\Index.cshtml"
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



    function onSubmitFormGD() {
        let isSubmit = false;
        let Tengdsx = document.getElementById(""Tengdsx"").value;
       
        let checkTengd = document.getElementById(""checkTengd"");
       
        let errorMessage = ""Vui lòng cung cấp thông tin!"";

        if (Tengdsx.length == 0 ) {
            checkTengd.innerText = errorMessage;
            
        }
        
        else {
            isSubmit = true;
        }
        return isSubmit;
    }


    let btnAddGD = document.getElementById(""btnAddGD"");
    let btnUpdateGD = document.getElementById(""btnUpdateGD"");
    let btnCancelGD = document.getElementById(""btnCancelGD"");
    let action = document.getElementById(""action"");

    btnCancelGD.addEventListener(""click"", function () {
        btnUpdateGD.style.display = ""none"";
        btnCancel");
            WriteLiteral(@"GD.style.display = ""none"";
        btnAddGD.style.display = ""block"";
    })


    btnAddGD.addEventListener(""click"", function () {
        action.value = ""addItem"";
    })
    btnUpdateGD.addEventListener(""click"", function () {
        action.value = ""editItem"";
    })


    function onEditGD(td) {

        selectedRow = td.parentElement.parentElement;
        document.getElementById(""Magdsx"").value = selectedRow.cells[0].innerHTML;
        document.getElementById(""Tengdsx"").value = selectedRow.cells[1].innerHTML;
        document.getElementById(""Ghichu"").value = selectedRow.cells[2].innerHTML;
        document.getElementById(""Idgdsx"").value = selectedRow.cells[3].innerHTML;



        btnAddGD.style.display = ""none"";
        btnUpdateGD.style.display = ""block"";
        btnCancelGD.style.display = ""block"";

    }
    btnUpdateGD.addEventListener(""click"", function () {
        btnAddGD.style.display = ""block"";
        btnUpdateGD.style.display = ""none"";
        btnCancelGD.style.");
            WriteLiteral("display = \"none\";\r\n\r\n    })\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLySanXuat.Entities.Giaidoansx>> Html { get; private set; }
    }
}
#pragma warning restore 1591
