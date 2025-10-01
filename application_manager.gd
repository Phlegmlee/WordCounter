extends Control

@export_category("GUI")
@export var root : Control

@export_category("Entries")
@export var word_count_entry : SpinBox
@export var month_entry : OptionButton
@export var day_entry : OptionButton
@export var year_entry : OptionButton

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



func _ready() -> void:
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
