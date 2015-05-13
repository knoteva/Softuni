var currPos = 0;
var step = 61;
var currentPlayer = "";
var NumOfPaw = "";
var num = 0;
var clicked = false;
var currpawn = "";
var player = ["bug", "slime", "programmer", "fire"];
var pawnOut = {red:0,blue:0,green:0,yellow:0};

function HaveHover() {
    var count = 0;
    var toKill = "";
    for (var i = 0; i < player.length; i++) {
        for (var n = 1; n <= 4; n++) {
            var firstPawn = document.getElementById(player[i] + n);
            var secondPawn=document.getElementById(currpawn);
            if (firstPawn.style.top==secondPawn.style.top&&firstPawn.style.left==secondPawn.style.left&&currentPlayer!=player[i]&&currPos+num<44) {
                count++;
                toKill = player[i] + n;
                return toKill;
            }
        }
    }
    return false;
}

function Stuck() {
    var text = document.getElementById('player');
    if (onboard[currpawn] == 0||currPos+num > 59) {
        if (DontHaveOtherFree()||currPos+num>59) {
            var badtext = document.getElementById('badtext');
            badtext.innerText = "Unfortunatlly you stuck";
            clicked = false;
            var dice = document.getElementById('dice');
            dice.style.backgroundImage = "url(../resources/dice.gif)";
            window.setTimeout(changePlayer, 1000);
        }
    }
}

function changePlayer() {
    if (num != 6){
        var text = document.getElementById("player");
        switch (text.innerText) {
            case "bug": text.innerText = text.style.color = "slime"; break;
            case "slime": text.innerText = text.style.color = "programmer"; break;
            case "programmer": text.innerText = text.style.color = "fire"; break;
            case "fire": text.innerText = text.style.color = "bug"; break;
        }
    }
    var dice = document.getElementById('dice');
    dice.style.backgroundImage = "url(resources/dice.gif)";
}
var positions = {
    bug1: 0, bug2: 0, bug3: 0, bug4: 0,
    slime1: 0, slime2: 0, slime3: 0, slime4: 0,
    programmer1: 0, programmer2: 0, programmer3: 0, programmer4: 0,
    fire1: 0, fire2: 0, fire3: 0, fire4: 0
};
var onboard = {
    bug1: 0, bug2: 0, bug3: 0, bug4: 0,
    slime1: 0, slime2: 0, slime3: 0, slime4: 0,
    programmer1: 0, programmer2: 0, programmer3: 0, programmer4: 0,
    fire1: 0, fire2: 0, fire3: 0, fire4: 0
};

function DontHaveOtherFree() {
    var text = document.getElementById('player');
    for (var i = 1; i <=4; i++) {
        if (onboard[text.innerText + i] == 1 || positions[text.innerText + i]+num>=56) return false;
    }
    return true;
}

function CheckForWinner() {
    if (pawnOut[currentPlayer] == 4) {
        var dice = document.getElementById("dice");
        var player = document.getElementById("player");
        var uselesstext1 = document.getElementById("uselesstext1");
        var uselesstext2 = document.getElementById("uselesstext2");
        dice.innerText = "";
        dice.style.visibility = "hidden";
        uselesstext1.innerText = "";
        uselesstext2.innerText = "";
        player.innerText = "The Winner is the "+currentPlayer+" player";
    }
}

function moveDown() {
    var doc = document.getElementById(currentPlayer + NumOfPaw);
    var curr = Number(doc.style.top.replace(/[a-z]/g, ''));
    doc.style.top = (curr+step)+'px';
    currPos++;
}
function moveUp() {
    var doc = document.getElementById(currpawn);
    var curr = Number(doc.style.top.replace(/[a-z]/g, ''));
    doc.style.top = (curr - step) + 'px';
    currPos++;
}
function moveLeft() {
    var doc = document.getElementById(currpawn);
    var curr = Number(doc.style.left.replace(/[a-z]/g, ''));
    doc.style.left = (curr - step) + 'px';
    currPos++;
}
function moveRight() {
    var doc = document.getElementById(currpawn);
    var curr = Number(doc.style.left.replace(/[a-z]/g, ''));
    doc.style.left = (curr + step) + 'px';
    currPos++;
}
var moveBug = [];
var moveSlime = [];
var moveProgrammer =[];
var moveFire =[];

function pushSteps(value, steps, count) {
    for (var i = 0; i < count; i++) steps.push(value);
}

