extends Control


@export_category("Entries")
@export var word_count_entry: Label
@export var date_entry: Label
@export var notes_entry : TextEdit


@export_category("Log")
@export var wc_log : TextEdit

var notes_string : String = " Notes: "
var save_data = PackedStringArray([])



func _ready() -> void:
	_file_check_create()
	_load_data()
	#print(OS.get_user_data_dir())



func _file_check_create() -> void:
	if !FileAccess.file_exists("user://wc.txt"):
		var wc_file = FileAccess.open("user://wc.txt", FileAccess.WRITE)
		wc_file.close()



func _load_data() -> void:
	var wc_file = FileAccess.open("user://wc.txt", FileAccess.READ)
	
	var log_contents = wc_file.get_as_text()
	if log_contents != "":
		wc_log.text = log_contents
		word_count_entry.get_previous_word_count(log_contents)
	
	wc_file.close()



func _save_data() -> void:
	var wc_file = FileAccess.open("user://wc.txt", FileAccess.READ_WRITE)
	
	save_data = [word_count_entry.get_word_count_string(), word_count_entry.get_words_written_string(), date_entry.get_date_string(), _get_note_string()]
	
	wc_file.seek_end()
	wc_file.store_csv_line(save_data)
	wc_file.close()



func _get_note_string() -> String:
	var note = notes_string + notes_entry.text.strip_edges()
	return note



func _on_accept_pressed():
	_save_data()
	_load_data()
