/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Location
JSName: edit-location.js
/*****************************************************************************************************************/
$(document).ready(function () {
locationLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//locationLoad Process
function locationLoad() {
var url = getApiURL("api/Location/GetLocationById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Location Catch: ' + err.message, 0);
}
}
function onLocationLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Location Catch: ' + err.message, 0);
}
}
function onLocationLoadError(response) {
ShowResponse('Error In Location: ' + response.message, 0);
}
function onLocationLoadFailure(response) {
ShowResponse('Failure In Location: ' + response.message, 0);
}
//locationUpdate Process
function locationUpdate() {
var url = getApiURL("api/Location/UpdateLocation");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Location Catch: ' + err.message, 0);
}
}
function onLocationUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Location Catch: ' + err.message, 0);
}
}
function onLocationUpdateError(response) {
ShowResponse('Error In Location: ' + response.message, 0);
}
function onLocationUpdateFailure(response) {
ShowResponse('Failure In Location: ' + response.message, 0);
}
/*****************************************************************************************************************/

