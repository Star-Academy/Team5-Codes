function update(Response) {
    text = splitResponse(Response);

    var div = document.createElement('div');
    div.innerHTML = text;
    var parent = document.getElementById('results');
    parent.removeChild(parent.lastChild);
    parent.appendChild(div);
    scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}

function splitResponse(Response) {
    resultItems = Response.split("Age:");
    var text = '';
    resultItems.forEach(element => {
        if (element != '')
            text += "Age:" + element + "<hr>";
    });
    return text;
}