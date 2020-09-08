function DoSearch(event) {
    if (event.key === "Enter") {
        let searchWrapper = document.getElementById("search-wrapper");
        const request = searchWrapper.value;
        const xHttp = new XMLHttpRequest();
        xHttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                localStorage.setItem("response", this.responseText);
                if (window.location.href.includes("Result.html")) {
                    update();
                } else {
                    window.location.replace("Result.html");
                }
            }
        };
        xHttp.open('POST', 'https://localhost:5001/Main/Get');
        xHttp.setRequestHeader('Content-Type', 'application/json');
        xHttp.send(JSON.stringify(request));
    }
}