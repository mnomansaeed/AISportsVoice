/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: KitType
JSName: add-kittype.js
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
//kittypeAdd Process
function kittypeAdd() {
var url = getApiURL("api/KitType/AddKitType");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In KitType Catch: ' + err.message, 0);
}
}
function onKitTypeAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In KitType Catch: ' + err.message, 0);
}
}
function onKitTypeAddError(response) {
ShowResponse('Error In KitType: ' + response.message, 0);
}
function onKitTypeAddFailure(response) {
ShowResponse('Failure In KitType: ' + response.message, 0);
}
/*****************************************************************************************************************/

