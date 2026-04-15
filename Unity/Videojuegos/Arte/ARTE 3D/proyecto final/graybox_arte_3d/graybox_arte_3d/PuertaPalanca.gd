extends KinematicBody

var activa = false
var pos_init

# Called when the node enters the scene tree for the first time.
func _ready():
	pos_init = translation


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Palanca_body_entered(body):
	if body.get_name() == "Player":
		if activa:	
			translation.y = pos_init.y
			activa = false
		else:
			translation.y = pos_init.y  + 6
			activa = true
		get_node("../Palanca/Palanca_geo").rotation_degrees.x *= -1
