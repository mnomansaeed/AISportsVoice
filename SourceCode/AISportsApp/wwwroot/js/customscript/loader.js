function loaderShow() {
    // Font Awesome
    $.LoadingOverlay("show", {
        image: "",
       // fontawesome: "fa fa-cog fa-spin",
        fontawesomeAutoResize: true,
        fontawesomeColor:"#007BFF",
        fontawesome: "fas fa-stethoscope fa-spin",
        background: "rgba(54,76,99, 0.6)"
    });
} 
function loaderHide() {

    $.LoadingOverlay("hide");
}


/*  ShowResponse MsgType
//  MsgType == 0 : "Error",
//  MsgType == 1 : "Sucess",
//  MsgType == 2 : "Info",
//  MsgType == 3 : "Warning",
*/

function ShowResponse(data, MsgType) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-full-width",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    switch (MsgType) {
        case 0:
            toastr["error"](data, "Error")
            // toastr.error(data);
            break;
        case 1:
            toastr["success"](data, "Message")
           // toastr.success(data);
            break;
        case 2:
            toastr["warning"](data, "Warning")
          // toastr.warning(data);
            break;
        case 3:
            toastr["info"](data, "Information")
            //toastr.info(data);
            break;
        case 4:
            toastr["warning"](data, "Validation")
            // toastr.warning(data);
            break;
        default:
            toastr["success"](data, "Message")
           //toastr.success(data);
    }
}