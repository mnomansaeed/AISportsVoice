/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 9:38:00 AM
TableName: Sterilizer
JSName: add-sterilizer.js
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
//sterilizerAdd Process
function sterilizerAdd() {
var url = getApiURL("api/Sterilizer/AddSterilizer");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
}
}
function onSterilizerAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
}
}
function onSterilizerAddError(response) {
ShowResponse('Error In Sterilizer: ' + response.message, 0);
}
function onSterilizerAddFailure(response) {
ShowResponse('Failure In Sterilizer: ' + response.message, 0);
}
/*****************************************************************************************************************/

