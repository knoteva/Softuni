let expect = require('chai').expect;

class Calculator {
    constructor() {
        this.expenses = [];
    }

    add(data) {
        this.expenses.push(data);
    }

    divideNums() {
        let divide;
        for (let i = 0; i < this.expenses.length; i++) {
            if (typeof (this.expenses[i]) === 'number') {
                if (i === 0 || divide===undefined) {
                    divide = this.expenses[i];
                } else {
                    if (this.expenses[i] === 0) {
                        return 'Cannot divide by zero';
                    }
                    divide /= this.expenses[i];
                }
            }
        }
        if (divide !== undefined) {
            this.expenses = [divide];
            return divide;
        } else {
           throw new Error('There are no numbers in the array!')
        }
    }

    toString() {
        if (this.expenses.length > 0)
            return this.expenses.join(" -> ");
        else return 'empty array';
    }

    orderBy() {
        if (this.expenses.length > 0) {
            let isNumber = true;
            for (let data of this.expenses) {
                if (typeof data !== 'number')
                    isNumber = false;
            }
            if (isNumber) {
                return this.expenses.sort((a, b) => a - b).join(', ');
            }
            else {
                return this.expenses.sort().join(', ');
            }
        }
        else return 'empty';
    }
}


let output = new Calculator();
output.add(10);
output.add("Pesho");
output.add("5");
console.log(output.toString());
output.add(10);
console.log(output.divideNums());
output.add(1);
console.log(output.orderBy());
console.log(output.toString());



describe("Calculator functionallity", function() {
    let calculator;
    beforeEach(function () {
        calculator = new Calculator()
    });
    it("expences prp should be empty arr", function() {
        let result = calculator.expenses;
        expect(result).to.be.eql([]);
    });
    it("add function ", function() {
        calculator.add('Pesho');
        calculator.add(10);
        calculator.add(-1.5);
        let result = calculator.expenses
        expect(result).to.be.eql(['Pesho', 10,  -1.5]);
    });
    it("add function ", function() {
        calculator.add(10);
        calculator.add(-1.5);
        calculator.add('AAA');
        calculator.add([])
        let result = calculator.expenses
        expect(result).to.be.eql([10,  -1.5, 'AAA', []]);
    });
    it("no numbers in arr", function() {
        let result = () =>calculator.divideNums();
        expect(result).to.throw('There are no numbers in the array!');
    });
    // it("divede numbers in arr", function() {
    //     calculator.add(10)
    //     let result = calculator.divideNums();
    //     expect(result).to.eql(1);
    // });
    it("sort numbers", function() {
        calculator.add(-5)
        calculator.add(2.8)
        calculator.add(-5.5)
        calculator.add(10)
       let result =  calculator.orderBy();
        expect(result).to.eql('-5.5, -5, 2.8, 10');
    });
    it("Empty order by", function() {
       let result =  calculator.orderBy();
        expect(result).to.eql('empty');
    });

    it("Empty string", function() {
        let result =  calculator.toString();
         expect(result).to.eql('empty array');
     });
     it("string", function() {
         calculator.add(1)
         calculator.add(5)
         calculator.add('vbfdg')
         calculator.add({})
        let result =  calculator.toString();
         expect(result).to.eql('1 -> 5 -> vbfdg -> [object Object]');
     });
     it("sort numbers", function() {
        calculator.add(1)
        calculator.add(10)
        calculator.add({})
        calculator.add('gf')
        calculator.add('aa')
       let result =  calculator.orderBy();
        expect(result).to.eql('1, 10, [object Object], aa, gf');
    });
    it("divided", function() {
        calculator.add(-5.5)
        calculator.add(2)
        calculator.add('4523')
        let result = calculator.divideNums();
        expect(result).to.be.closeTo(-2.75, 0.01);
    });
    it("divided 0", function() {
        calculator.add(1)
        calculator.add(0)

        let result = calculator.divideNums();
        expect(result).to.be.eql('Cannot divide by zero');
    });
});
