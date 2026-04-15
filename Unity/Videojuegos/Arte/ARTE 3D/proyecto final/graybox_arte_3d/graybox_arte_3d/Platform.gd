extends Path

export (float) var duracion = 5
export (float) var espera = 0
export (float) var desface = 0
var activada = false


# Called when the node enters the scene tree for the first time.
func _ready():
	if desface > 0:
		$Timer.wait_time = desface
		$Timer.start()
	else:
		activada = true


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if activada:
		if $PathFollow.unit_offset == 0:
			movimiento(1)
		elif $PathFollow.unit_offset == 1:
			movimiento(0)

func movimiento(target):
	$Tween.interpolate_property($PathFollow, "unit_offset", $PathFollow.unit_offset, target, duracion, Tween.TRANS_SINE, Tween.EASE_IN_OUT, espera)
	$Tween.start()


func _on_Timer_timeout():
	activada = true
