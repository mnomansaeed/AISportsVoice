/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: User
JSName: add-user.js
/*****************************************************************************************************************/
$(document).ready(function () {
    $("#DateRangeFrom").datepicker({
        dateFormat: "mm/dd/yy", // Set desired format
        changeMonth: true,
        changeYear: true,
        yearRange: "1990:2100"
    });
    $("#DateRangeTo").datepicker({
        dateFormat: "mm/dd/yy", // Set desired format
        changeMonth: true,
        changeYear: true,
        yearRange: "1990:2100"
    });
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//userAdd Process
function userAdd() {
    var url = getApiURL("api/User/AddUser");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In User Catch: ' + err.message, 0);
    }
}
function onUserAddSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In User Catch: ' + err.message, 0);
    }
}
function onUserAddError(response) {
    ShowResponse('Error In User: ' + response.message, 0);
}
function onUserAddFailure(response) {
    ShowResponse('Failure In User: ' + response.message, 0);
}
/*****************************************************************************************************************/

