// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addRow(tableID) {
    var table = document.getElementById("infoTable");
    var rowCount = table.rows.length;
    var row = table.insertRow(rowCount);
    //Column 1.
    var cell1 = row.insertCell(0);
    var element1 = document.createElement(“input”);
    element1.type = “button”;
}