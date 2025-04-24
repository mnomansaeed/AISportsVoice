/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 3:45:00 AM
TableName: Subscription
JSName: edit-subscription.js
/*****************************************************************************************************************/
$(document).ready(function () {
    subscriptionLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//subscriptionLoad Process
function subscriptionLoad() {
    var url = getApiURL("api/Subscription/GetSubscriptionById");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function onSubscriptionLoadSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function onSubscriptionLoadError(response) {
    ShowResponse('Error In Subscription: ' + response.message, 0);
}
function onSubscriptionLoadFailure(response) {
    ShowResponse('Failure In Subscription: ' + response.message, 0);
}
//subscriptionUpdate Process
function subscriptionUpdate() {
    var url = getApiURL("api/Subscription/UpdateSubscription");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function onSubscriptionUpdateSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function onSubscriptionUpdateError(response) {
    ShowResponse('Error In Subscription: ' + response.message, 0);
}
function onSubscriptionUpdateFailure(response) {
    ShowResponse('Failure In Subscription: ' + response.message, 0);
}
/*****************************************************************************************************************/

