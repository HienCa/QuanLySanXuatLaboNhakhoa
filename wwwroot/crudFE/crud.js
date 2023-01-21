//Nội dung phiếu nhập
let btnAdd = document.getElementById("btnAdd");
let btnUpdate = document.getElementById("btnUpdate");
let btnCancel = document.getElementById("btnCancel");
btnCancel.addEventListener("click", function () {
    btnUpdate.style.display = "none";
    btnCancel.style.display = "none";
    btnAdd.style.display = "block";
})

let action = document.getElementById("action");

let TaoPhieu = document.getElementById("TaoPhieu");

btnAdd.addEventListener("click", function () {
    action.value = "addItem";
})
btnUpdate.addEventListener("click", function () {
    action.value = "editItem";
})
TaoPhieu.addEventListener("click", function () {
    action.value = "TaoPhieu";
})


function onEdit(td) {
    let formNdpnk = document.getElementById("formNdpnk");
    selectedRow = td.parentElement.parentElement;
    document.getElementById("Solo").value = selectedRow.cells[0].innerHTML;

    //let Tenvl = selectedRow.cells[1].innerHTML;
    //for (var i = 0; i < document.getElementById("multipleSelect").length; i++)
    //    if (formNdpnk.multipleSelect[i].innerText[i].innerText == Tenvl) document.getElementById("multipleSelect")[i].selected = true;

    document.getElementById("Soluong").value = selectedRow.cells[2].innerHTML;
    document.getElementById("Count").value = selectedRow.cells[2].innerHTML;
    //let Donvitinh = selectedRow.cells[3].innerHTML;
    //for (var i = 0; i < document.getElementById("Donvitinh").length; i++)
    //    if (formNdpnk.Donvitinh[i].innerText == Donvitinh) document.getElementById("multipleSelect")[i].selected = true;

    document.getElementById("Gianhap").value = selectedRow.cells[4].innerHTML;

    let priceFormated = (selectedRow.cells[4].innerHTML).replaceAll(",", "");
    document.getElementById("Dongia").value = priceFormated;
    document.getElementById("Thanhtien").value = selectedRow.cells[5].innerHTML;


    var Ngaysx = new Date(selectedRow.cells[6].innerHTML);
    var Hansd = new Date(selectedRow.cells[7].innerHTML);
    document.getElementById("Ngaysx").value = formatDate(Ngaysx);
    document.getElementById("Hansd").value = formatDate(Hansd);
    document.getElementById("Idndpnk").value = selectedRow.cells[8].innerHTML;



    btnAdd.style.display = "none";
    btnUpdate.style.display = "block";
    btnCancel.style.display = "block";

}
btnUpdate.addEventListener("click", function () {
    btnAdd.style.display = "block";
    btnUpdate.style.display = "none";
    btnCancel.style.display = "none";

})



//let deleteBtnPnks = document.querySelectorAll('.formDelete');
//deleteBtnPnks.forEach(function (deleteBtn) {
//    deleteBtn.addEventListener('submit', function (e) {
       
//        var form = this;

//        e.preventDefault();

//        swal({
//            title: 'Bạn có chắc chắn muốn xóa?',

//            icon: 'warning',
//            buttons: ['Hủy bỏ!', 'Xác nhận'],
//            dangerMode: true,
//        }).then(function (isConfirm) {
//            if (isConfirm) {

//                form.submit()

//                swal({
//                    title: 'Đã xóa!',
//                    icon: 'success',
//                    timer: 1500,
//                    button: false,
//                });

//            } else {
//                swal({
//                    title: 'Đã hủy!',
//                    button: false,
//                    icon: 'error',
//                    timer: 500,
//                });
//            }
//        });
//    });
//})

//Phiếu trả nợ
function checkInputNdptn() {

    let SotienNdpt = document.getElementById("SotienNdpt").value;
    let GhichuNdpt = document.getElementById("GhichuNdpt").value;
    let checkSotienNdpt = document.getElementById("checkSotienNdpt");
    let checkGhichuNdpt = document.getElementById("checkGhichuNdpt");
    let errorMessage = "Dữ liệu cung cấp quá dài!";
    if (SotienNdpt.length > 255 || GhichuNdpt.length > 255) {
        checkGhichuNdpt.innerText = errorMessage;
        checkSotienNdpt.innerText = errorMessage;
        return false;
    }
    if (SotienNdpt.length == 0) {
        checkSotienNdpt.innerText = "Vui lòng nhập số tiền muốn trả!";

        return false;
    }
    else {

        return true;
    }
}




//Nội dung phiếu trả nợ nhà cung cấp
let btnAddNdptn = document.getElementById("btnAddNdptn");
let btnUpdateNdptn = document.getElementById("btnUpdateNdptn");
let btnCancelNdptn = document.getElementById("btnCancelNdptn");


btnAddNdptn.addEventListener("click", function () {
    let action = document.getElementById("actionNd");
    action.value = "addItem";
})
btnUpdateNdptn.addEventListener("click", function () {
    let action = document.getElementById("actionNd");
    action.value = "editItem";
})



btnCancel.addEventListener("click", function () {
    btnUpdateNdptn.style.display = "none";
    btnCancelNdptn.style.display = "none";
    btnAddNdptn.style.display = "block";
})
//Edit nội dung phiếu
function onEditNdptnncc(td) {

    const IdntnnccEdit = document.getElementById("IdntnnccEdit");
    selectedRow = td.parentElement.parentElement;
    document.getElementById("SotienNdpt").value = selectedRow.cells[1].innerHTML;
    document.getElementById("SotienNdpttra").value = (selectedRow.cells[1].innerHTML).replaceAll(",", "");

    IdntnnccEdit.value = selectedRow.cells[3].innerHTML;
    document.getElementById("GhichuNdpt").value = selectedRow.cells[4].innerHTML;


    btnAddNdptn.style.display = "none";
    btnUpdateNdptn.style.display = "block";
    btnCancelNdptn.style.display = "block";

}




//validate number số tiền trả

function changeSotienNdptn() {

    const moneyElement = document.getElementById("SotienNdpt");

    Formater = new Intl.NumberFormat('vi-VN');
    priceFormated = Formater.format(moneyElement.value);


    document.getElementById("SotienNdpttra").value = document.getElementById("SotienNdpt").value;
    //đổi sau khi gán số không có dấu phẩy
    document.getElementById("SotienNdpt").value = priceFormated.replaceAll(".", ",");


}


//Nội dung phiếu nhập
function onEditNdptnncc(td) {

    const IdntnnccEdit = document.getElementById("IdntnnccEdit");
    selectedRow = td.parentElement.parentElement;
    document.getElementById("SotienNdpt").value = selectedRow.cells[1].innerHTML;
    document.getElementById("SotienNdpttra").value = (selectedRow.cells[1].innerHTML).replaceAll(",", "");

    IdntnnccEdit.value = selectedRow.cells[3].innerHTML;
    document.getElementById("GhichuNdpt").value = selectedRow.cells[4].innerHTML;


    btnAddNdptn.style.display = "none";
    btnUpdateNdptn.style.display = "block";
    btnCancelNdptn.style.display = "block";

}



function checkSotienTraNoNcc() {
    var inputPrice = document.getElementById('SotienNdpt');
    inputValueA = inputPrice.value;

    if (isNaN(inputValueA)) {
        inputPrice.value = inputValueA.slice(0, inputValueA.length - 1)

    }

}









