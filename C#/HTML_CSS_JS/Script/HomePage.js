
function DoSearch(event) {
    if (event.key === "Enter") {
        let searchWrapper = document.getElementById("search-wrapper");
        const input = searchWrapper.value;
        const request = input;
        const xHttp = new XMLHttpRequest();
        xHttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                update(this.responseText);
            }
        };
        xHttp.open('POST', 'https://localhost:5001/Main/Get');
        xHttp.setRequestHeader('Content-Type', 'application/json');
        xHttp.send(JSON.stringify(request));
    }
}

