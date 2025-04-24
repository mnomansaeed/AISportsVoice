/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation
JSName: edit-physicallocation.js
/*****************************************************************************************************************/
$(document).ready(function () {
physicallocationLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//physicallocationLoad Process
function physicallocationLoad() {
var url = getApiURL("api/PhysicalLocation/GetPhysicalLocationById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
}
}
function onPhysicalLocationLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
}
}
function onPhysicalLocationLoadError(response) {
ShowResponse('Error In PhysicalLocation: ' + response.message, 0);
}
function onPhysicalLocationLoadFailure(response) {
ShowResponse('Failure In PhysicalLocation: ' + response.message, 0);
}
//physicallocationUpdate Process
function physicallocationUpdate() {
var url = getApiURL("api/PhysicalLocation/UpdatePhysicalLocation");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
}
}
function onPhysicalLocationUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
}
}
function onPhysicalLocationUpdateError(response) {
ShowResponse('Error In PhysicalLocation: ' + response.message, 0);
}
function onPhysicalLocationUpdateFailure(response) {
ShowResponse('Failure In PhysicalLocation: ' + response.message, 0);
}
/*****************************************************************************************************************/

