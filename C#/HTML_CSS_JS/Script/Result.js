function doUpdate(response) {
    text = splitResponse(response);

    var div = document.createElement('div');
    div.innerHTML = text;
    var parent = document.getElementById('results');
    parent.removeChild(parent.lastChild);
    parent.appendChild(div);
}

function splitResponse(Response) {
    resultItems = Response.split("Age:");
    var text = '';
    if (resultItems.length == 1) {
        text = "No result ):"
    } else {
        resultItems.forEach(element => {
            if (element != '')
                text += "<div class=\"result-item\">Age:" + element + "</div><hr>";
        });
    }
    return text;
}

function update() {
    doUpdate(localStorage.getItem("response"));
    // scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}

///// Code for hide the menu-bar /////
var prevScrollPos = window.pageYOffset;
window.onscroll = function() {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollPos > currentScrollPos) {
        document.getElementById("menu-bar").style.top = "0";
    } else {
        document.getElementById("menu-bar").style.top = "-50px";
    }
    prevScrollPos = currentScrollPos;
}