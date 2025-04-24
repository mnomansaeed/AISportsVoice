/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: SubCategory
JSName: edit-subcategory.js
/*****************************************************************************************************************/
$(document).ready(function () {
    subcategoryLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//subcategoryLoad Process
function subcategoryLoad() {
    var url = getApiURL("api/SubCategory/GetSubCategoryById");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In SubCategory Catch: ' + err.message, 0);
    }
}
function onSubCategoryLoadSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In SubCategory Catch: ' + err.message, 0);
    }
}
function onSubCategoryLoadError(response) {
    ShowResponse('Error In SubCategory: ' + response.message, 0);
}
function onSubCategoryLoadFailure(response) {
    ShowResponse('Failure In SubCategory: ' + response.message, 0);
}
//subcategoryUpdate Process
function subcategoryUpdate() {
    var url = getApiURL("api/SubCategory/UpdateSubCategory");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In SubCategory Catch: ' + err.message, 0);
    }
}
function onSubCategoryUpdateSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In SubCategory Catch: ' + err.message, 0);
    }
}
function onSubCategoryUpdateError(response) {
    ShowResponse('Error In SubCategory: ' + response.message, 0);
}
function onSubCategoryUpdateFailure(response) {
    ShowResponse('Failure In SubCategory: ' + response.message, 0);
}
/*****************************************************************************************************************/

