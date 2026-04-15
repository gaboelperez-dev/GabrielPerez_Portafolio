extends Area

var dentro = false
var dano = 2

func _on_dano_gradual_body_shape_entered(body_id, body, body_shape, area_shape):
	if body.get_name() == "Player":
		Global.vida -= dano
		dentro = true

func _on_dano_gradual_body_shape_exited(body_id, body, body_shape, area_shape):
	if body.get_name() == "Player":
		dentro = false

func _on_Timer_timeout():
	if dentro:
		Global.vida -= dano
