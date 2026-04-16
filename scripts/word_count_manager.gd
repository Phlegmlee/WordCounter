# Word Count Manager
extends Control

@onready var _spin_box : SpinBox = %SpinBox

var prev_word_count := 0
var word_count_string : String = "Word Count: "
var words_written_string : String = " Words Written: "



func _get_words_written() -> int:
	var current_wc = _spin_box.value
	var words_written = current_wc - prev_word_count
	return words_written



func get_previous_word_count(log_cont) -> void:
	if not log_cont:
		_spin_box.value = 0
		prev_word_count = 0
	
	var split_lines = log_cont.split("\n")
	var last_line = split_lines[split_lines.size() - 2]
	var split_last = last_line.split(",")
	
	var regex = RegEx.new()
	regex.compile("\\d+")
	var word_count = regex.search_all(split_last[0])
	for number in word_count:
		var number_found = int(number.get_string())
		_spin_box.value = number_found
		prev_word_count = number_found
		break



func get_word_count_string() -> String:
	var wc = word_count_string + str(int(_spin_box.value))
	return wc



func get_words_written_string() -> String:
	var ww = _get_words_written()
	var ww_string = words_written_string + str(ww)
	return ww_string
