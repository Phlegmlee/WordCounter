# Log Management
extends Control

@onready var _text_log : TextEdit = %TextLog



func set_text_log(content : String) -> void:
	_text_log.text = content
