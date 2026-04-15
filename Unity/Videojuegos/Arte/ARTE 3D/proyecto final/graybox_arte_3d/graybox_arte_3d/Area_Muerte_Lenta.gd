extends Area

var dentro = false
var activada = true
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func _process(delta):
	if dentro and activada:
		if $Timer.is_stopped():
			$Timer.start()
			Global.vida -= 2

func _on_Area_Muerte_Lenta_body_shape_entered(body_id, body, body_shape, area_shape):
	if body.get_name() == "Player":
		dentro = true

func _on_Area_Muerte_Lenta_body_shape_exited(body_id, body, body_shape, area_shape):
	if body.get_name() == "Player":
		dentro = false
