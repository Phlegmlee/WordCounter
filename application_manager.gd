extends Control

#signal send_words_written(words_written)

@export_category("GUI")
@export var root : Control
@export var darkmode_toggle : CheckButton

@export_category("Entries")
@export var word_count_entry : SpinBox
@export var month_entry : OptionButton
@export var day_entry : OptionButton
@export var year_entry : OptionButton
@export var notes_entry : TextEdit

@export_category("Log")
@export var wc_log : TextEdit

var light_theme = preload("res://themes/light-mode-theme.tres")
var dark_theme = preload("res://themes/dark_mode_theme.tres")

var date : Dictionary = {}

var days_per_month : Dictionary = {
	"1" : 31,
	"2" : 29,
	"3" : 31,
	"4" : 30,
	"5" : 31,
	"6" : 30,
	"7" : 31,
	"8" : 31,
	"9" : 30,
	"10" : 31,
	"11" : 30,
	"12" : 31,
}

var prev_word_count := 0
var word_count_string : String = "Word Count: "
var words_written_string : String = " Words Written: "
var date_string : String = " Date: "
var notes_string : String = " Notes: "
var save_data = PackedStringArray([word_count_string, words_written_string, date_string, notes_string])



func _ready() -> void:
	_theme_check()
	_file_check_create()
	_load_data()



func _theme_check() -> void:
	if DisplayServer.is_dark_mode_supported():
		if DisplayServer.is_dark_mode():
			root.theme = dark_theme
			darkmode_toggle.button_pressed = true
		else:
			root.theme = light_theme
			darkmode_toggle.button_pressed = false



func _file_check_create() -> void:
	if !FileAccess.file_exists("wc.txt"):
		var wc_file = FileAccess.open("wc.txt", FileAccess.WRITE)
		wc_file.close()



func _load_data() -> void:
	_populate_date()
	
	var wc_file = FileAccess.open("wc.txt", FileAccess.READ)
	
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
	var wc_file = FileAccess.open("wc.txt", FileAccess.READ_WRITE)
	
	save_data = [_get_word_count_string(), _get_words_written_string(), _get_date_string(), _get_note_string()]
	
	wc_file.seek_end()
	wc_file.store_csv_line(save_data)
	wc_file.close()



func _get_word_count_string() -> String:
	var wc = word_count_string + str(int(word_count_entry.value))
	return wc



func _get_date_string() -> String:
	var month = month_entry.get_item_text(month_entry.selected)
	var day = day_entry.get_item_text(day_entry.selected)
	var year = year_entry.get_item_text(year_entry.selected)
	var d = date_string + month + " " + day + " " + year
	return d



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



func _populate_date() -> void:
	date = Time.get_datetime_dict_from_system()
	
	month_entry.selected = month_entry.get_item_index(date.month)
	
	# Add days based on month.
	for day in days_per_month[str(date.month)]:
		day = day + 1
		day_entry.add_item(str(day), day)
	
	day_entry.selected = day_entry.get_item_index(date.day)
	
	# Add years based on current year.
	for year in 11:
		year += date.year - 1
		year_entry.add_item(str(year), year)
	
	year_entry.selected = year_entry.get_item_index(date.year)



func _on_dark_mode_toggled(toggled_on):
	if toggled_on:
		root.theme = dark_theme
	else:
		root.theme = light_theme



func _on_accept_pressed():
	_save_data()
	_load_data()
