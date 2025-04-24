/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Category
JSName: edit-category.js
/*****************************************************************************************************************/
$(document).ready(function () {
categoryLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//categoryLoad Process
function categoryLoad() {
var url = getApiURL("api/Category/GetCategoryById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Category Catch: ' + err.message, 0);
}
}
function onCategoryLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Category Catch: ' + err.message, 0);
}
}
function onCategoryLoadError(response) {
ShowResponse('Error In Category: ' + response.message, 0);
}
function onCategoryLoadFailure(response) {
ShowResponse('Failure In Category: ' + response.message, 0);
}
//categoryUpdate Process
function categoryUpdate() {
var url = getApiURL("api/Category/UpdateCategory");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Category Catch: ' + err.message, 0);
}
}
function onCategoryUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Category Catch: ' + err.message, 0);
}
}
function onCategoryUpdateError(response) {
ShowResponse('Error In Category: ' + response.message, 0);
}
function onCategoryUpdateFailure(response) {
ShowResponse('Failure In Category: ' + response.message, 0);
}
/*****************************************************************************************************************/

