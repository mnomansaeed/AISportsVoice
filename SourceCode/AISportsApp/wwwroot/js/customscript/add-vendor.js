/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: Vendor
JSName: add-vendor.js
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
//vendorAdd Process
function vendorAdd() {
var url = getApiURL("api/Vendor/AddVendor");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Vendor Catch: ' + err.message, 0);
}
}
function onVendorAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Vendor Catch: ' + err.message, 0);
}
}
function onVendorAddError(response) {
ShowResponse('Error In Vendor: ' + response.message, 0);
}
function onVendorAddFailure(response) {
ShowResponse('Failure In Vendor: ' + response.message, 0);
}
/*****************************************************************************************************************/

