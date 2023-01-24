function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');


}
/*from dd-mm-yyyy to yyyy-mm-dd*/
function reformatDateString(s) {
    var b = s.split(/\D/);
    return b.reverse().join('-');
}
