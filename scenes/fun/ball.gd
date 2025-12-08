extends RigidBody2D

@export var timer : Timer


func _ready():
	timer.start(randf_range(5.0, 10.0))

func _on_timer_timeout():
	self.queue_free()
