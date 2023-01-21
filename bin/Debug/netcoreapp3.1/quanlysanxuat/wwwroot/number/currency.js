let tr = document.querySelectorAll(".tr");
let SL = document.querySelectorAll(".SL");
let Gia = document.querySelectorAll(".Gia");
let totalAmount = document.getElementById("totalAmount");
let ThanhToan = document.getElementById("ThanhToan");
let TienCK = document.getElementById("TienCK");
let TienThue = document.getElementById("TienThue");
let vat = document.getElementById("VAT");

function totalBill() {
    let Payment = 0;
    let Amount = 0;
    let CK = 0;
    let Thue = 0;
    for (let i = 0; i < tr.length - 1; i++) {
        let CKTM = document.getElementById("CKTM");
        let vat = document.getElementById("VAT");

        let count = parseFloat((SL[i].innerText).replaceAll(",", ""));
        let price = parseFloat((Gia[i].innerText).replaceAll(",", ""));
        console.log(count);
        console.log(price);
        //Tiền hàng
        Amount += count * price;

        //Tiền Chiếc khấu
        CK += (count * price) / 100;
        console.log("CK:" + CK);

        //CKTM- thuế suất
        VAT = vat.value;

        //Thuế
        Thue += ((count * price) - (count * price * CK / 100) * VAT) / 100;

    }
    Payment = Amount - CK + parseFloat(Thue);

    totalAmount.value = parseFloat(Amount).toFixed(2);
    TienCK.value = parseFloat(CK).toFixed(2);
    TienThue.value = parseFloat(Thue).toFixed(2);
    ThanhToan.value = parseFloat(Payment).toFixed(2);
}