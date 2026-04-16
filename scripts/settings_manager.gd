# Settings Manager - Creates and handles the settings config.
class_name SettingsManager
extends Node

const SETTINGS_FILE_PATH : String = "user://settings.config"

var settings_data : Dictionary = {}


func _enter_tree() -> void:
	_file_check_create()



func _file_check_create() -> void:
	if not FileAccess.file_exists(SETTINGS_FILE_PATH):
		var settings_file = FileAccess.open(SETTINGS_FILE_PATH, FileAccess.WRITE)
		settings_file.close()


func _save_settings() -> void:
	var settings_file = FileAccess.open(SETTINGS_FILE_PATH, FileAccess.WRITE)
	settings_file.store_var(settings_data)
	settings_file.close()


func _load_settings() -> void:
	var settings_file = FileAccess.open(SETTINGS_FILE_PATH, FileAccess.READ)
	if not settings_file.get_length():
		return
	settings_data = settings_file.get_var()


func add_setting(key : String, value : Variant) -> void:
	if settings_data.has(key):
		settings_data.erase(key)
	settings_data.get_or_add(key, value)
	_save_settings()


func get_setting(key : String) -> Variant:
	_load_settings()
	return settings_data.get(key)


func has_setting(key : String) -> bool:
	_load_settings()
	return settings_data.has(key)
