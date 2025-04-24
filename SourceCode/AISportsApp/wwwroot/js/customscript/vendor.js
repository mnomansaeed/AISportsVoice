/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 2:20:00 AM
TableName: Vendor
JSName: vendor.js
/*****************************************************************************************************************/
$(document).ready(function () {
    vendorList();
});
////Ajax click event
$(document).ajaxStart(function () {
    loaderShow();
});
$(document).ajaxStop(function () {
    loaderHide();
});
//vendor Process
function vendorList() {
    var url = '';
    if (typeof userRole !== 'undefined') {
        if (userRole !== 'Super Admin Group') {
            //ShowResponse('Please specify URL for the non admin group call.', 0);
            //return;
            //alert(locationId);
            url = getApiURL("api/Vendor/GetVendorsByLocationId/" + locationId);
        }
        else { // for Admin group
            url = getApiURL("api/Vendor/GetVendors");
        }
    }
    else {
        ShowResponse('No call exist for undefined role.', 0);
        return;
    }
    //  debugger;
    try {
        $('#vendor-table').DataTable().destroy();// destroy the datatable before re initialisation
        var table = $('#vendor-table').DataTable({
            dom: 'Bfrtip',
            ajax: {
                type: "GET",
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + auth(),
                    'Content-Type': 'application/json'
                },
                dataSrc: function (response) { return response ? response.lstVendor || [] : []; },
                /* success onVendorSuccess,*/
                error: onVendorError,
                failure: onVendorFailure
            },
            responsive: true, lengthMenu: [[7, 10, 25, 50, -1], [7, 10, 25, 50, "All"]], lengthChange: true, autoWidth: false, ordering: true, info: true,
            buttons: [{ text: 'Add New', action: function (e, dt, node, config) { addVendor(); } }, 'copy', { extend: 'csv', text: 'Csv', filename: 'data' }, { extend: 'excel', text: 'Excel', filename: 'data', extension: '.xlsx' }, { extend: 'pdf', text: 'Pdf', filename: 'data' }, 'print', 'colvis'],
            columns: [
                { data: 'VendorId' },
               
                { data: 'VendorCode' },
                { data: 'VendorName' },
                { data: 'VATRegistrationNo' },
                { data: 'PhoneNumber' },
                { data: 'Email' },
                
                {
                    title: "Edit", data: null, render: function (data, type, row) {
                        return '<button id="btnEdit" class="btn btn-primary" onclick="editVendor(\'' + row.VendorId + '\');">Edit</button>'
                    }
                },
                {
                    title: "Delete", data: null, render: function (data, type, row) {
                        return '<button id="btnDelete" class="btn btn-primary" onclick="removeVendor(\'' + row.VendorId + '\');">Delete</button>'
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
            .appendTo($('#vendor-table_wrapper .col-sm-6:eq(0)'));
    }
    catch (err) {
        ShowResponse('Error In Vendor Catch: ' + err.message, 0);
    }
}
function addVendor() {
    return redirect('' + getFrontURL('Setup/add-vendor') + '');
}
function editVendor(Id) {
    return redirect('' + getFrontURL('Setup/edit-vendor?id=' + Id) + '');
}
function removeVendor(Id) {
    //alert(Id);
    if (confirm("Do you want To delete?")) {
        const url = getFrontURL('Setup/vendor?handler=Delete');
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
        vendorList();
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
function onVendorError(response) {
    ShowResponse('Error In Vendor: ' + response.message, 0);
}
function onVendorFailure(response) {
    ShowResponse('Failure In Vendor: ' + response.message, 0);
}
/*****************************************************************************************************************/

