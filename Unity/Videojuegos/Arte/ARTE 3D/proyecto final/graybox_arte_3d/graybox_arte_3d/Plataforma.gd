extends PathFollow

export (float) var duracion = 5
export (float) var espera = 0
export (float) var desface = 0
var activada = false

func _ready():
	if desface > 0:
		$Timer.wait_time = desface
		$Timer.start()
	else:
		activada = true

func _process(delta):
	if activada:
		if self.unit_offset == 0:
			movimiento(1)
		elif self.unit_offset == 1:
			movimiento(0)

func movimiento(target):
	$Tween.interpolate_property(self, "unit_offset", self.unit_offset, target, duracion, Tween.TRANS_SINE, Tween.EASE_IN_OUT, espera)
	$Tween.start()

func _on_Timer_timeout():
	activada = true
