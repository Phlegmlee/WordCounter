extends Control


@export_category("Entries")
@export var word_count_entry : SpinBox
@export var date_entry: Label
@export var notes_entry : TextEdit

@export_category("Log")
@export var wc_log : TextEdit



var prev_word_count := 0
var word_count_string : String = "Word Count: "
var words_written_string : String = " Words Written: "
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
		_get_previous_word_count(log_contents)
	
	wc_file.close()



func _get_previous_word_count(log_cont) -> void:
	var split_lines = log_cont.split("\n")
	var last_line = split_lines[split_lines.size() - 2]
	var split_last = last_line.split(",")
	
	var regex = RegEx.new()
	regex.compile("\\d+")
	var word_count = regex.search_all(split_last[0])
	for number in word_count:
		var number_found = int(number.get_string())
		word_count_entry.value = number_found
		prev_word_count = number_found
		break



func _save_data() -> void:
	var wc_file = FileAccess.open("user://wc.txt", FileAccess.READ_WRITE)
	
	save_data = [_get_word_count_string(), _get_words_written_string(), date_entry.get_date_string(), _get_note_string()]
	
	wc_file.seek_end()
	wc_file.store_csv_line(save_data)
	wc_file.close()



func _get_word_count_string() -> String:
	var wc = word_count_string + str(int(word_count_entry.value))
	return wc







func _get_note_string() -> String:
	var note = notes_string + notes_entry.text.strip_edges()
	return note



func _get_words_written() -> int:
	var current_wc = word_count_entry.value
	var words_written = current_wc - prev_word_count
	#send_words_written.emit(words_written)
	return words_written



func _get_words_written_string() -> String:
	var ww = _get_words_written()
	var ww_string = words_written_string + str(ww)
	return ww_string


func _on_accept_pressed():
	_save_data()
	_load_data()
