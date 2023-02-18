const searchDate = document.getElementById("searchDate");
searchDate.addEventListener("click", FilterDateInTable);

function FilterDateInTable() {

    let from, to, table, tr, td, i, txtValue;
    fromInput = document.getElementById("from");
    toInput = document.getElementById("to");
    from = new Date(from.value);
    to = new Date(to.value);
    alert("from: " + from);
    alert("to:" + to);
    table = document.querySelector(".filterTable");
    tr = table.getElementsByTagName("tr");


    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            txtValue = new Date(txtValue.value);
            alert("txtValue: " + txtValue);

            if (txtValue > from && txtValue < to) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}