var Response;

function setResponse(response) {
    Response = response;
}

function update() {
    document.getElementById('results').innerText = Response;
    scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}