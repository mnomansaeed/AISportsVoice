/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Location_Type
JSName: edit-location_type.js
/*****************************************************************************************************************/
$(document).ready(function () {
location_typeLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//location_typeLoad Process
function location_typeLoad() {
var url = getApiURL("api/Location_Type/GetLocation_TypeById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Location_Type Catch: ' + err.message, 0);
}
}
function onLocation_TypeLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Location_Type Catch: ' + err.message, 0);
}
}
function onLocation_TypeLoadError(response) {
ShowResponse('Error In Location_Type: ' + response.message, 0);
}
function onLocation_TypeLoadFailure(response) {
ShowResponse('Failure In Location_Type: ' + response.message, 0);
}
//location_typeUpdate Process
function location_typeUpdate() {
var url = getApiURL("api/Location_Type/UpdateLocation_Type");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Location_Type Catch: ' + err.message, 0);
}
}
function onLocation_TypeUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Location_Type Catch: ' + err.message, 0);
}
}
function onLocation_TypeUpdateError(response) {
ShowResponse('Error In Location_Type: ' + response.message, 0);
}
function onLocation_TypeUpdateFailure(response) {
ShowResponse('Failure In Location_Type: ' + response.message, 0);
}
/*****************************************************************************************************************/

