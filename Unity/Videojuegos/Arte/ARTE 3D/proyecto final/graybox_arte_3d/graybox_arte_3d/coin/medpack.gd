extends Area

var taken = false

func _ready():
	pass

func _on_medpack_body_entered(body):
	if not taken and body is preload("res://player/player.gd"):
		if Global.vida < 100:
			if Global.vida <= 90:
				Global.vida += 10
			else:
				Global.vida += (100 - Global.vida)
			get_node("Animation").play("take")
			taken = true
			
		
