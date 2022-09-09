var canvas = document.getElementById("canvas")
var ctx = canvas.getContext("2d")

var lives = null
var okLeft = false
var okRight = false
var speed =null


var myCar = new Image()

myCar.X = 50
myCar.Y = 400

var enemyCar1 = new Image()

enemyCar1.X = 50
enemyCar1.Y = -150

var enemyCar2 = new Image()

enemyCar2.X = 250
enemyCar2.Y = -450


var line = new Image()

line.X = 180
line.Y = -140

var line2 = new Image()

line2.X = 180
line2.Y = 160


function getCookie(name) {
	let matches = document.cookie.match(new RegExp(
		"(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
	));
	return matches ? decodeURIComponent(matches[1]) : undefined;
}

let mapp = getCookie("Player_map").toString()
console.log(mapp)
let carr = getCookie("Player_car").toString()
var road = null
if (mapp == "forest") {
	road = "green"
	line.src = "../img/linefo.png";
	line2.src = "../img/linefo.png"
	enemyCar1.src = "../img/yama.png"
	enemyCar2.src = "../img/yama.png"
	speed = 1
}
else if (mapp == "Ukraine road"){
	road = "gray"
	line.src = "../img/line.png";
	line2.src = "../img/lineua.png"
	enemyCar1.src = "../img/yama.png"
	enemyCar2.src = "../img/yama.png"
	speed =  2
}
else if (mapp == "Europe road"){
	road = "gray"
	enemyCar1.src = "../img/Musstang.png"
	enemyCar2.src = "../img/car2e.png"
	line.src = "../img/line.png";
	line2.src = "../img/line.png"
	speed =  3
}
if (carr == "zaz") {
	myCar.src = "../img/ZazCar.png"
	lives = 4
	speed += 1
}
else if (carr == "vepr") {
	myCar.src = "../img/humvy.png"
	lives = 5
	speed += 0

}
else if (carr == "Lada 2106") {
	myCar.src = "../img/vaz.png"
	lives = 3
	speed += 2
}
else if (carr == "fiat") {
	myCar.src = "../img/fiat.png"
	lives = 2
	speed += 3
}
else if (carr == "lamborghini") {
	myCar.src = "../img/lambo.png"
	lives = 1
	speed += 4
}
function drawRect() {
	ctx.fillStyle = road
	ctx.fillRect(0, 0, 400, 500)
	console.log(1)
}


function drawLines() {
	ctx.drawImage(line, line.X, line.Y)
	line.Y += speed
	if (line.Y > 500) {
		line.Y = -140
	}

	ctx.drawImage(line2, line2.X, line2.Y)
	line2.Y += speed
	if (line2.Y > 500) {
		line2.Y = -140
	}
}

function drawLives() {
	ctx.font = "20px Arial"
	ctx.fillStyle = "White"
	ctx.fillText("Lives: " + lives, 235, 48)
}



function stop() {
	cancelAnimationFrame(myReq)
	ctx.font = "60px Arial"
	ctx.fillStyle = "Red"
	ctx.fillText("Game over", 40, 200)
	stop = true
}

function drawMyCar() {
	if (okLeft === true && myCar.X > 0) { myCar.X -= 5 }
	if (okRight === true && myCar.X < 335) { myCar.X += 5 }

	ctx.drawImage(myCar, myCar.X, myCar.Y)
}

function drawEnemyCar1() {

	if (enemyCar1.Y + 100 > myCar.Y && enemyCar1.X + 65 > myCar.X && enemyCar1.X < myCar.X + 65) {
		crash = true
		enemyCar1.Y = enemyCar2.Y - 300
		lives--
		if (lives < 1) {
			stop()
		}
	} else {
		crash = false
	}

	if (!crash) {
		ctx.drawImage(enemyCar1, enemyCar1.X, enemyCar1.Y)
		enemyCar1.Y += speed
		if (enemyCar1.Y > 500) {
			enemyCar1.Y = -100
			enemyCar1.X = Math.floor(Math.random() * 335)
		}
	}
}

function drawEnemyCar2() {

	if (enemyCar2.Y + 100 > myCar.Y && enemyCar2.X + 65 > myCar.X && enemyCar2.X < myCar.X + 65) {
		crash = true
		enemyCar2.Y = enemyCar1.Y - 300
		lives--
		if (lives < 1) {
			stop()
		}
	} else {
		crash = false
	}

	if (!crash) {
		ctx.drawImage(enemyCar2, enemyCar2.X, enemyCar2.Y)
		enemyCar2.Y += speed
		if (enemyCar2.Y > 500) {
			enemyCar2.Y = -100
			enemyCar2.X = Math.floor(Math.random() * 335)
		}
	}
}

function render() {
	if (stop === true) { return }

	drawRect()
	drawLines()
	drawLives()
	drawMyCar()
	drawEnemyCar1()
	drawEnemyCar2()

	myReq = requestAnimationFrame(render)
}
render()

addEventListener("keydown", function (event) {
	var newDirect = event.keyCode
	if (newDirect === 37) {
		okLeft = true
	}

	if (newDirect === 39) {
		okRight = true
	}
})

addEventListener("keyup", function (event) {
	var newDirect = event.keyCode
	if (newDirect === 37) {
		okLeft = false
	}

	if (newDirect === 39) {
		okRight = false
	}
})