/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: Condition
JSName: add-condition.js
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
//conditionAdd Process
function conditionAdd() {
var url = getApiURL("api/Condition/AddCondition");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Condition Catch: ' + err.message, 0);
}
}
function onConditionAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Condition Catch: ' + err.message, 0);
}
}
function onConditionAddError(response) {
ShowResponse('Error In Condition: ' + response.message, 0);
}
function onConditionAddFailure(response) {
ShowResponse('Failure In Condition: ' + response.message, 0);
}
/*****************************************************************************************************************/

