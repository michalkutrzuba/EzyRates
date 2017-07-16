"use strict";

class HttpClient {

    getJsonAsync(url) {

        return new Promise((resolve, reject) => {

            let xhttp = new XMLHttpRequest();
            xhttp.open('GET', url);
            xhttp.setRequestHeader("Content-type", "application/json");

            xhttp.onload = () => {
                if (xhttp.status === 200) {
                    let response = JSON.parse(xhttp.responseText);
                    resolve(response);
                }
                else {
                    reject(Error(xhttp.statusText));
                }
            };

            xhttp.onerror = function () {
                reject(Error("Network Error"));
            };

            xhttp.send();
        });
    }
}
