/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 9:38:00 AM
TableName: Sterilizer
JSName: sterilizer.js
/*****************************************************************************************************************/
$(document).ready(function () {
    sterilizerList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//sterilizer Process
function sterilizerList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        if (userRole !== 'Super Admin Group') {
            //ShowResponse('Please specify URL for the non admin group call.', 0);
            //return;
            //alert(locationId);
            url = getApiURL("api/Sterilizer/GetSterilizersByLocationId/" + locationId);
        }
        else { // for Admin group
            url = getApiURL("api/Sterilizer/GetSterilizers");
        }
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#sterilizer-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#sterilizer-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstSterilizer || [] : []; },
                /* success onSterilizerSuccess,*/
                error: onSterilizerError,
                failure: onSterilizerFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addSterilizer(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'SterilizerId' },
                
                { data: 'SterilizerName' },
                { data: 'Description' },
                { data: 'Notes' },
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editSterilizer(\'' + row.SterilizerId + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removeSterilizer(\'' + row.SterilizerId + '\');">Delete</button>'
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
            .appendTo($('#sterilizer-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In Sterilizer Catch: ' + err.message, 0);
    }
}
function addSterilizer() {
    return redirect('' + getFrontURL('Setup/add-sterilizer') + '');
}
function editSterilizer(Id) {
    return redirect('' + getFrontURL('Setup/edit-sterilizer?id=' + Id) + '');
}
function removeSterilizer(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/sterilizer?handler=Delete');
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
        sterilizerList();
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
function onSterilizerError(response) {
    ShowResponse('Error In Sterilizer: ' + response.message, 0);
}
function onSterilizerFailure(response) {
    ShowResponse('Failure In Sterilizer: ' + response.message, 0);
}
/*****************************************************************************************************************/

