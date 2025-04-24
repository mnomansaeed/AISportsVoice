/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: User
JSName: edit-user.js
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
    userLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//userLoad Process
function userLoad() {
    var url = getApiURL("api/User/GetUserById");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In User Catch: ' + err.message, 0);
    }
}
function onUserLoadSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In User Catch: ' + err.message, 0);
    }
}
function onUserLoadError(response) {
    ShowResponse('Error In User: ' + response.message, 0);
}
function onUserLoadFailure(response) {
    ShowResponse('Failure In User: ' + response.message, 0);
}
//userUpdate Process
function userUpdate() {
    var url = getApiURL("api/User/UpdateUser");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In User Catch: ' + err.message, 0);
    }
}
function onUserUpdateSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In User Catch: ' + err.message, 0);
    }
}
function onUserUpdateError(response) {
    ShowResponse('Error In User: ' + response.message, 0);
}
function onUserUpdateFailure(response) {
    ShowResponse('Failure In User: ' + response.message, 0);
}
/*****************************************************************************************************************/

