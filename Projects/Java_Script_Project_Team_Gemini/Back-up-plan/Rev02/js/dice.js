var clicked = false;
var pawnOut = {red: 0,blue: 0,green: 0,yellow: 0}
function stuck() {
    var text = document.getElementById('player');
    if (onboard[currPawn] == 0 || currPos + num > 44) {
        if (dontHaveOtherFree() || currPos+num > 44) {
            var badtext = document.getElementById('badtext');
            // badtext.innerText = "Sorry";
            clicked = false;
            var dice = document.getElementById('dice');
            dice.style.backgroundImage = "url(images/dice.gif)";
            window.setTimeout(changePlayer, 1000);
        }
    }
}
function changePlayer() {
    if (num != 6){
    var text = document.getElementById('player');
        switch (text.innerText) {
            case "red": text.innerText = text.style.color = "blue"; break;
            case "blue": text.innerText = text.style.color = "yellow"; break;
            case "yellow": text.innerText = text.style.color = "green"; break;
            case "green": text.innerText = text.style.color = "red"; break;
        }
    }
    var badtext = document.getElementById('badtext');
    badtext.innerText = "";
    var dice = document.getElementById('dice');
    dice.style.backgroundImage = "url(images/dice.gif)";
}
var positions = {
    redpawn1: 0, redpawn2: 0, redpawn3: 0, redpawn4: 0,
    bluepawn1: 0, bluepawn2: 0, bluepawn3: 0, bluepawn4: 0,
    greenpawn1: 0, greenpawn2: 0, greenpawn3: 0, greenpawn4: 0,
    yellowpawn1: 0, yellowpawn2: 0, yellowpawn3: 0, yellowpawn4: 0
};
var onboard = {
    redpawn1: 0, redpawn2: 0, redpawn3: 0, redpawn4: 0,
    bluepawn1: 0, bluepawn2: 0, bluepawn3: 0, bluepawn4: 0,
    greenpawn1: 0, greenpawn2: 0, greenpawn3: 0, greenpawn4: 0,
    yellowpawn1: 0, yellowpawn2: 0, yellowpawn3: 0, yellowpawn4: 0
};
function dontHaveOtherFree() {
    var text = document.getElementById('player');
    for (var i = 1; i <= 4; i++) {
        if (onboard[text.innerText + "pawn" + i] == 1 || positions[text.innerText + "pawn" + i] + num >= 44) return false;
    }
    return true;
}
function randomNum() {
    if (!clicked) {
        num = Math.floor((Math.random() * 6) + 1);
        var dice = document.getElementById('dice');
        dice.style.backgroundImage = "url(images/" + num + ".jpg)";
        clicked = true;
    }
    if (num != 6 && dontHaveOtherFree()) {
        var bad = document.getElementById('badtext');
        // bad.innerText = "Sorry!";
        window.setTimeout(changePlayer, 1000);
        clicked = false;
    }
}






