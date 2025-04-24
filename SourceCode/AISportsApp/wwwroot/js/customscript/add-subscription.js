/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 3:45:00 AM
TableName: Subscription
JSName: add-subscription.js
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
//subscriptionAdd Process
function subscriptionAdd() {
    var url = getApiURL("api/Subscription/AddSubscription");
    //  debugger;
    try {
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function onSubscriptionAddSuccess(data, status, jqXHR) {
    try {
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function onSubscriptionAddError(response) {
    ShowResponse('Error In Subscription: ' + response.message, 0);
}
function onSubscriptionAddFailure(response) {
    ShowResponse('Failure In Subscription: ' + response.message, 0);
}
/*****************************************************************************************************************/

