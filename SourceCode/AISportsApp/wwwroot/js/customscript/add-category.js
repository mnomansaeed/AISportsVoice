/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 5:12:00 PM
TableName: Category
JSName: add-category.js
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
//categoryAdd Process
function categoryAdd() {
var url = getApiURL("api/Category/AddCategory");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Category Catch: ' + err.message, 0);
}
}
function onCategoryAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Category Catch: ' + err.message, 0);
}
}
function onCategoryAddError(response) {
ShowResponse('Error In Category: ' + response.message, 0);
}
function onCategoryAddFailure(response) {
ShowResponse('Failure In Category: ' + response.message, 0);
}
/*****************************************************************************************************************/

