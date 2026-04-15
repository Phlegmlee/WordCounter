# Date Management
extends Control

# TODO: Handle days per month when month selection is changed. For example, Febuary only has 28 or 29 days
#		and if the month is changed the days are wrong.
#		CONCEPT: when month changed -> update days

@onready var _month_entry : OptionButton = %Month
@onready var _day_entry : OptionButton = %Day
@onready var _year_entry : OptionButton = %Year

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

var _date_string : String = " Date: "


func _ready() -> void:
	_populate_date()


func _populate_date() -> void:
	date = Time.get_datetime_dict_from_system()
	
	_month_entry.selected = _month_entry.get_item_index(date.month)
	
	# Add days based on month.
	for day in days_per_month[str(date.month)]:
		day = day + 1
		_day_entry.add_item(str(day), day)
	
	_day_entry.selected = _day_entry.get_item_index(date.day)
	
	# Add years based on current year.
	for year in 11:
		year += date.year - 1
		_year_entry.add_item(str(year), year)
	
	_year_entry.selected = _year_entry.get_item_index(date.year)


func get_date_string() -> String:
	var month = _month_entry.get_item_text(_month_entry.selected)
	var day = _day_entry.get_item_text(_day_entry.selected)
	var year = _year_entry.get_item_text(_year_entry.selected)
	var d = _date_string + month + " " + day + " " + year
	return d
