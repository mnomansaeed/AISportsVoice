/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: SterilizerType
JSName: edit-sterilizertype.js
/*****************************************************************************************************************/
$(document).ready(function () {
    sterilizertypeLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//sterilizertypeLoad Process
function sterilizertypeLoad() {
    var url = getApiURL("api/SterilizerType/GetSterilizerTypeById");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In SterilizerType Catch: ' + err.message, 0);
    }
}
function onSterilizerTypeLoadSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In SterilizerType Catch: ' + err.message, 0);
    }
}
function onSterilizerTypeLoadError(response) {
    ShowResponse('Error In SterilizerType: ' + response.message, 0);
}
function onSterilizerTypeLoadFailure(response) {
    ShowResponse('Failure In SterilizerType: ' + response.message, 0);
}
//sterilizertypeUpdate Process
function sterilizertypeUpdate() {
    var url = getApiURL("api/SterilizerType/UpdateSterilizerType");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In SterilizerType Catch: ' + err.message, 0);
    }
}
function onSterilizerTypeUpdateSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In SterilizerType Catch: ' + err.message, 0);
    }
}
function onSterilizerTypeUpdateError(response) {
    ShowResponse('Error In SterilizerType: ' + response.message, 0);
}
function onSterilizerTypeUpdateFailure(response) {
    ShowResponse('Failure In SterilizerType: ' + response.message, 0);
}
/*****************************************************************************************************************/

