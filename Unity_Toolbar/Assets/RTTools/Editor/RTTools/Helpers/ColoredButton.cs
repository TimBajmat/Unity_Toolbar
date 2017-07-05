using UnityEngine;

public static class ColoredButton 
{
	/// <summary>
	/// Draws the button with the specified name and color.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="color">Color.</param>
	public static bool Draw(string name, Color color)
	{
		GUI.color = color;
		bool b = GUILayout.Button(name);
		GUI.color = Color.white;

		return b;
	}

	/// <summary>
	/// Draws the button with the specified name, color and options.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="color">Color.</param>
	/// <param name="options">Options.</param>
	public static bool Draw(string name, Color color, params GUILayoutOption[] options)
	{
		GUI.color = color;
		bool b = GUILayout.Button(name, options);
		GUI.color = Color.white;

		return b;
	}

	/// <summary>
	/// Draws the button with the specified image and color.
	/// </summary>
	/// <param name="image">Image.</param>
	/// <param name="color">Color.</param>
	public static bool Draw(Texture image, Color color)
	{
		GUI.color = color;
		bool b = GUILayout.Button(image);
		GUI.color = Color.white;

		return b;
	}

	/// <summary>
	/// Draws the button with the specified image, color and options.
	/// </summary>
	/// <param name="image">Image.</param>
	/// <param name="color">Color.</param>
	/// <param name="options">Options.</param>
	public static bool Draw(Texture image, Color color, params GUILayoutOption[] options)
	{
		GUI.color = color;
		bool b = GUILayout.Button(image, options);
		GUI.color = Color.white;

		return b;
	}
}
