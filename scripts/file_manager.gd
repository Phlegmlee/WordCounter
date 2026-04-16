# File Manager
class_name FileManager
extends Control

signal file_changed

@export var settings_manager : SettingsManager
@onready var current_project_name : Label = %FileName
@onready var project_display_string : String = BASE_FILE_NAME.get_basename()

const USER_FILE_PREFIX : String = "user://"
const BASE_FILE_NAME : String = "WordCounter.txt"
var user_file_name : String = "your_userfile.txt"
var current_file : String = USER_FILE_PREFIX + BASE_FILE_NAME

enum FileState {
	BASE,
	USER
}
var current_state : FileState = FileState.BASE


func _ready() -> void:
	if settings_manager.has_setting("file_state"):
		current_state = settings_manager.get_setting("file_state")
	if settings_manager.has_setting("user_file_name"):
		user_file_name = settings_manager.get_setting("user_file_name")
	if settings_manager.has_setting("current_file"):
		current_file = settings_manager.get_setting("current_file")
	if settings_manager.has_setting("project_name"):
		project_display_string = settings_manager.get_setting("project_name")
	
	current_project_name.text = project_display_string
	
	_file_check_create(current_state)


func _file_check_create(file_state : FileState) -> void:
	match file_state:
		FileState.BASE:
			current_file = USER_FILE_PREFIX + BASE_FILE_NAME
		
		FileState.USER:
			current_file = user_file_name
	
	_create_file(current_file)


func _create_file(file : String, overwrite : bool = false) -> void:
	if not FileAccess.file_exists(file) or overwrite:
		var wc_file = FileAccess.open(file, FileAccess.WRITE)
		wc_file.close()


func load_data() -> FileAccess:
	var file = FileAccess.open(current_file, FileAccess.READ)
	return file


func save_data(data : PackedStringArray) -> void:
	var file = FileAccess.open(current_file, FileAccess.READ_WRITE)

	file.seek_end()
	file.store_csv_line(data)
	file.close()


func new_file(file_name : String = user_file_name) -> void:
	DisplayServer.file_dialog_show("Create a new File", ProjectSettings.globalize_path(USER_FILE_PREFIX), file_name, false, DisplayServer.FILE_DIALOG_MODE_SAVE_FILE, ["*.txt"], _on_new_file_created)


func open_file() -> void:
	DisplayServer.file_dialog_show("Open a File", ProjectSettings.globalize_path(USER_FILE_PREFIX), "", false, DisplayServer.FILE_DIALOG_MODE_OPEN_FILE, ["*.txt"], _on_file_selected)


func _set_current_state() -> void:
	if current_file != USER_FILE_PREFIX + BASE_FILE_NAME:
		current_state = FileState.USER
		user_file_name = current_file
		settings_manager.add_setting("user_file_name", user_file_name)
	else:
		current_state = FileState.BASE
	
	settings_manager.add_setting("file_state", current_state)
	settings_manager.add_setting("current_file", current_file)
	settings_manager.add_setting("project_name", project_display_string)
	current_project_name.text = project_display_string


func _on_file_selected(status : bool, selected_paths : PackedStringArray, _selected_filter_index : int) -> void:
	if not status:
		return
	
	
	current_file = USER_FILE_PREFIX + selected_paths[0].get_file()
	project_display_string = selected_paths[0].get_file().get_basename()
	_set_current_state()
	file_changed.emit()


func _on_new_file_created(status : bool, selected_paths : PackedStringArray, _selected_filter_index : int) -> void:
	if not status:
		return
	
	current_file = USER_FILE_PREFIX + selected_paths[0].get_file()
	_create_file(current_file, true)
	project_display_string = selected_paths[0].get_file().get_basename()
	_set_current_state()
	file_changed.emit()
