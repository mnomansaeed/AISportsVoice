/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 9:38:00 AM
TableName: Sterilizer
JSName: edit-sterilizer.js
/*****************************************************************************************************************/
$(document).ready(function () {
sterilizerLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//sterilizerLoad Process
function sterilizerLoad() {
var url = getApiURL("api/Sterilizer/GetSterilizerById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
}
}
function onSterilizerLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
}
}
function onSterilizerLoadError(response) {
ShowResponse('Error In Sterilizer: ' + response.message, 0);
}
function onSterilizerLoadFailure(response) {
ShowResponse('Failure In Sterilizer: ' + response.message, 0);
}
//sterilizerUpdate Process
function sterilizerUpdate() {
var url = getApiURL("api/Sterilizer/UpdateSterilizer");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
}
}
function onSterilizerUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
}
}
function onSterilizerUpdateError(response) {
ShowResponse('Error In Sterilizer: ' + response.message, 0);
}
function onSterilizerUpdateFailure(response) {
ShowResponse('Failure In Sterilizer: ' + response.message, 0);
}
/*****************************************************************************************************************/

