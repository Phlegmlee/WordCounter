class_name Settings
extends Control

@export_category("GUI")
@export var root : Control
@export var darkmode_toggle : CheckButton
var light_theme = preload("res://themes/light-mode-theme.tres")
var dark_theme = preload("res://themes/dark_mode_theme.tres")

@onready var _version_label = %version_label
@onready var _project_version = ProjectSettings.get("application/config/version")


func _ready() -> void:
	_theme_check()
	_version_label.text = "Version: " + _project_version


func _theme_check() -> void:
	if DisplayServer.is_dark_mode_supported():
		if DisplayServer.is_dark_mode():
			root.theme = dark_theme
			darkmode_toggle.button_pressed = true
		else:
			root.theme = light_theme
			darkmode_toggle.button_pressed = false


func _on_dark_mode_toggled(toggled_on):
	if toggled_on:
		root.theme = dark_theme
	else:
		root.theme = light_theme
