/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 10:54:00 AM
TableName: PhysicalLocation
JSName: physicallocation.js
/*****************************************************************************************************************/
$(document).ready(function () {
    physicallocationList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//physicallocation Process
function physicallocationList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        //if (userRole !== 'Super Admin Group') {
        //    //ShowResponse('Please specify URL for the non admin group call.', 0);
        //    //return;
        //    //alert(locationId);
        //    url = getApiURL("api/PhysicalLocation/GetPhysicalLocationsByLocationId/" + locationId);
        //}
        //else { // for Admin group
            url = getApiURL("api/PhysicalLocation/GetPhysicalLocations");
        //}
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#physicallocation-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#physicallocation-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstPhysicalLocation || [] : []; },
                /* success onPhysicalLocationSuccess,*/
                error: onPhysicalLocationError,
                failure: onPhysicalLocationFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addPhysicalLocation(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'PhysicalLocation_ID' },
               
                { data: 'PhysicalLocationName' },
                { data: 'Short_Code' },
                { data: 'Long_Code' },
                { data: 'Short_Name' },
                { data: 'Description' },
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editPhysicalLocation(\'' + row.PhysicalLocation_ID + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removePhysicalLocation(\'' + row.PhysicalLocation_ID + '\');">Delete</button>'
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
            .appendTo($('#physicallocation-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In PhysicalLocation Catch: ' + err.message, 0);
    }
}
function addPhysicalLocation() {
    return redirect('' + getFrontURL('Setup/add-physicallocation') + '');
}
function editPhysicalLocation(Id) {
    return redirect('' + getFrontURL('Setup/edit-physicallocation?id=' + Id) + '');
}
function removePhysicalLocation(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/physicallocation?handler=Delete');
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
        physicallocationList();
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
function onPhysicalLocationError(response) {
    ShowResponse('Error In PhysicalLocation: ' + response.message, 0);
}
function onPhysicalLocationFailure(response) {
    ShowResponse('Failure In PhysicalLocation: ' + response.message, 0);
}
/*****************************************************************************************************************/

