/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation_Type
JSName: edit-physicallocation_type.js
/*****************************************************************************************************************/
$(document).ready(function () {
physicallocation_typeLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//physicallocation_typeLoad Process
function physicallocation_typeLoad() {
var url = getApiURL("api/PhysicalLocation_Type/GetPhysicalLocation_TypeById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
}
}
function onPhysicalLocation_TypeLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
}
}
function onPhysicalLocation_TypeLoadError(response) {
ShowResponse('Error In PhysicalLocation_Type: ' + response.message, 0);
}
function onPhysicalLocation_TypeLoadFailure(response) {
ShowResponse('Failure In PhysicalLocation_Type: ' + response.message, 0);
}
//physicallocation_typeUpdate Process
function physicallocation_typeUpdate() {
var url = getApiURL("api/PhysicalLocation_Type/UpdatePhysicalLocation_Type");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
}
}
function onPhysicalLocation_TypeUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
}
}
function onPhysicalLocation_TypeUpdateError(response) {
ShowResponse('Error In PhysicalLocation_Type: ' + response.message, 0);
}
function onPhysicalLocation_TypeUpdateFailure(response) {
ShowResponse('Failure In PhysicalLocation_Type: ' + response.message, 0);
}
/*****************************************************************************************************************/

