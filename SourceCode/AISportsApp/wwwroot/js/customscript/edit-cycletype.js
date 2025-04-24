/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: CycleType
JSName: edit-cycletype.js
/*****************************************************************************************************************/
$(document).ready(function () {
cycletypeLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//cycletypeLoad Process
function cycletypeLoad() {
var url = getApiURL("api/CycleType/GetCycleTypeById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In CycleType Catch: ' + err.message, 0);
}
}
function onCycleTypeLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In CycleType Catch: ' + err.message, 0);
}
}
function onCycleTypeLoadError(response) {
ShowResponse('Error In CycleType: ' + response.message, 0);
}
function onCycleTypeLoadFailure(response) {
ShowResponse('Failure In CycleType: ' + response.message, 0);
}
//cycletypeUpdate Process
function cycletypeUpdate() {
var url = getApiURL("api/CycleType/UpdateCycleType");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In CycleType Catch: ' + err.message, 0);
}
}
function onCycleTypeUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In CycleType Catch: ' + err.message, 0);
}
}
function onCycleTypeUpdateError(response) {
ShowResponse('Error In CycleType: ' + response.message, 0);
}
function onCycleTypeUpdateFailure(response) {
ShowResponse('Failure In CycleType: ' + response.message, 0);
}
/*****************************************************************************************************************/

