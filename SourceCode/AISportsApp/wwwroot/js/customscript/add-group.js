/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 4:37:00 PM
TableName: Group
JSName: add-group.js
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
//groupAdd Process
function groupAdd() {
var url = getApiURL("api/Group/AddGroup");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Group Catch: ' + err.message, 0);
}
}
function onGroupAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Group Catch: ' + err.message, 0);
}
}
function onGroupAddError(response) {
ShowResponse('Error In Group: ' + response.message, 0);
}
function onGroupAddFailure(response) {
ShowResponse('Failure In Group: ' + response.message, 0);
}
/*****************************************************************************************************************/

