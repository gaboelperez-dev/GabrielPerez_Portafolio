extends Control

func _ready():
	pass # Replace with function body.
	$Monedas.text = String(Global.monedasJuntadas) + " / " + String(Global.monedasTotales) + " monedas"



func _on_Menu_pressed():
	get_tree().change_scene("res://Menu.tscn")


func _on_Salir_pressed():
	get_tree().quit()
