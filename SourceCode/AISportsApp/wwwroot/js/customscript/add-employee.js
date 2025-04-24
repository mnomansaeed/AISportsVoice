/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 6:43:00 PM
TableName: Employee
JSName: add-employee.js
/*****************************************************************************************************************/
$(document).ready(function () {
$("#DateOfBirth").datepicker({
dateFormat: "mm/dd/yy", // Set desired format
changeMonth: true,
changeYear: true,
yearRange: "1990:2100"
});
$("#HireDate").datepicker({
dateFormat: "mm/dd/yy", // Set desired format
changeMonth: true,
changeYear: true,
yearRange: "1990:2100"
});
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//employeeAdd Process
function employeeAdd() {
var url = getApiURL("api/Employee/AddEmployee");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Employee Catch: ' + err.message, 0);
}
}
function onEmployeeAddSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Employee Catch: ' + err.message, 0);
}
}
function onEmployeeAddError(response) {
ShowResponse('Error In Employee: ' + response.message, 0);
}
function onEmployeeAddFailure(response) {
ShowResponse('Failure In Employee: ' + response.message, 0);
}
/*****************************************************************************************************************/

