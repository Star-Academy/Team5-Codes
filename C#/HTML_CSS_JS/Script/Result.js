function update(Response) {
    document.getElementById('results').innerText = Response;
    // document.getElementById('results').innerHTML = "<div>" + Response + "</div>";
    scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}