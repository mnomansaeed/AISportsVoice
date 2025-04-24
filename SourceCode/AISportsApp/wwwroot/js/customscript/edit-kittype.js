/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: KitType
JSName: edit-kittype.js
/*****************************************************************************************************************/
$(document).ready(function () {
    kittypeLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//kittypeLoad Process
function kittypeLoad() {
    var url = getApiURL("api/KitType/GetKitTypeById");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In KitType Catch: ' + err.message, 0);
    }
}
function onKitTypeLoadSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In KitType Catch: ' + err.message, 0);
    }
}
function onKitTypeLoadError(response) {
    ShowResponse('Error In KitType: ' + response.message, 0);
}
function onKitTypeLoadFailure(response) {
    ShowResponse('Failure In KitType: ' + response.message, 0);
}
//kittypeUpdate Process
function kittypeUpdate() {
    var url = getApiURL("api/KitType/UpdateKitType");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In KitType Catch: ' + err.message, 0);
    }
}
function onKitTypeUpdateSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In KitType Catch: ' + err.message, 0);
    }
}
function onKitTypeUpdateError(response) {
    ShowResponse('Error In KitType: ' + response.message, 0);
}
function onKitTypeUpdateFailure(response) {
    ShowResponse('Failure In KitType: ' + response.message, 0);
}
/*****************************************************************************************************************/