pushSteps(moveDown, moveBug, 5);
pushSteps(moveRight, moveBug, 1);
pushSteps(moveDown, moveBug , 1);
pushSteps(moveRight, moveBug, 5);
pushSteps(moveDown, moveBug, 2);
pushSteps(moveLeft, moveBug, 5);
pushSteps(moveDown, moveBug, 1);
pushSteps(moveLeft, moveBug, 1);
pushSteps(moveDown, moveBug, 5);
pushSteps(moveLeft, moveBug, 2);
pushSteps(moveUp, moveBug, 5);
pushSteps(moveLeft, moveBug,1);
pushSteps(moveUp, moveBug, 1);
pushSteps(moveLeft, moveBug, 5);
pushSteps(moveUp, moveBug, 2);
pushSteps(moveRight, moveBug, 5);
pushSteps(moveUp, moveBug, 1);
pushSteps(moveRight, moveBug, 1);
pushSteps(moveUp, moveBug, 5);
pushSteps(moveRight, moveBug, 1);
pushSteps(moveDown, moveBug, 4);

pushSteps(moveLeft, moveSlime, 5);
pushSteps(moveDown, moveSlime, 1);
pushSteps(moveLeft, moveSlime, 1);
pushSteps(moveDown, moveSlime, 5);
pushSteps(moveLeft, moveSlime, 2);
pushSteps(moveUp, moveSlime, 5);
pushSteps(moveLeft, moveSlime, 1);
pushSteps(moveUp, moveSlime, 1);
pushSteps(moveLeft, moveSlime, 5);
pushSteps(moveUp, moveSlime, 2);
pushSteps(moveRight, moveSlime, 5);
pushSteps(moveUp, moveSlime, 1);
pushSteps(moveRight, moveSlime, 1);
pushSteps(moveUp, moveSlime, 5);
pushSteps(moveRight, moveSlime, 2);
pushSteps(moveDown, moveSlime, 5);
pushSteps(moveRight, moveSlime, 1);
pushSteps(moveDown, moveSlime, 1);
pushSteps(moveRight, moveSlime, 5);
pushSteps(moveDown, moveSlime, 1);
pushSteps(moveLeft, moveSlime, 4);

pushSteps(moveUp,moveProgrammer, 5);
pushSteps(moveLeft,moveProgrammer, 1);
pushSteps(moveUp,moveProgrammer, 1);
pushSteps(moveLeft,moveProgrammer, 5);
pushSteps(moveUp,moveProgrammer, 2);
pushSteps(moveRight,moveProgrammer, 5);
pushSteps(moveUp,moveProgrammer, 1);
pushSteps(moveRight,moveProgrammer, 1);
pushSteps(moveUp,moveProgrammer, 5);
pushSteps(moveRight,moveProgrammer, 2);
pushSteps(moveDown,moveProgrammer, 5);
pushSteps(moveRight,moveProgrammer, 1);
pushSteps(moveDown,moveProgrammer, 1);
pushSteps(moveRight,moveProgrammer, 5);
pushSteps(moveDown,moveProgrammer, 2);
pushSteps(moveLeft,moveProgrammer, 5);
pushSteps(moveDown,moveProgrammer, 1);
pushSteps(moveLeft,moveProgrammer, 1);
pushSteps(moveDown,moveProgrammer, 5);
pushSteps(moveLeft,moveProgrammer, 2);
pushSteps(moveUp,moveProgrammer, 4);

pushSteps(moveRight, moveFire, 5);
pushSteps(moveUp, moveFire, 1);
pushSteps(moveRight, moveFire, 1);
pushSteps(moveUp, moveFire, 5);
pushSteps(moveRight, moveFire, 2);
pushSteps(moveDown, moveFire, 5);
pushSteps(moveRight, moveFire, 1);
pushSteps(moveDown, moveFire, 1);
pushSteps(moveRight, moveFire, 5);
pushSteps(moveDown, moveFire, 2);
pushSteps(moveLeft, moveFire, 5);
pushSteps(moveDown, moveFire, 1);
pushSteps(moveLeft, moveFire, 1);
pushSteps(moveDown, moveFire, 5);
pushSteps(moveLeft, moveFire, 2);
pushSteps(moveUp, moveFire, 5);
pushSteps(moveLeft, moveFire, 1);
pushSteps(moveUp, moveFire, 1);
pushSteps(moveLeft, moveFire, 5);
pushSteps(moveUp, moveFire, 1);
pushSteps(moveRight, moveFire, 4);

