using UnityEngine;

public static class ToggleButton {

	private static GUIStyle ToggleButtonStyleNormal;
	private static GUIStyle ToggleButtonStyleToggled;

	/// <summary>
	/// Makes a toggle style button.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="value">If set to <c>true</c> button will be toggled.</param>
	public static bool Draw(string name, bool value)
	{
		GetStyle();
		return GUILayout.Button(name, value ? ToggleButtonStyleToggled : ToggleButtonStyleNormal);
	}

	public static bool Draw(string name, bool value, params GUILayoutOption[] options)
	{
		GetStyle();
		return GUILayout.Button(name, value ? ToggleButtonStyleToggled : ToggleButtonStyleNormal, options);
	}
		
	private static void GetStyle()
	{
		if ( ToggleButtonStyleNormal == null )
		{
			ToggleButtonStyleNormal = "Button";
			ToggleButtonStyleToggled = new GUIStyle(ToggleButtonStyleNormal);
			ToggleButtonStyleToggled.normal.background = ToggleButtonStyleToggled.active.background;
		}
	}
}
