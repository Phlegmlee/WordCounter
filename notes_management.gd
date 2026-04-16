# Notes Management
extends Control

@onready var _note_text: TextEdit = %NoteText

var _notes_string : String = " Notes: "



func get_note_string() -> String:
	var note = _notes_string + _note_text.text.strip_edges()
	return note
