/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: Vendor
JSName: edit-vendor.js
/*****************************************************************************************************************/
$(document).ready(function () {
vendorLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//vendorLoad Process
function vendorLoad() {
var url = getApiURL("api/Vendor/GetVendorById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Vendor Catch: ' + err.message, 0);
}
}
function onVendorLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Vendor Catch: ' + err.message, 0);
}
}
function onVendorLoadError(response) {
ShowResponse('Error In Vendor: ' + response.message, 0);
}
function onVendorLoadFailure(response) {
ShowResponse('Failure In Vendor: ' + response.message, 0);
}
//vendorUpdate Process
function vendorUpdate() {
var url = getApiURL("api/Vendor/UpdateVendor");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Vendor Catch: ' + err.message, 0);
}
}
function onVendorUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Vendor Catch: ' + err.message, 0);
}
}
function onVendorUpdateError(response) {
ShowResponse('Error In Vendor: ' + response.message, 0);
}
function onVendorUpdateFailure(response) {
ShowResponse('Failure In Vendor: ' + response.message, 0);
}
/*****************************************************************************************************************/

