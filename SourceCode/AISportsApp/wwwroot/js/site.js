// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// AES decryption method using CryptoJS
function decryptMessage(encryptedText, key, iv) {
    // Convert key and IV to CryptoJS format (WordArray)
    var keyUtf8 = CryptoJS.enc.Utf8.parse(key);
    var ivUtf8 = CryptoJS.enc.Utf8.parse(iv);

    // Decrypt the message
    var decrypted = CryptoJS.AES.decrypt(encryptedText, keyUtf8, {
        iv: ivUtf8,
        padding: CryptoJS.pad.Pkcs7
    });

    // Convert decrypted data to UTF-8
    var decryptedText = decrypted.toString(CryptoJS.enc.Utf8);
    return decryptedText;
}

// AES encryption method using CryptoJS
function encryptMessage(plainText, key, iv) {
    // Convert key and IV to CryptoJS format (WordArray)
    var keyUtf8 = CryptoJS.enc.Utf8.parse(key);
    var ivUtf8 = CryptoJS.enc.Utf8.parse(iv);

    // Encrypt the message
    var encrypted = CryptoJS.AES.encrypt(plainText, keyUtf8, {
        iv: ivUtf8,
        padding: CryptoJS.pad.Pkcs7
    });

    // Return encrypted message as base64 string
    return encrypted.toString();
}
function auth() {
   // debugger;
    var tok = getCookie('egtdata');
   
    if (!tok) {
        console.error("No Valid token found!");
        // Redirect to the main page after saving the token
        window.location.href = getFrontURL("index");
    }

  //  var token = decryptMessage(tok.trim(), "ponmlkjihgfedcba", "6543210987654321")
  
    if (isTokenExpired(tok.trim())) {
        console.error("token expired!");
        window.location.href = getFrontURL("index");
    }

    return tok;
}
function isTokenExpired(token) {
    const payloadBase64 = token.split('.')[1];
    const decodedPayload = JSON.parse(atob(payloadBase64));
    const exp = decodedPayload.exp;
    const currentTime = Math.floor(Date.now() / 1000);
    return currentTime > exp;
}



function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}
function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0)
            return c.substring(nameEQ.length, c.length);
    }
    return null;
}
function eraseCookie(name) {
    document.cookie = name + '=; Max-Age=-99999999;';
}


function roundNumber(num, scale) {
    if (!("" + num).includes("e")) {
        return +(Math.round(num + "e+" + scale) + "e-" + scale);
    } else {
        var arr = ("" + num).split("e");
        var sig = ""
        if (+arr[1] + scale > 0) {
            sig = "+";
        }
        return +(Math.round(+arr[0] + "e" + sig + (+arr[1] + scale)) + "e-" + scale);
    }
}

// Write your Javascript code.
function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
};
function setSize() {
    var iframeElement = parent.document.getElementById('iframeSearch');
    var height = document.documentElement.clientHeight - 110;
    iframeElement.style.height = height + "px";
    var width = document.documentElement.clientWidth - 230;
    iframeElement.style.width = width + "px";
}


function getFrontURL(urlPart) {
    var retURL = 'http://localhost/AISportsApp/';
    // var retURL = 'http://localhost/AISportsApp/';
    retURL = retURL + urlPart;
    return retURL;
}
function getApiURL(urlPart) {
    var retURL = 'http://localhost/AISportsRESTServiceAPI/';
    // var retURL = 'http://localhost/AISportsRESTServiceAPI/';
    retURL = retURL + urlPart;
    return retURL;
}
function redirect(url) {
    var ua = navigator.userAgent.toLowerCase(),
        isIE = ua.indexOf('msie') !== -1,
        version = parseInt(ua.substr(4, 2), 10);

    // Internet Explorer 8 and lower
    if (isIE && version < 9) {
        var link = document.createElement('a');
        link.href = url;
        document.body.appendChild(link);
        link.click();
    }

    // All other browsers can use the standard window.location.href (they don't lose HTTP_REFERER like Internet Explorer 8 & lower does)
    else {
        window.location.href = url;
    }
}



function getFormattedDateEx(date) {
    var year = new Date(date).getFullYear();

    var month = (1 + new Date(date).getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = new Date(date).getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return month + '/' + day + '/' + year;
}

function getFormattedTimeEx(date) {
    var hours = new Date(date).getHours(); //returns 0-23
    var minutes = new Date(date).getMinutes(); //returns 0-59
    var seconds = new Date(date).getSeconds(); //


    return hours + ':' + minutes + ':' + seconds;
}

function getAgeFormDob(date) {

    var birthday = +new Date(date);
    return ~~((Date.now() - birthday) / (31557600000));

}







