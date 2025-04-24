/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Tuesday, November 12, 2024
Time: 9:48:00 AM
TableName: Tenant
JSName: add-tenant.js
/*****************************************************************************************************************/
$(document).ready(function () {
    $("#SubscriptionStartDate").datepicker({
        dateFormat: "mm/dd/yy", // Set desired format
        changeMonth: true,
        changeYear: true,
        yearRange: "1990:2100"
    });
    $("#SubscriptionEndDate").datepicker({
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
//tenantAdd Process
function tenantAdd() {
    var url = getApiURL("api/Tenant/AddTenant");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In Tenant Catch: ' + err.message, 0);
    }
}
function onTenantAddSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In Tenant Catch: ' + err.message, 0);
    }
}
function onTenantAddError(response) {
    ShowResponse('Error In Tenant: ' + response.message, 0);
}
function onTenantAddFailure(response) {
    ShowResponse('Failure In Tenant: ' + response.message, 0);
}
/*****************************************************************************************************************/

