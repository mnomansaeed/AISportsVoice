/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: SubCategory
JSName: add-subcategory.js
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
//subcategoryAdd Process
function subcategoryAdd() {
    var url = getApiURL("api/SubCategory/AddSubCategory");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In SubCategory Catch: ' + err.message, 0);
    }
}
function onSubCategoryAddSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In SubCategory Catch: ' + err.message, 0);
    }
}
function onSubCategoryAddError(response) {
    ShowResponse('Error In SubCategory: ' + response.message, 0);
}
function onSubCategoryAddFailure(response) {
    ShowResponse('Failure In SubCategory: ' + response.message, 0);
}
/*****************************************************************************************************************/

