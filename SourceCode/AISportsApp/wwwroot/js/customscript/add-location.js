/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Location
JSName: add-location.js
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
//locationAdd Process
function locationAdd() {
var url = getApiURL("api/Location/AddLocation");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Location Catch: ' + err.message, 0);
}
}
function onLocationAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Location Catch: ' + err.message, 0);
}
}
function onLocationAddError(response) {
ShowResponse('Error In Location: ' + response.message, 0);
}
function onLocationAddFailure(response) {
ShowResponse('Failure In Location: ' + response.message, 0);
}
/*****************************************************************************************************************/

