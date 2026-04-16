class_name Settings
extends Control

@export_category("GUI")
@export var root : Control
@onready var dark_mode_toggle : CheckButton = %DarkMode
@onready var file_button : MenuButton = %FILE
@onready var file_popup : PopupMenu = file_button.get_popup()

@onready var _version_label = %version_label
@onready var _project_version = ProjectSettings.get("application/config/version")

@export var file_manager : FileManager
@export var settings_manager : SettingsManager

var light_theme = preload("res://themes/light-mode-theme.tres")
var dark_theme = preload("res://themes/dark_mode_theme.tres")

enum ThemeState {
	DARK,
	LIGHT
}
var current_theme : ThemeState = ThemeState.DARK

func _ready() -> void:
	file_popup.id_pressed.connect(_file_menu_pressed)
	if settings_manager.has_setting("current_theme"):
		current_theme = settings_manager.get_setting("current_theme")
		
	_theme_check()
	_version_label.text = "Version: " + _project_version


func _theme_check() -> void:
	match current_theme:
		ThemeState.DARK:
			root.theme = dark_theme
			dark_mode_toggle.button_pressed = true
		ThemeState.LIGHT:
			root.theme = light_theme
			dark_mode_toggle.button_pressed = false


func _on_dark_mode_toggled(toggled_on):
	if toggled_on:
		current_theme = ThemeState.DARK
	else:
		current_theme = ThemeState.LIGHT
	
	_theme_check()
	settings_manager.add_setting("current_theme", current_theme)


func _file_menu_pressed(id : int) -> void:
	match id:
		0:
			file_manager.new_file()
		1:
			file_manager.open_file()
		2:
			OS.shell_open(ProjectSettings.globalize_path(file_manager.USER_FILE_PREFIX))
