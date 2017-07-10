using UnityEngine;

public static class ToggleButton {

	private static GUIStyle ToggleButtonStyleNormal;
	private static GUIStyle ToggleButtonStyleToggled;

	/// <summary>
	/// Makes a toggle style button.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="b">If set to <c>true</c> button will be toggled.</param>
	public static bool Draw(string name, bool b)
	{
		GetToggleStyle();
		return GUILayout.Button(name, b ? ToggleButtonStyleToggled : ToggleButtonStyleNormal);
	}

	public static bool Draw(string name, bool b, params GUILayoutOption[] options)
	{
		GetToggleStyle();
		return GUILayout.Button(name, b ? ToggleButtonStyleToggled : ToggleButtonStyleNormal, options);
	}
		
	private static void GetToggleStyle()
	{
		if ( ToggleButtonStyleNormal == null )
		{
			ToggleButtonStyleNormal = "Button";
			ToggleButtonStyleToggled = new GUIStyle(ToggleButtonStyleNormal);
			ToggleButtonStyleToggled.normal.background = ToggleButtonStyleToggled.active.background;
		}
	}
}
