function sortLetters(word, bool)  {

    var letter = word.split("").sort(function (x, y) {
        if (bool) {
            return x.toUpperCase() > y.toUpperCase();
        } else {
            return x.toUpperCase() < y.toUpperCase();
        }
    });

    console.log(letter.join(""));
}

sortLetters('HelloWorld', true);
sortLetters('HelloWorld', false); 