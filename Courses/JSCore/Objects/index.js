
class Person{
    constructor (firstName ="", lastName="", age="4", email="5"){
  
        this.firstName = firstName;
        this.lastName=lastName;
        this.age = age;
        this.email = email;
    }
    toString(){
        return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
    }
}

creatPeople = function () {
    return [
        new Person(this.firstName, this.lastName, this.age, this.email),
        new Person(this.firstName, this.lastName, this.age, this.email),
        new Person(this.firstName, this.lastName, this.age, this.email),
        new Person(this.firstName, this.lastName, this.age, this.email)
    ];
}


const people = creatPeople();
people.forEach((person) =>{
    console.log(person.toString())
})
