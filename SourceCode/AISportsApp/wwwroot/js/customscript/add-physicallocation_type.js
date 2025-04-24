/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation_Type
JSName: add-physicallocation_type.js
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
//physicallocation_typeAdd Process
function physicallocation_typeAdd() {
var url = getApiURL("api/PhysicalLocation_Type/AddPhysicalLocation_Type");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
}
}
function onPhysicalLocation_TypeAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
}
}
function onPhysicalLocation_TypeAddError(response) {
ShowResponse('Error In PhysicalLocation_Type: ' + response.message, 0);
}
function onPhysicalLocation_TypeAddFailure(response) {
ShowResponse('Failure In PhysicalLocation_Type: ' + response.message, 0);
}
/*****************************************************************************************************************/

