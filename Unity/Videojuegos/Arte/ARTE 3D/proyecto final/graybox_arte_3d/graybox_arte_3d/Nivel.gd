extends Spatial

func _ready():
	pass # Replace with function body.

func _on_Area_Muerte_body_shape_entered(body_id, body, body_shape, area_shape):
	if body.get_name() == "Player":
		get_tree().change_scene("res://GameOver.tscn")

func _on_Area_Ganar_body_shape_entered(body_id, body, body_shape, area_shape):
	if body.get_name() == "Player":
		get_tree().change_scene("res://GameWin.tscn")


