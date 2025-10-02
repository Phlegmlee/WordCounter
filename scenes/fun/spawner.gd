extends Node2D



var ball = preload("res://scenes/fun/ball.tscn")
var ammount_to_spawn := 0


func _physics_process(_delta) -> void:
	if ammount_to_spawn > 0:
		if ammount_to_spawn > 500:
			ammount_to_spawn = 500
		for i in ammount_to_spawn:
			var ball_instance = ball.instantiate()
			add_child(ball_instance)
			ammount_to_spawn -= 1
	


func _on_application_manager_send_words_written(words_written):
	if words_written > 0:
		ammount_to_spawn = words_written
