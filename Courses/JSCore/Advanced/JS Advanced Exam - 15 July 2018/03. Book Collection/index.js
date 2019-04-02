class BookCollection {
    constructor(shelfGenre, room, shelfCapacity){
        this.room = room;
        this.shelfCapacity = shelfCapacity;
        this.shelfGenre = shelfGenre;
        this.shelf = [];
    }
    get room(){
        return this._room;
    }
    set room(currentRoom){
        switch(currentRoom){
            case 'livingRoom':
            case 'bedRoom':
            case 'closet':
                this._room = currentRoom;
                break;
            default:
            let output = `Cannot have book shelf in ${currentRoom}`
                throw "Cannot have book shelf in "
        }
    }


    addBook(bookName, bookAuthor, genre) {
        if(this.shelfCondition === 0){
            this.shelf.shift();
        }
        let book = {bookName, bookAuthor, genre};
        this.shelf.push(book);
        this.shelf.sort((a,b)=>a['bookAuthor'].localeCompare(b['bookAuthor']))
        return this;
    }
    throwAwayBook(bookName){
        this.shelf = this.shelf.filter((b) => b.bookName !== bookName)
    } 
    showBooks(genre){
        let output = '';
        let wantedBooks = this.shelf.filter((b) => b.genre === genre)
        output += `Results for search "${genre}":\n`
        wantedBooks.forEach(book => {
            output += `\uD83D\uDCD6 ${book.bookAuthor} - "${book.bookName}"\n`
        });
        return output.trim()
    }
    get shelfCondition(){
        return Math.max(0, this.shelfCapacity - this.shelf.lenght)
    }
     toString() {
         let output = '';
         output +=`"${this.shelfGenre}" shelf in ${this.room} contains:\n`;
         this.shelf.forEach(book => {
            output += `\uD83D\uDCD6 "${book.bookName}" - ${book.bookAuthor}\n` 
        });
        
        if(output === `"${this.shelfGenre}" shelf in ${this.room} contains:\n`){
            output = "It's an empty shelf"
        }
         return output.trim();
         
     }
}

let livingRoom = new BookCollection('Programming', 'livingRoom', 5)
.addBook("Introduction to Programming with C#", "Svetlin Nakov")
console.log(livingRoom.toString());






