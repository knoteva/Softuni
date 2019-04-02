 function solve(input, sort){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = +price;
            this.status = status; 
        }
    }
    let tickets = [];
    for(let item of input) {
        let [destination, price, status] = item.split("|");
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }
    return tickets.sort((a, b) => a[sort] < b[sort]);
    
} 

console.log(solve([ 'Philadelphia|94.20|available',
                    'New York City|95.99|available',
                    'New York City|95.99|sold',
                    'Boston|126.20|departed'],
                    'destination'))