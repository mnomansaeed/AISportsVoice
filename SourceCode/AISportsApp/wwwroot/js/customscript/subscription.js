/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Wednesday, November 13, 2024
Time: 3:45:00 AM
TableName: Subscription
JSName: subscription.js
/*****************************************************************************************************************/
$(document).ready(function () {
    subscriptionList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//subscription Process
function subscriptionList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        //if (userRole !== 'Super Admin Group') {
        //    //ShowResponse('Please specify URL for the non admin group call.', 0);
        //    //return;
        //    //alert(locationId);
        //    url = getApiURL("api/Subscription/GetSubscriptionsByLocationId/" + locationId);
        //}
        //else { // for Admin group
            url = getApiURL("api/Subscription/GetSubscriptions");
        //}
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#subscription-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#subscription-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstSubscription || [] : []; },
                /* success onSubscriptionSuccess,*/
                error: onSubscriptionError,
                failure: onSubscriptionFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addSubscription(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'SubscriptionId' },
                { data: 'PlanName' },
                { data: 'Status' },
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editSubscription(\'' + row.SubscriptionId + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removeSubscription(\'' + row.SubscriptionId + '\');">Delete</button>'
                    }
                }
            ],
            columnDefs: [
                {
                    "targets": [0],/*For hiding first column of the grid*/
                    "visible": false,
                    "searchable": false
                }
            ]
        })
        table.buttons().container()
            .appendTo($('#subscription-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In Subscription Catch: ' + err.message, 0);
    }
}
function addSubscription() {
    return redirect('' + getFrontURL('Setup/add-subscription') + '');
}
function editSubscription(Id) {
    return redirect('' + getFrontURL('Setup/edit-subscription?id=' + Id) + '');
}
function removeSubscription(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/subscription?handler=Delete');
        try {
            $.ajax({
                type: "POST",
                url: url,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("RequestVerificationToken",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: JSON.stringify({
                    Id: Id
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onRemove,
                error: onRemoveError,
                failure: onRemoveFailure
            });
        }
        catch (err) {
            ShowResponse('Error In Deletion Catch: ' + err.message, 0);
        }
    }
    else {
        // Cancel delete action
    }
}
function onRemove(response) {
    const data = jQuery.parseJSON(JSON.stringify(response));
    if (data.success) {
        //ShowResponse(data.message, 1);
        subscriptionList();
    }
    else {
        ShowResponse(data.message, 0);
    }
}
function onRemoveError(response) {
    const data = jQuery.parseJSON(JSON.stringify(response));
    ShowResponse('Error In Deletion: ' + data.message, 0);
}
function onRemoveFailure(response) {
    const data = jQuery.parseJSON(JSON.stringify(response));
    ShowResponse('Failure In Deletion: ' + data.message, 0);
}
function onSubscriptionError(response) {
    ShowResponse('Error In Subscription: ' + response.message, 0);
}
function onSubscriptionFailure(response) {
    ShowResponse('Failure In Subscription: ' + response.message, 0);
}
/*****************************************************************************************************************/

