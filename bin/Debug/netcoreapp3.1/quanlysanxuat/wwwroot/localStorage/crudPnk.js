
/*let Idpnk = @phieunhapkho.Idpnk;*/

let pnks = [];
const arrPnks = Array.from(pnks);
function getElements() {

    let Tenvl = document.querySelector(".Tenvl");
    let Soluong = document.getElementById("Soluong");
    let Donvitinh = document.querySelector(".Donvitinh");
    let Dongia = document.getElementById("Dongia");
    let Tongtien = document.getElementById("Tongtien");
    let Solo = document.getElementById("Solo");
    let Ngaysx = document.getElementById("Ngaysx");
    let Hansd = document.getElementById("Hansd");
    let CKTM = document.getElementById("CKTM");
    let Thue = document.getElementById("Thue");
    let VAT = document.querySelector(".VAT");
    //let GiaBan = document.getElementById("GiaBan");
}

function addItem() {

    let Tenvl = document.querySelector(".Tenvl");
    let Soluong = document.getElementById("Soluong");
    let Donvitinh = document.querySelector(".Donvitinh");
    let Dongia = document.getElementById("Dongia");
    let Tongtien = document.getElementById("Tongtien");
    let Solo = document.getElementById("Solo");
    let Ngaysx = document.getElementById("Ngaysx");
    let Hansd = document.getElementById("Hansd");
    let CKTM = document.getElementById("CKTM");
    let Thue = document.getElementById("Thue");
    let VAT = document.querySelector(".VAT");

    /*let Idpnk = document.getElementById("Idpnk");*/

    /*const Idpnk = Idpnk.value;*/
    let pnks = localStorage.getItem('pnks' + Idpnk) ? JSON.parse(localStorage.getItem('pnks') + Idpnk) : [];

    arrPnks.push({
        "Idpnk": Idpnk.value,
        "Tenvl": Tenvl.value,
        "Soluong": Soluong.value,
        "Donvitinh": Donvitinh.value,
        "Dongia": Dongia.value,
        "Solo": Solo.value,
        "Tongtien": Tongtien.value,
        "Ngaysx": Ngaysx.value,
        "Hansd": Hansd.value,
        "CKTM": CKTM.value,
        "Thue": Thue.value,
        "Thue": Thue.value,
        "VAT": VAT.value,
        //"GiaBan": GiaBan.value,
    })
    localStorage.setItem('pnks' + Idpnk, JSON.stringify(pnks));
    renderListItem();

}


function renderListItem() {
    //let Idpnk = document.getElementById("Idpnk");

    let pnks = localStorage.getItem('pnks' + Idpnk) ? JSON.parse(localStorage.getItem('pnks') + Idpnk) : [];

    if (pnks.length === 0) {
        document.getElementById('list-pnk').style.display = 'none';
        return false;
    }

    document.getElementById('list-pnk').style.display = 'block';

    let tableContent = `<thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Tên hàng hóa</th>
                                    <th scope="col">Số lượng</th>
                                    <th scope="col">ĐVT</th>
                                    <th scope="col">Số lô</th>
                                    <th scope="col">Đơn giá</th>
                                    <th scope="col">Thành tiền</th>
                                    <th scope="col">%CK</th>
                                    <th scope="col">Ngày SX</th>
                                    <th scope="col">Hạn SD</th>
                                    <th scope="col">Thuế suất</th>
                                    <th scope="col">Giá bán</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>`

    arrPnks.forEach((pnk, index) => {
        let pnkId = index;
        index++;
        tableContent += `
                        <tbody>
                            <tr>
                                  <th scope="row">${index}</th>
                                  <td>${pnk.Tenvl}</td>
                                  <td>${pnk.SoLuong}</td>
                                  <td>${pnk.Donvitinh}</td>
                                  <td>${pnk.Solo}</td>
                                  <td>${pnk.Dongia}</td>
                                  <td>${pnk.Tongtien}</td>
                                  <td>${pnk.CKTM}</td>
                                  <td>${pnk.Ngaysx}</td>
                                  <td>${pnk.Hansd}</td>
                                  <td>${pnk.Thue}</td>
                                  <td></td>
                                  <td><a href='#' onclick='loadItem(${pnkId})'><i class="fas fa-edit text-white"></i></a> |
                                  <a href='#' onclick='deleteItem(${pnkId})'><i class="fas fa-trash-alt text-white"></i></a></td>
                            </tr>

                        </tbody>
                          `
    })

    document.getElementById('grid-pnks').innerHTML = tableContent;
}

function deleteItem(id) {
    /*let Idpnk = document.getElementById("Idpnk");*/
    let pnks = localStorage.getItem('pnks' + Idpnk) ? JSON.parse(localStorage.getItem('pnks') + Idpnk) : [];

    const arrPnks = Array.from(pnks);
    arrPnks.splice(id, 1);//xóa theo key(id) của array và 1 phần tử
    localStorage.setItem("pnks" + Idpnk, JSON.stringify(pnks));

    renderListItem();
}

function loadItem(id) {

    /* let Idpnk = document.getElementById("Idpnk");*/

    let AddBtn = document.getElementById("Add");
    AddBtn.style.display = "none";

    let EditBtn = document.getElementById("Edit");
    EditBtn.style.display = "block";


    /*getElements()*/
    let Tenvl = document.querySelector(".Tenvl");
    let Soluong = document.getElementById("Soluong");
    let Donvitinh = document.querySelector(".Donvitinh");
    let Dongia = document.getElementById("Dongia");
    let ThanhTien = document.getElementById("ThanhTien");
    let Solo = document.getElementById("Solo");
    let Ngaysx = document.getElementById("Ngaysx");
    let Hansd = document.getElementById("Hansd");
    let CKTM = document.getElementById("CKTM");
    let Thue = document.getElementById("Thue");
    let VAT = document.querySelector(".VAT");

    let pnks = localStorage.getItem('pnks' + Idpnk) ? JSON.parse(localStorage.getItem('pnks') + Idpnk) : [];


    Tenvl.value = pnks[id].Tenvl;
    Soluong.value = pnks[id].Soluong;
    Donvitinh.value = pnks[id].Donvitinh;
    Dongia.value = pnks[id].Dongia;
    Solo.value = pnks[id].Solo;
    Tongtien.value = pnks[id].Tongtien;
    Ngaysx.value = pnks[id].Ngaysx;
    Hansd.value = pnks[id].Hansd;
    CKTM.value = pnks[id].CKTM;
    Thue.value = pnks[id].Thue;

}
function editItem(id) {
    //let Idpnk = document.getElementById("Idpnk");

    let AddBtn = document.getElementById("Add");
    AddBtn.style.display = "block";

    let EditBtn = document.getElementById("Edit");
    EditBtn.style.display = "none";

    //let Tenvl = document.querySelector(".Tenvl");
    //let Soluong = document.getElementById("Soluong");
    //let Donvitinh = document.querySelector(".Donvitinh");
    //let Dongia = document.getElementById("Dongia");
    //let ThanhTien = document.getElementById("ThanhTien");
    //let Solo = document.getElementById("Solo");
    //let Ngaysx = document.getElementById("Ngaysx");
    //let Hansd = document.getElementById("Hansd");
    //let CKTM = document.getElementById("CKTM");
    //let Thue = document.getElementById("Thue");
    //let VAT = document.querySelector(".VAT");

    //let pnks = localStorage.getItem('pnks' + Idpnk) ? JSON.parse(localStorage.getItem('pnks') + Idpnk) : [];

    deleteItem(id);
    addItem();
    renderListItem();
}