function ResetPawn(victim) {
    onboard[victim] = 0;
    positions[victim] = 0;
    var pawnToMove = document.getElementById(victim);
    switch (victim) {
        case "bug1": pawnToMove.style.top = 120 + "px"; pawnToMove.style.left = 1170 + "px"; break;
        case "bug2": pawnToMove.style.top = 120 + "px"; pawnToMove.style.left = 1240 + "px"; break;
        case "bug3": pawnToMove.style.top = 180 + "px"; pawnToMove.style.left = 1170 + "px"; break;
        case "bug4": pawnToMove.style.top = 180 + "px"; pawnToMove.style.left = 1240 + "px"; break;
        case "programmer1": pawnToMove.style.top = 705 + "px"; pawnToMove.style.left = 590 + "px"; break;
        case "programmer2": pawnToMove.style.top = 705 + "px"; pawnToMove.style.left = 660 + "px"; break;
        case "programmer3": pawnToMove.style.top = 775 + "px"; pawnToMove.style.left = 590 + "px"; break;
        case "programmer4": pawnToMove.style.top = 775 + "px"; pawnToMove.style.left = 660 + "px"; break;
        case "slime1": pawnToMove.style.top = 765 + "px"; pawnToMove.style.left = 1240 + "px"; break;
        case "slime2": pawnToMove.style.top = 705 + "px"; pawnToMove.style.left = 1240 + "px"; break;
        case "slime3": pawnToMove.style.top = 705 + "px"; pawnToMove.style.left = 1170 + "px"; break;
        case "slime4": pawnToMove.style.top = 765 + "px"; pawnToMove.style.left = 1170 + "px"; break;
        case "fire1": pawnToMove.style.top = 180 + "px"; pawnToMove.style.left = 590 + "px"; break;
        case "fire2": pawnToMove.style.top = 180 + "px"; pawnToMove.style.left = 660 + "px"; break;
        case "fire3": pawnToMove.style.top = 120 + "px"; pawnToMove.style.left = 660 + "px"; break;
        case "fire4": pawnToMove.style.top = 120 + "px"; pawnToMove.style.left = 590 + "px"; break;
    }
}
function diceRoll() {
    if (!clicked) {
        num = Math.floor((Math.random() * 6) + 1);
        var dice = document.getElementById('dice');
        dice.style.backgroundImage = "url(resources/" + num + ".jpg)";
        clicked = true;

    }
    if (num != 6 && DontHaveOtherFree()) {
        var bad = document.getElementById('badtext');
        bad.innerText = "Unfortunatlly you stuck";
        window.setTimeout(changePlayer, 1000);
        clicked = false;
    }

}


function randomMove(player, paw) {
    var text = document.getElementById('player');
    NumOfPaw = paw;
    currentPlayer = player;
    currpawn = currentPlayer + NumOfPaw;
    currPos = positions[currpawn];
    if (num + currPos > 56) {
        Stuck();
    }
    else {
        if (clicked) {
            var position = currPos;
            if (text.innerText == currentPlayer) {
                if (onboard[currpawn] === 1 || num === 6) {
                    if (onboard[currpawn] === 0) {
                        var doc = document.getElementById(currpawn);
                        var curr = Number(doc.style.left.replace(/[a-z]/g, ''));
                        switch (player) {
                            case "bug":
                                doc.style.left = 980 + 'px';
                                doc.style.top = 20 + "px";
                                break;

                            case "slime":
                                doc.style.left = 1350 + 'px';
                                doc.style.top = 523 + "px";
                                break;

                            case "programmer":
                                doc.style.left = 860 + 'px';
                                doc.style.top = 895 + "px";
                                break;

                            case "fire":
                                doc.style.left = 490 + 'px';
                                doc.style.top = 390 + "px";
                                break;
                        }
                        onboard[currpawn] = 1;
                    }
                    else {
                        switch (player) {
                            case "bug":
                                for (var i = currPos; i < position + num; i++) {
                                    moveBug[i]();
                                }
                                break;

                            case "slime":
                                for (var i = currPos; i < position + num; i++) {
                                    moveSlime[i]();
                                }
                                break;

                            case "programmer":
                                for (var i = currPos; i < position + num; i++) {
                                    moveProgrammer[i]();
                                }
                                break;

                            case "fire":
                                for (var i = currPos; i < position + num; i++) {
                                    moveFire[i]();
                                }
                                break;
                        }
                        positions[currpawn] = currPos;
                        var victim = HaveHover();
                        if (victim != false) {
                            ResetPawn(victim);
                        }
                        if (currPos == 56) { pawnOut[currentPlayer]++; onboard[currpawn] = 0; positions[currpawn] = 0; document.getElementById(currpawn).style.visibility = "hidden"; };
                        CheckForWinner();
                        changePlayer();
                    }
                    num = 0;
                    clicked = false;
                    var dice = document.getElementById('dice');
                    dice.style.backgroundImage = "url(resources/dice.gif)";
                }
                else Stuck();
            }
        }
    }
}
