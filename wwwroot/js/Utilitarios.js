function verModal(titulo, texto) {
    return Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'No',
        confirmButtonText: 'Si',
        timer: 8000,
        closeOnConfirm: false
    })
}
//function Imprimir(table,titulo,col1,col2,col3,col4,col5) {
//    //<table><thead></thead><tbody></tbody></table>
//    var head = document.getElementById("head").outerHTML;
//    table = table.replace(head, "");
//    var columnas = "";
//    if (col1 != "") columnas += col1+" ";
//    if (col2 != "") columnas += col2 + " ";
//    if (col3 != "") columnas += col3 + " ";
//    if (col4 != "") columnas += col4 + " ";
//    if (col5 != "") columnas += col5 + " ";
//    var tabla = "<h1>Reporte de " + titulo + " </h1>"
//        + "<h3>"+columnas+"</h3>"
//        + table.outerHTML;
//        //+ "<h3>Especialidad Id          Especialidad</h3>"
//        //+ table.outerHTML;
//        //+ document.getElementById(table).outerHTML;
//        //+ document.getElementById("TbEspecial").outerHTML;
//    var pagina = window.document.body;
//    var ventana = window.open("");
//    ventana.document.write(tabla);
//    ventana.print();
//    ventana.close();
//    window.document.body.pagina;
//}
