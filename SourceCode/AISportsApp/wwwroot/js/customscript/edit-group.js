/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 4:37:00 PM
TableName: Group
JSName: edit-group.js
/*****************************************************************************************************************/
$(document).ready(function () {
groupLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//groupLoad Process
function groupLoad() {
var url = getApiURL("api/Group/GetGroupById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Group Catch: ' + err.message, 0);
}
}
function onGroupLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Group Catch: ' + err.message, 0);
}
}
function onGroupLoadError(response) {
ShowResponse('Error In Group: ' + response.message, 0);
}
function onGroupLoadFailure(response) {
ShowResponse('Failure In Group: ' + response.message, 0);
}
//groupUpdate Process
function groupUpdate() {
var url = getApiURL("api/Group/UpdateGroup");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Group Catch: ' + err.message, 0);
}
}
function onGroupUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Group Catch: ' + err.message, 0);
}
}
function onGroupUpdateError(response) {
ShowResponse('Error In Group: ' + response.message, 0);
}
function onGroupUpdateFailure(response) {
ShowResponse('Failure In Group: ' + response.message, 0);
}
/*****************************************************************************************************************/

