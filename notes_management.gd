# Notes Management
extends Control

@onready var _note_text: TextEdit = %NoteText
@onready var _text_log : TextEdit = %TextLog

var _notes_string : String = " Notes: "


func set_text_log(content : String) -> void:
	_text_log.text = content


func get_note_string() -> String:
	var note = _notes_string + _note_text.text.strip_edges()
	return note
