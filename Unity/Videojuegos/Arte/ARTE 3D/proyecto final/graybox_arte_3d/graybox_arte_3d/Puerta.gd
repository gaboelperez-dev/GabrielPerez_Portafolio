extends CSGBox

export(int) var monedas_necesarias = 10
#var monedas_necesarias = 10


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if Global.monedasJuntadas >= monedas_necesarias:
		queue_free()
