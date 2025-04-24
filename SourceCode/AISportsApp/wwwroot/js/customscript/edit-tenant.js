/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Tuesday, November 12, 2024
Time: 9:48:00 AM
TableName: Tenant
JSName: edit-tenant.js
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
    tenantLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//tenantLoad Process
function tenantLoad() {
    var url = getApiURL("api/Tenant/GetTenantById");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In Tenant Catch: ' + err.message, 0);
    }
}
function onTenantLoadSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In Tenant Catch: ' + err.message, 0);
    }
}
function onTenantLoadError(response) {
    ShowResponse('Error In Tenant: ' + response.message, 0);
}
function onTenantLoadFailure(response) {
    ShowResponse('Failure In Tenant: ' + response.message, 0);
}
//tenantUpdate Process
function tenantUpdate() {
    var url = getApiURL("api/Tenant/UpdateTenant");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In Tenant Catch: ' + err.message, 0);
    }
}
function onTenantUpdateSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In Tenant Catch: ' + err.message, 0);
    }
}
function onTenantUpdateError(response) {
    ShowResponse('Error In Tenant: ' + response.message, 0);
}
function onTenantUpdateFailure(response) {
    ShowResponse('Failure In Tenant: ' + response.message, 0);
}
/*****************************************************************************************************************/

