extends Control

func _ready():
	pass # Replace with function body.

func _on_Comenzar_pressed():
	get_tree().change_scene("res://Nivel.tscn")

func _on_Salir_pressed():
	get_tree().quit()
