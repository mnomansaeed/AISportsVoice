/***************************************************Script **************************************************************
Author:   Code developed by Shinersoft Code Plumber 2024.
Date: Thursday, November 14, 2024
Time: 6:43:00 PM
TableName: Employee
JSName: edit-employee.js
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
employeeLoad();
});
////Ajax click event
$(document).ajaxStart(function () {
loaderShow();
});
$(document).ajaxStop(function () {
loaderHide();
});
//employeeLoad Process
function employeeLoad() {
var url = getApiURL("api/Employee/GetEmployeeById");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Employee Catch: ' + err.message, 0);
}
}
function onEmployeeLoadSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Employee Catch: ' + err.message, 0);
}
}
function onEmployeeLoadError(response) {
ShowResponse('Error In Employee: ' + response.message, 0);
}
function onEmployeeLoadFailure(response) {
ShowResponse('Failure In Employee: ' + response.message, 0);
}
//employeeUpdate Process
function employeeUpdate() {
var url = getApiURL("api/Employee/UpdateEmployee");
//  debugger;
try {
}
catch (err) {
ShowResponse('Error In Employee Catch: ' + err.message, 0);
}
}
function onEmployeeUpdateSuccess(data, status, jqXHR) {
try {
}
catch (err) {
ShowResponse('Error In Employee Catch: ' + err.message, 0);
}
}
function onEmployeeUpdateError(response) {
ShowResponse('Error In Employee: ' + response.message, 0);
}
function onEmployeeUpdateFailure(response) {
ShowResponse('Failure In Employee: ' + response.message, 0);
}
/*****************************************************************************************************************/

