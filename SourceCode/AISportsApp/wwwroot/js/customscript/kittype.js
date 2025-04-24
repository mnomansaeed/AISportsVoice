/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: KitType
JSName: kittype.js
/*****************************************************************************************************************/
$(document).ready(function () {
    kittypeList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//kittype Process
function kittypeList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        if (userRole !== 'Super Admin Group') {
            //ShowResponse('Please specify URL for the non admin group call.', 0);
            //return;
            //alert(locationId);
            url = getApiURL("api/KitType/GetKitTypesByLocationId/" + locationId);
        }
        else { // for Admin group
            url = getApiURL("api/KitType/GetKitTypes");
        }
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#kittype-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#kittype-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstKitType || [] : []; },
                /* success onKitTypeSuccess,*/
                error: onKitTypeError,
                failure: onKitTypeFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addKitType(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'KitTypeId' },
               
                { data: 'KitTypeName' },
                { data: 'Description' },
                { data: 'Notes' },
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editKitType(\'' + row.KitTypeId + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removeKitType(\'' + row.KitTypeId + '\');">Delete</button>'
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
            .appendTo($('#kittype-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In KitType Catch: ' + err.message, 0);
    }
}
function addKitType() {
    return redirect('' + getFrontURL('Setup/add-kittype') + '');
}
function editKitType(Id) {
    return redirect('' + getFrontURL('Setup/edit-kittype?id=' + Id) + '');
}
function removeKitType(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/kittype?handler=Delete');
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
        kittypeList();
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
function onKitTypeError(response) {
    ShowResponse('Error In KitType: ' + response.message, 0);
}
function onKitTypeFailure(response) {
    ShowResponse('Failure In KitType: ' + response.message, 0);
}
/*****************************************************************************************************************/

