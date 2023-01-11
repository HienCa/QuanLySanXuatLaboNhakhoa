
function myFunction(val) {
    let a = new Intl.NumberFormat('de-DE',
        { style: 'currency', currency: 'VND' }).format(val)
    document.getElementById("demo").innerHTML = a;
    document.getElementById("price").value = val;
}
