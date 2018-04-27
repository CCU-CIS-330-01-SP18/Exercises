window.onload = function(){
    if(getCookie("Ember") !== ''){
        var logout = $("<button>");
        logout.attr("onclick", "tryLogout()");
        logout.text("Log Out");
        $("#nav").empty().append(logout);
    }
};

function tryLogin(){
    var email = document.getElementById("login_email").value;
    var pass = document.getElementById("login_password").value;

    var jsonData = JSON.stringify({
        'test': 'this is not a test'
    });

    $.ajax({
        url: '//localhost:8080/login',
        type: 'POST',
        async: false,
        data: jsonData,
        headers: {
            'email': email,
            'password': pass
        },
        success: function (data) {
            setCookie(data);
            window.location = "home.html";
        },
        error: function(xhr, textStatus, errorThrown){
            switch(xhr.status) {
                case 400:
                    $("#loginerr").text("Bad request!").removeAttr("hidden");
                    break;
                case 401:
                    $("#loginerr").text("Invalid credentials!").removeAttr("hidden");
                    break;
                default:
                    $("#loginerr").text("There was an error logging in!").removeAttr("hidden");
            }
        }
    });
}

function tryLogout(){
    deleteCookie();
    location.reload();
}

function deleteCookie(){
    document.cookie = "Ember=none; path=/; expires=Thu, 01 Jan 1970 00:00:01 GMT";
}

function setCookie(value){
    document.cookie = "Ember="+value+"; path=/";
}

// Borrowed from w3schools
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}