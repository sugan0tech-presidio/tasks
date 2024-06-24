function Person(name, age) {
    this.name = name;
    this.age = age;
}

Person.prototype.greet = function() {
    console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
};

const person1 = new Person('Alice', 30);
person1.greet();

console.log('--------------------------');

function Employee(name, age, jobTitle) {
    Person.call(this, name, age);
    this.jobTitle = jobTitle;
}

Employee.prototype = Object.create(Person.prototype);
Employee.prototype.constructor = Employee;

Employee.prototype.work = function() {
    console.log(`${this.name} is working as a ${this.jobTitle}.`);
};

const employee1 = new Employee('Bob', 25, 'Developer');
employee1.greet();
employee1.work();

console.log('--------------------------');

class Animal {
    constructor(name, species) {
        this.name = name;
        this.species = species;
    }

    describe() {
        console.log(`${this.name} is a ${this.species}.`);
    }
}

class Dog extends Animal {
    constructor(name, breed) {
        super(name, 'Dog');
        this.breed = breed;
    }

    bark() {
        console.log(`${this.name} barks! Woof woof!`);
    }
}

const dog1 = new Dog('Rex', 'Labrador');
dog1.describe();
dog1.bark();

console.log('--------------------------');

function createCar(model, year) {
    let speed = 0;

    return {
        model: model,
        year: year,
        accelerate: function() {
            speed += 10;
            console.log(`${this.model} is accelerating. Speed: ${speed} km/h.`);
        },
        brake: function() {
            speed -= 5;
            console.log(`${this.model} is braking. Speed: ${speed} km/h.`);
        },
        getSpeed: function() {
            return speed;
        }
    };
}

const car1 = createCar('Toyota', 2020);
car1.accelerate();
car1.brake();
console.log(`Current speed: ${car1.getSpeed()} km/h`);

console.log('--------------------------');

class Shape {
    constructor(name) {
        this.name = name;
    }

    draw() {
        console.log(`Drawing ${this.name}`);
    }
}

class Circle extends Shape {
    constructor(radius) {
        super('Circle');
        this.radius = radius;
    }

    draw() {
        console.log(`Drawing a circle with radius ${this.radius}`);
    }
}

class Square extends Shape {
    constructor(sideLength) {
        super('Square');
        this.sideLength = sideLength;
    }

    draw() {
        console.log(`Drawing a square with side length ${this.sideLength}`);
    }
}

const shapes = [new Circle(5), new Square(10)];
shapes.forEach(shape => shape.draw());

console.log('--------------------------');

const CanFly = {
    fly: function() {
        console.log(`${this.name} is flying.`);
    }
};

const CanSwim = {
    swim: function() {
        console.log(`${this.name} is swimming.`);
    }
};

function mixin(target, ...sources) {
    Object.assign(target, ...sources);
}

const bird = { name: 'Sparrow' };
mixin(bird, CanFly);
bird.fly();

const fish = { name: 'Goldfish' };
mixin(fish, CanSwim);
fish.swim();

const duck = { name: 'Duck' };
mixin(duck, CanFly, CanSwim);
duck.fly();
duck.swim();

console.log('--------------------------');

const animalProto = {
    eat: function() {
        console.log(`${this.name} is eating.`);
    }
};

const mammalProto = Object.create(animalProto);
mammalProto.giveBirth = function() {
    console.log(`${this.name} is giving birth.`);
};

const dogProto = Object.create(mammalProto);
dogProto.bark = function() {
    console.log(`${this.name} is barking.`);
};

const myDog = Object.create(dogProto);
myDog.name = 'Buddy';
myDog.eat();
myDog.giveBirth();
myDog.bark();

console.log('--------------------------');

class MathHelper {
    static PI = 3.14159;

    static calculateCircleArea(radius) {
        return this.PI * radius * radius;
    }
}

console.log(`PI value: ${MathHelper.PI}`);
console.log(`Area of circle: ${MathHelper.calculateCircleArea(5)}`);

console.log('--------------------------');

class BankAccount {
    #balance = 0;

    deposit(amount) {
        this.#balance += amount;
        console.log(`Deposited: ${amount}. Current balance: ${this.#balance}.`);
    }

    withdraw(amount) {
        if (amount <= this.#balance) {
            this.#balance -= amount;
            console.log(`Withdrew: ${amount}. Current balance: ${this.#balance}.`);
        } else {
            console.log('Insufficient funds.');
        }
    }

    getBalance() {
        return this.#balance;
    }
}

const myAccount = new BankAccount();
myAccount.deposit(100);
myAccount.withdraw(30);
console.log(`Final balance: ${myAccount.getBalance()}`);

console.log('--------------------------');

class Singleton {
    constructor() {
        if (Singleton.instance) {
            return Singleton.instance;
        }
        Singleton.instance = this;
    }

    logMessage(message) {
        console.log(message);
    }
}

const singleton1 = new Singleton();
const singleton2 = new Singleton();
singleton1.logMessage('Singleton pattern in action!');
console.log(singleton1 === singleton2);

console.log('--------------------------');

class Car {
    constructor(model, price) {
        this.model = model;
        this.price = price;
    }

    details() {
        console.log(`${this.model} costs $${this.price}`);
    }
}

class CarFactory {
    createCar(type) {
        switch (type) {
            case 'SUV':
                return new Car('SUV', 30000);
            case 'Sedan':
                return new Car('Sedan', 20000);
            case 'Coupe':
                return new Car('Coupe', 25000);
            default:
                return null;
        }
    }
}

const factory = new CarFactory();
const suv = factory.createCar('SUV');
const sedan = factory.createCar('Sedan');
suv.details();
sedan.details();

