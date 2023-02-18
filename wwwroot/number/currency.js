
////nhập kho
//function totalBill() {

//    let tr = document.querySelectorAll(".tr");
//    let SL = document.querySelectorAll(".SL");
//    let Gia = document.querySelectorAll(".Gia");
//    let totalAmount = document.getElementById("totalAmount");
//    let ThanhToan = document.getElementById("ThanhToan");
//    let TienCK = document.getElementById("TienCK");
//    let TienThue = document.getElementById("TienThue");
//    let vat = document.getElementById("VAT");
//    let cktm = document.getElementById("CKTM");

//    let totalAmountThuc = document.getElementById("totalAmountThuc");
//    let ThanhToanThuc = document.getElementById("ThanhToanThuc");
//    let TienCKThuc = document.getElementById("TienCKThuc");
//    let TienThueThuc = document.getElementById("TienThueThuc");

//    let Payment = 0;
//    let Amount = 0;
//    let CK = 0;
//    let Thue = 0;
//    for (let i = 0; i <= tr.length - 1; i++) {
//        let CKTM = document.getElementById("CKTM");
//        let vat = document.getElementById("VAT");

//        let count = parseFloat((SL[i].innerText).replaceAll(",", ""));
//        let price = parseFloat((Gia[i].innerText).replaceAll(",", ""));
//        console.log(count);
//        console.log(price);
//        //Tiền hàng
//        Amount += count * price;

//        //Tiền Chiếc khấu
//        CK += (count * price) / 100;
//        console.log("CK:" + CK);

//        //CKTM- thuế suất
//        VAT = vat.value;

//        //Thuế
//        Thue += ((count * price) - (count * price * CK / 100) * VAT) / 100;

//    }
//    Payment = Amount - CK + parseFloat(Thue);

 


//    //toFixed(2)

//    //Dữ liệu tính toán
//    totalAmountThuc.value = parseFloat(Amount).toFixed(2);
//    TienCKThuc.value = parseFloat(CK).toFixed(2);
//    TienThueThuc.value = parseFloat(Thue).toFixed(2);
//    ThanhToanThuc.value = parseFloat(Payment).toFixed(2);


//    //Dữ liệu hiển thị
    
//    totalAmount.value =parseFloat(Amount).toFixed(2);
//    TienCK.value = parseFloat(CK).toFixed(2);
//    TienThue.value = parseFloat(Thue).toFixed(2);
//    ThanhToan.value = parseFloat(Payment).toFixed(2);

//    //bỏ
//    //totalAmount.value = formatCurrencyed(parseFloat(Amount).toFixed(2));
//    //TienCK.value = formatCurrencyed(parseFloat(CK).toFixed(2));
//    //TienThue.value = formatCurrencyed(parseFloat(Thue).toFixed(2));
//    //ThanhToan.value = formatCurrencyed(parseFloat(Payment).toFixed(2));
//}


//const formatCurrencyed = function (money) {
//    Formater = new Intl.NumberFormat('vi-VN');
//    moneyFormated = Formater.format(money);
    
//    return moneyFormated.replaceAll(".", ",");
//}