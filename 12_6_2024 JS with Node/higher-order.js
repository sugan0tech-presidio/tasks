function containsSubstring(str, substring) {
    return str.includes(substring); 
}

function filterStrings(strings, callbackFunc, substring) {
    let filteredArray = [];
    for (let value of strings) {
        if (callbackFunc(value, substring)) {
            filteredArray.push(value);
        }
    }
    return filteredArray;
}

let arrayOfStrings = ["apple", "banana", "cherry", "blueberry", "apoii"];
let substringToSearch = "ap";

console.log(filterStrings(arrayOfStrings, containsSubstring, substringToSearch));
