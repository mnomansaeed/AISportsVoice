/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation
JSName: add-physicallocation.js
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
//physicallocationAdd Process
function physicallocationAdd() {
var url = getApiURL("api/PhysicalLocation/AddPhysicalLocation");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
}
}
function onPhysicalLocationAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
}
}
function onPhysicalLocationAddError(response) {
ShowResponse('Error In PhysicalLocation: ' + response.message, 0);
}
function onPhysicalLocationAddFailure(response) {
ShowResponse('Failure In PhysicalLocation: ' + response.message, 0);
}
/*****************************************************************************************************************/

