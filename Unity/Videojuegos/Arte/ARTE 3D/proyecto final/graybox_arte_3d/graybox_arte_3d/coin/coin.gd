extends Area

var taken = false

func _ready():
	Global.monedasTotales += 1

func _on_coin_body_enter(body):
	if not taken and body is preload("res://player/player.gd"):
		get_node("Animation").play("take")
		Global.monedasJuntadas += 1
		taken = true
