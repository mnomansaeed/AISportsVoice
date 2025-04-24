/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Location_Type
JSName: add-location_type.js
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
//location_typeAdd Process
function location_typeAdd() {
var url = getApiURL("api/Location_Type/AddLocation_Type");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Location_Type Catch: ' + err.message, 0);
}
}
function onLocation_TypeAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Location_Type Catch: ' + err.message, 0);
}
}
function onLocation_TypeAddError(response) {
ShowResponse('Error In Location_Type: ' + response.message, 0);
}
function onLocation_TypeAddFailure(response) {
ShowResponse('Failure In Location_Type: ' + response.message, 0);
}
/*****************************************************************************************************************/

