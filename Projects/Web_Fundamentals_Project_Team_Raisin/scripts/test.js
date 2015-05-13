function students(){
	$("#student").hide(1000);
	$(".hypnotize-img").show(1000);
	setTimeout(function () {$(".hypnotize-h1").show(1000)}, 2000);
	setTimeout(function () {$(".hypnotize-h2").show(1000)}, 4000);
	setTimeout(function () {result();}, 8000);
};

function result(){
	var phrases = ["Ти си отличен кандидат. FunUni точно за теб. Тук е твоето място :) <a href='https://softuni.bg/apply'>Кандидатствай</a>", 
					"FunUni не е за теб :( Опитай с нещо друго....", 
					"<a href='https://softuni.bg/apply'>Кандидатствай</a> ... пък ще видим какво ще излезе :P"];
	$(".hypnotize-img").hide(1000);
	$(".hypnotize-h1").hide(1000);
	$(".hypnotize-h2").hide(1000);
	$("#result").html(phrases[Math.floor(Math.random()*phrases.length)]);
}