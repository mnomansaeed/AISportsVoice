//Global keys
var apiKey = getAPIKEY();
var apiTitle = getAPITitle();
var auth = getAuthorization();

//Ajax Login click event
$('#btnLogin').on('click', function () {

    return redirect('' + getFrontURL('Authentication/login') + '');
})
$('#btnGotoLogin').on('click', function () {

    return redirect('' + getFrontURL('Authentication/login') + '');
})
