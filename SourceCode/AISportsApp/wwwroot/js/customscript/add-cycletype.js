/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: CycleType
JSName: add-cycletype.js
/*****************************************************************************************************************/
$(document).ready(function () {
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//cycletypeAdd Process
function cycletypeAdd() {
var url = getApiURL("api/CycleType/AddCycleType");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In CycleType Catch: ' + err.message, 0);
}
}
function onCycleTypeAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In CycleType Catch: ' + err.message, 0);
}
}
function onCycleTypeAddError(response) {
ShowResponse('Error In CycleType: ' + response.message, 0);
}
function onCycleTypeAddFailure(response) {
ShowResponse('Failure In CycleType: ' + response.message, 0);
}
/*****************************************************************************************************************/

