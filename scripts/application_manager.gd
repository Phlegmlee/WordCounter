extends Control

# TODO: Show current document as a project name or something

@export_category("Entries")
@export var word_count_entry : Label
@export var date_entry : Label
@export var notes_entry : Label


@export var log_management : Control
@export var file_manager : FileManager

var save_data = PackedStringArray([])



func _ready() -> void:
	file_manager.file_changed.connect(_populate_content)
	_populate_content()
	#print(OS.get_user_data_dir())



func _populate_content() -> void:
	var wc_file = file_manager.load_data()
	
	var log_contents = wc_file.get_as_text()
	log_management.set_text_log(log_contents)
	word_count_entry.get_previous_word_count(log_contents)
	
	wc_file.close()



func _on_accept_pressed():
	save_data = [word_count_entry.get_word_count_string(), word_count_entry.get_words_written_string(), date_entry.get_date_string(), notes_entry.get_note_string()]
	file_manager.save_data(save_data)
	_populate_content()
