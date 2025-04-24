/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: SterilizerType
JSName: add-sterilizertype.js
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
//sterilizertypeAdd Process
function sterilizertypeAdd() {
    var url = getApiURL("api/SterilizerType/AddSterilizerType");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In SterilizerType Catch: ' + err.message, 0);
    }
}
function onSterilizerTypeAddSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In SterilizerType Catch: ' + err.message, 0);
    }
}
function onSterilizerTypeAddError(response) {
    ShowResponse('Error In SterilizerType: ' + response.message, 0);
}
function onSterilizerTypeAddFailure(response) {
    ShowResponse('Failure In SterilizerType: ' + response.message, 0);
}
/*****************************************************************************************************************/

