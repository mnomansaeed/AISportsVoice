//Global keys
var apiKey = getAPIKEY();
var apiTitle = getAPITitle();
var auth = getAuthorization();

//Ajax Login click event
$('#btnLogin').on('click', function () {

    return redirect('' + getFrontURL('Authentication/login') + '');
})
$('#btnRecover').on('click', function () {

    return redirect('' + getFrontURL('Authentication/recover-password') + '');
})
//Final reset password button click
$('#btnReset1').on('click', function () {
  
    if ($('#txtTempPassword').val() === '') {
        alert('Temporary password is required.');
        return false;
    }
    if ($('#txtPasswordNew').val() === '')
    {
        alert('Password is required.');
        return false;
    }

    if ($('#txtPasswordNew').val() === $('#txtConfirmPassword').val())
    {
  
        //Ajax call for password update against user id.
        forgotPasswordUpdate($('#txtTempPassword').val(), $('#txtPasswordNew').val())
    }
    else
    {
        alert('Password and confirm password does not match.');
        return false;
    }
    
})

function forgotPasswordUpdate(tempPassword,password) {
  
    var url = getApiURL("api/User/UpdateUserPasswordByTempPassword");

    try {
        $.ajax({
            type: "POST",
            url: url,
            headers: {
                'API_Key': apiKey,
                'API_Title': apiTitle,
                'Authorization': 'Basic ' + auth,
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({
                "UserId": 0,
                "UserGroupId": 0,
                "PracticeId": null,
                "UserName": "",
                "Password": password,
                "Email": "",
                "TempPassword": tempPassword,
                "IsMaster": null,
                "SecurityQuestionId": null,
                "SecurityAnswer": null,
                "SecurityQuestionId2": null,
                "SecurityAnswer2": null,
                "OwnSecurityQuestion": null,
                "OwnSecurityAnswer": null,
                "Is_Active": 0,
                "Created_Date": "",
                "Created_By": 0,
                "Modified_Date": "",
                "Modified_By": 0,
                "Audit_Id": null,
                "User_IP": null,
                "Site_Id": 0
                

            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onForgotPasswordUpdateSuccess,
            error: onForgotPasswordUpdateError,
            failure: onForgotPasswordUpdateFailure
        });
    }
    catch (err) {
        loaderHide();
        alert('Error In Forgot Password Update Catch: ' + err.message);
    }
}

function onForgotPasswordUpdateSuccess(data, status, jqXHR) {
  
    try {

        var x = jQuery.parseJSON(JSON.stringify(data));

        if (x > 0) {
            loaderHide();
            
            alert("Password updated successfully");
          //redirect to login page
            redirect('' + getFrontURL('index') + '');
            
          
           
        }
        else {
            loaderHide();
            alert('Error in Forgot Password Update process!.');
        }
    }
    catch (err) {
        loaderHide();
        alert('Error in Forgot Password Update process!: ' + err.message);
    }

}

function onForgotPasswordUpdateError(response) {
  
    loaderHide();
    alert('Error In Forgot Password Update: ' + response.message);
}

function onForgotPasswordUpdateFailure(response) {
  
    loaderHide();
    alert('Failure In Forgot Password Update: ' + response.message);
}


