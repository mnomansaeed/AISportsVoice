//Global keys
var apiKey = getAPIKEY();
var apiTitle = getAPITitle();
var auth = getAuthorization();

$(document).ready(function () {
    
    UserGroupLoadSignup();

});
//Ajax Login click event
$('#btnLogin').on('click', function () {

    return redirect('' + getFrontURL('Authentication/login') + '');
})
function Validate() {

    if (!$('#txtFirstName').val()) {
        ShowResponse('Please input First Name to proceed.', 2);
        return false;
    }
    if (!$('#txtUserName').val()) {
        ShowResponse('Please input User Name to proceed.',2);
        return false;
    }
    if (!$('#txtLastName').val()) {
        ShowResponse('Please input Last Name to proceed.',2);
        return false;
    }
    if (!$('#txtEmail').val()) {
        ShowResponse('Please input Email to proceed.',2);
        return false;
    }
    if (!$('#txtPhone').val()) {
        ShowResponse('Please input Phone to proceed.',2);
        return false;
    }
    if (!$('#txtPassword').val()) {
        ShowResponse('Please input Password to proceed.', 2);
        return false;
    }
    if (!$('#txtRetypePassword').val()) {
        ShowResponse('Please retype Password to proceed.', 2);
        return false;
    }
    if ($('#txtPassword').val() != $('#txtRetypePassword').val()) {
        ShowResponse('Passwords does not match.', 2);
        return false;
    }
    return true;
}
$('#btnSignup').on('click', function () {
  
    if (Validate()) {
        signupUser();
    }
  
})
$(document).ajaxStart(function () {
    loaderShow();
    
});
$(document).ajaxStop(function () {
    loaderHide();
});
function UserGroupLoadSignup() {
   // debugger;
    var url = getApiURL("api/UserGroup/GetUserGroups");

    try {
        $.ajax({
            type: "GET",
            url: url,
            headers: {
                'API_Key': apiKey,
                'API_Title': apiTitle,
                'Authorization': 'Basic ' + auth,
                'Content-Type': 'application/json'
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onUserGroupLoadSuccess,
            error: onUserGroupLoadError,
            failure: onUserGroupLoadFailure
        });
    }
    catch (err) {
        
        ShowResponse('Error In User Group Load Catch: ' + err.message,2);
    }
}
function onUserGroupLoadSuccess(data, status, jqXHR) {

    var x = jQuery.parseJSON(JSON.stringify(data));
    
    try {

        var $el1 = $("#cmbUserGroup");
        $el1.empty(); // remove old options
        // binding controls with returned sequerity questions
        //$el1.append($("<option></option>")
        //    .attr("value", "-1").text("Select Specialty"));

        if (x.lstUserGroup.length > 0) {
   

            for (var i = 0; i < x.lstUserGroup.length; i++) {
                if (x.lstUserGroup[i].Name.toLowerCase() != 'admin')
                {
                    $el1.append($("<option></option>")
                        .attr("value", x.lstUserGroup[i].UserGroupId).text(x.lstUserGroup[i].Name));
                }
            }
        }
        else {
          
            ShowResponse('Error in User Group loading process!.',2);
        }
    }
    catch (err) {
        
        ShowResponse('Error In User Group Load: ' + err.message,2);
    }
}
function onUserGroupLoadError(response) {
        
    ShowResponse('Error In User Group Load: ' + response.message,2);
}

function onUserGroupLoadFailure(response) {
    
    ShowResponse('Failure In User Group Load: ' + response.message,2);
}



//Signup mechanism
function signupUser() {
   // debugger;
    var url = getApiURL("api/User/AddUser");
    $.ajax({
        type: "POST",
        url: url,

        headers: {
            'API_Key': apiKey,
            'API_Title': apiTitle,
            'Authorization': 'Basic ' + auth,
            'Content-Type': 'application/json'
        },
        //crossDomain: true,
        data: JSON.stringify({
            "UserId": 0,
            "UserGroupId": $("#cmbUserGroup option:selected").val(),
            "PracticeId": 0,
            "UserName": $('#txtUserName').val(),
            "Password": $('#txtPassword').val(),
            "Email": $('#txtEmail').val(),
            "TempPassword": "",
            "IsMaster": true,
            "SecurityQuestionId": 0,
            "SecurityAnswer": "",
            "SecurityQuestionId2": 0,
            "SecurityAnswer2": "",
            "OwnSecurityQuestion": "",
            "OwnSecurityAnswer": "",
            "Is_Active": 1,
            "Created_Date": "2021-09-30T14:31:18.015Z",
            "Created_By": 1,
            "Modified_Date": "2021-09-30T14:31:18.015Z",
            "Modified_By": 1,
            "Audit_Id": 0,
            "User_IP": "0.0.0.0",
            "Site_Id": 0,
            "FirstName": $('#txtFirstName').val(),
            "LastName": $('#txtLastName').val(),
            "Phone": $('#txtPhone').val()
         
        }),
        dataType: "json",
        success: onSignupSuccess,
        failure: onSignupFailure,
        error: onSignupError
    });

}

function onSignupSuccess(data, status, jqXHR) {
    //debugger;
    var x = jQuery.parseJSON(JSON.stringify(data));
    if (x == -1)
    { // duplicate username found
        ShowResponse("User already exist. Please try another user name.", 2);
    }
    else if (x == -2)
    { // duplicate email found
        ShowResponse("Email already exist. Please try another email.", 2);
    }
    else if (x == -3) {
        // duplicate phone found
        ShowResponse("Phone already exist. Please try another phone number.", 2);
    }
    else {

        //Send email to user with the following user successfully created.
        var con = "";
        if ($('#cmbUserGroup option:selected').text().toLowerCase() == 'patient') {
            con = "<!DOCTYPE html><html><head><link rel=stylesheet href=https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css /></head><body><div style=\"padding: 15px;\"><p>Dear UserName,</p><p>Thank you for choosing MawaEdi.com.You can now book your appointment with your doctor based on your needs.You will also be able to search your favorite doctors list and health tips free of charge.</p><p><br /></p><p>Thanks,<br />MawaEdi.com</p></div></body></html>";
        }
        else if ($('#cmbUserGroup option:selected').text().toLowerCase() == 'provider') {
            con = "<!DOCTYPE html><html><head><link rel=stylesheet href=https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css /></head><body><div style=\"padding: 15px;\"><p>Dear UserName,</p><p>Thank you for choosing MawaEdi.com.You can now manage your patient's appointment.You will also be able to manage your patient's data and health tips to your patients.</p><p><br /></p><p>Thanks,<br />MawaEdi.com</p></div></body></html>";
        }
        else if ($('#cmbUserGroup option:selected').text().toLowerCase() == 'receptionist') {
            con = "<!DOCTYPE html><html><head><link rel=stylesheet href=https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css /></head><body><div style=\"padding: 15px;\"><p>Dear UserName,</p><p>Thank you for choosing MawaEdi.com.You can now manage your doctor's appointment.You will also be able to manage your doctor's patients data and health tips for your doctor's patients.</p><p><br /></p><p>Thanks,<br />MawaEdi.com</p></div></body></html>";
        }
        else if ($('#cmbUserGroup option:selected').text().toLowerCase() == 'staff') {
            con = "<!DOCTYPE html><html><head><link rel=stylesheet href=https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css /><link rel=stylesheet href=https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css /></head><body><div style=\"padding: 15px;\"><p>Dear UserName,</p><p>Thank you for choosing MawaEdi.com.You can now manage and review a communication between patient and the receptionist.You will also be able to manage quality of MawaEdi.com service.</p><p><br /></p><p>Thanks,<br />MawaEdi.com</p></div></body></html>";
        }
        sendEmail($('#txtEmail').val(), $('#txtUserName').val(), $('#txtPassword').val(), $('#txtFirstName').val() + ' ' + $('#txtLastName').val(), con);
    }
    
      //  ShowResponse("Error in Signup process!.",0);
    
}

function onSignupError(response) {
 
        ShowResponse('Error In Signup: ' + response.message, 2);
    
}

function onSignupFailure(response) {

        ShowResponse('Failure In Signup: ' + response.message, 2);
    
}


//Send Email mechanism
function sendEmail(email, userName, password, name, emailContent) {
    var url = getFrontURL("Authentication/signup?handler=SendEmail");
    try {
        $.ajax({
            type: "POST",
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("RequestVerificationToken",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: JSON.stringify({
                Email: email,
                UserName: userName,
                Password: password,
                Name: name,
                EmailContent: emailContent
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onsendEmailSuccess,
            error: onsendEmailError,
            failure: onsendEmailFailure
        });
    }
    catch (err) {
      
        ShowResponse('Error In sendEmail Catch: ' + err.message,2);
    }
}

function onsendEmailSuccess(data, status, jqXHR) {
    var myResult = jQuery.parseJSON(JSON.stringify(data));
    loaderHide();
    if (myResult === '1') {
        ShowResponse('Please check your email for login information.',2);
        redirect('' + getFrontURL('Authentication/login'));
    }
    else {
        ShowResponse("Error in sendEmail process!.",2);
    }
}

function onsendEmailError(response) {
  
    ShowResponse('Error In sendEmail: ' + response.message,2);
}

function onsendEmailFailure(response) {
    
    ShowResponse('Failure In sendEmail: ' + response.message,2);
}