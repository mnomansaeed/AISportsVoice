/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation_Type
JSName: physicallocation_type.js
/*****************************************************************************************************************/
$(document).ready(function () {
    physicallocation_typeList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//physicallocation_type Process
function physicallocation_typeList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        //if (userRole !== 'Super Admin Group') {
        //    //ShowResponse('Please specify URL for the non admin group call.', 0);
        //    //return;
        //    //alert(locationId);
        //    url = getApiURL("api/PhysicalLocation_Type/GetPhysicalLocation_TypesByLocationId/" + locationId);
        //}
        //else { // for Admin group
            url = getApiURL("api/PhysicalLocation_Type/GetPhysicalLocation_Types");
        //}
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#physicallocation_type-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#physicallocation_type-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstPhysicalLocation_Type || [] : []; },
                /* success onPhysicalLocation_TypeSuccess,*/
                error: onPhysicalLocation_TypeError,
                failure: onPhysicalLocation_TypeFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addPhysicalLocation_Type(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'PhysicalLocation_Type_Id' },
                { data: 'PhysicalLocationTypeName' },
                { data: 'Description' },
                
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editPhysicalLocation_Type(\'' + row.PhysicalLocation_Type_Id + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removePhysicalLocation_Type(\'' + row.PhysicalLocation_Type_Id + '\');">Delete</button>'
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
            .appendTo($('#physicallocation_type-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In PhysicalLocation_Type Catch: ' + err.message, 0);
    }
}
function addPhysicalLocation_Type() {
    return redirect('' + getFrontURL('Setup/add-physicallocation_type') + '');
}
function editPhysicalLocation_Type(Id) {
    return redirect('' + getFrontURL('Setup/edit-physicallocation_type?id=' + Id) + '');
}
function removePhysicalLocation_Type(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/physicallocation_type?handler=Delete');
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
        physicallocation_typeList();
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
function onPhysicalLocation_TypeError(response) {
    ShowResponse('Error In PhysicalLocation_Type: ' + response.message, 0);
}
function onPhysicalLocation_TypeFailure(response) {
    ShowResponse('Failure In PhysicalLocation_Type: ' + response.message, 0);
}
/*****************************************************************************************************************/

