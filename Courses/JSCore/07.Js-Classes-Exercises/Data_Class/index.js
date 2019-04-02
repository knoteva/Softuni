class Request {
    constructor(method, uri, version, message, response=undefined, fulfilled=false) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = response;
        this.fulfilled = fulfilled;
    }
}

let myData = new Request('GET', 'http://google.com', 'HTTP/1.1', '')
console.log(myData)
// console.log("\n")
// console.log("\n")
// console.log(myData)
// console.log("\n")
// console.log("\n")
// console.log(myData)


