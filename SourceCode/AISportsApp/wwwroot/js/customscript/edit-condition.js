/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: Condition
JSName: edit-condition.js
/*****************************************************************************************************************/
$(document).ready(function () {
conditionLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//conditionLoad Process
function conditionLoad() {
var url = getApiURL("api/Condition/GetConditionById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Condition Catch: ' + err.message, 0);
}
}
function onConditionLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Condition Catch: ' + err.message, 0);
}
}
function onConditionLoadError(response) {
ShowResponse('Error In Condition: ' + response.message, 0);
}
function onConditionLoadFailure(response) {
ShowResponse('Failure In Condition: ' + response.message, 0);
}
//conditionUpdate Process
function conditionUpdate() {
var url = getApiURL("api/Condition/UpdateCondition");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Condition Catch: ' + err.message, 0);
}
}
function onConditionUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Condition Catch: ' + err.message, 0);
}
}
function onConditionUpdateError(response) {
ShowResponse('Error In Condition: ' + response.message, 0);
}
function onConditionUpdateFailure(response) {
ShowResponse('Failure In Condition: ' + response.message, 0);
}
/*****************************************************************************************************************/

