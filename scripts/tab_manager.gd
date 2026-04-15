extends TabContainer

const FILE_SIGNED_ICON = preload("uid://ca815babvuov4")
const FILE_ICON = preload("uid://c4p40oswhju8f")
const FOLDER_ICON = preload("uid://cwm2tc302ryc1")
const HOME_ICON = preload("uid://ba0jxuf7l8g3b")
const SETTINGS_ICON = preload("uid://bx5nlww500no4")


func _ready() -> void:
	self.set_tab_icon(0, HOME_ICON)
	self.set_tab_icon(1, FILE_SIGNED_ICON)
	self.set_tab_icon(2, SETTINGS_ICON)
