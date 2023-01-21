


function myFunction() {


    let countElement = document.getElementById("Count");
    let countReal = document.getElementById("Soluong");
    let priceElement = document.getElementById("Gianhap");
    let priceReal = document.getElementById("Dongia");
    let totalPriceElement = document.getElementById("Thanhtien");
    if (isNaN(priceElement.value)) {
        priceElement.value = 0;
        priceReal.value = 0;
    }
    if (isNaN(priceElement.value)) {
        countElement.value = 0;
        countReal.value = 0;
    }
    priceReal.value = priceElement.value;
    countReal.value = countElement.value;
    let totalPrice = parseFloat(countElement.value) * parseFloat(priceElement.value);

  

    Formater = new Intl.NumberFormat('vi-VN');
    priceFormated = Formater.format(priceElement.value);
    totalPriceFormated = Formater.format(totalPrice);

    priceElement.value = priceFormated.replaceAll(".", ",");
    totalPriceElement.value = totalPriceFormated.replaceAll(".", ",");

    console.log("totalPriceReal :" + totalPrice);
    document.getElementById("Tongtien").value = totalPrice.toFixed(0);
    

}

function ValidateIsNaN() {
    var inputPrice = document.getElementById('Gianhap');
    var inputCount = document.getElementById('Count');
    inputValueA = inputPrice.value;
    inputValueB = inputCount.value;

    if (isNaN(inputValueA)) {
        inputPrice.value = inputValueA.slice(0, inputValueA.length - 1)

    }
    if (isNaN(inputValueB)) {
        inputCount.value = inputValueB.slice(0, inputValueB.length - 1)

    }
}


