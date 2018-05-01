window.onload = function(){
    if(getCookie("Ember") !== ''){
        var logout = $("<button>");
        logout.attr("onclick", "tryLogout()");
        logout.text("Log Out");
        $("#nav").empty().append(logout);

        getAllPosts()
    }else{
        window.location = "index.html";
    }
};

function getAllPosts(){
    $.ajax({
        url: '//localhost:8080/all',
        type: 'GET',
        async: false,
        headers: {
            'hash': getCookie("Ember")
        },
        success: function (data) {
            displayPosts(data)
        },
        error: function(xhr, textStatus, errorThrown){
            switch(xhr.status) {
                default:
                    alert("an error was caught: "+xhr.status);
            }
        }
    });
}

function displayPosts(data){
    $("#allposts").empty();
    var jsonData = JSON.parse(data);

    for(var i=0; i<jsonData.length; i++){
        var newDiv = $("<div/>");
        var newHead = $("<p/>");
        var newBody = $("<p/>");
        var newFoot = $("<p/>");
        var comments = $("<p/>");
        newDiv.attr("id", "post"+jsonData[i].PostID);
        newDiv.attr("class", "post");
        newHead.text("User ID: "+jsonData[i].UserID+" // Post ID: "+jsonData[i].PostID);
        newHead.attr("class", "postheader");
        newBody.text(jsonData[i].PostMessage);
        newFoot.text("Pennies: "+jsonData[i].Points+"; Posted on: "+jsonData[i].Posted);
        newFoot.attr("class", "postheader");
        comments.attr("class", "postheader");
        comments.text("Comments:");

        for(var o=0; o<jsonData[i].Comments.length; o++){
            console.log(jsonData[i].Comments[o]);

            var newComment = $("<p/>");
            newComment.text("User ID: "+jsonData[i].Comments[o].UserID+": "+jsonData[i].Comments[o].PostMessage);
            newComment.attr("class", "postheader");

            comments.append(newComment);
        }

        newDiv.append(newHead).append(newBody).append(newFoot).append(comments);

        $("#allposts").append(newDiv);
    }
}

function submitPost(){
    var data = document.getElementById("newpostdata").value;

    var jsonData = JSON.stringify({
        'message': data
    });

    $.ajax({
        url: '//localhost:8080/newpost',
        type: 'POST',
        async: false,
        data: jsonData,
        headers: {
            'hash': getCookie("Ember")
        },
        success: function (data) {
            getAllPosts()
        },
        error: function(xhr, textStatus, errorThrown){
            switch(xhr.status) {
                default:
                    alert("an error was caught: "+xhr.status);
            }
        }
    });
}

function submitComment(){
    var data = document.getElementById("newcommentdata").value;
    var pid = document.getElementById("newcommentid").value;

    var jsonData = JSON.stringify({
        'message': data
    });

    $.ajax({
        url: '//localhost:8080/addcomment?pid='+pid,
        type: 'POST',
        async: false,
        data: jsonData,
        headers: {
            'hash': getCookie("Ember")
        },
        success: function (data) {
            getAllPosts()
        },
        error: function(xhr, textStatus, errorThrown){
            switch(xhr.status) {
                default:
                    alert("an error was caught: "+xhr.status);
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