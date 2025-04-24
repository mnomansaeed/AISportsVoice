/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: CycleType
JSName: cycletype.js
/*****************************************************************************************************************/
$(document).ready(function () {
    cycletypeList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//cycletype Process
function cycletypeList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        if (userRole !== 'Super Admin Group') {
            //ShowResponse('Please specify URL for the non admin group call.', 0);
            //return;
            //alert(locationId);
            url = getApiURL("api/CycleType/GetCycleTypesByLocationId/" + locationId);
        }
        else { // for Admin group
            url = getApiURL("api/CycleType/GetCycleTypes");
        }
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#cycletype-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#cycletype-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstCycleType || [] : []; },
                /* success onCycleTypeSuccess,*/
                error: onCycleTypeError,
                failure: onCycleTypeFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addCycleType(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'CycleTypeId' },
                
                { data: 'CycleTypeName' },
                { data: 'Description' },
                { data: 'Notes' },
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editCycleType(\'' + row.CycleTypeId + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removeCycleType(\'' + row.CycleTypeId + '\');">Delete</button>'
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
            .appendTo($('#cycletype-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In CycleType Catch: ' + err.message, 0);
    }
}
function addCycleType() {
    return redirect('' + getFrontURL('Setup/add-cycletype') + '');
}
function editCycleType(Id) {
    return redirect('' + getFrontURL('Setup/edit-cycletype?id=' + Id) + '');
}
function removeCycleType(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/cycletype?handler=Delete');
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
        cycletypeList();
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
function onCycleTypeError(response) {
    ShowResponse('Error In CycleType: ' + response.message, 0);
}
function onCycleTypeFailure(response) {
    ShowResponse('Failure In CycleType: ' + response.message, 0);
}
/*****************************************************************************************************************/

