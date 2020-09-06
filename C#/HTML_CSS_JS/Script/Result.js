function update() {
    document.getElementById('results').innerText = localStorage.getItem("response");
    scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}

function doUpdate(response) {
    document.getElementById('results').innerText = response;
}