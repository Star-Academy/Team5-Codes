function update(Response) {
    document.getElementById('results').innerText = Response;
    scrollTo({ top: document.getElementById('results').offsetTop, behavior: 'smooth' });
}