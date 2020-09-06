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
    resultItems.forEach(element => {
        if (element !== '')
            text += "Age:" + element + "<hr>";
    });
    return text;
}

function update() {
    doUpdate(localStorage.getItem("response"));
    // scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}