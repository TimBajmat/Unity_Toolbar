using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using RTTools.Helpers;
using RTTools.Models;

namespace RTTools.Windows 
{
	public class Toolkit : EditorWindow
	{
		private const BindingFlags FLAGS = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
		private const string TOOL_TITLE = "RTTools";
		private const string GUI_SKIN = "GUISkin";
		private const string TOOLKIT = "Toolkit";
		private const float DEFAULT_SIZE = 72f;

		private ToolkitBar toolkitBar;
		private Vector2 scrollPos;
		private GUISkin skin;

		[MenuItem("RTTools/Toolbar %g")]
		private static void ShowWindow()
		{
			Toolkit window = (Toolkit)EditorWindow.GetWindow(typeof(Toolkit), false, TOOL_TITLE);
			window.minSize = new Vector2(100, DEFAULT_SIZE);
			window.maxSize = new Vector2(DEFAULT_SIZE, DEFAULT_SIZE);
			window.CenterOnMainWindow();
		}

		private void OnEnable()
		{
			toolkitBar = Resources.Load<ToolkitBar>(TOOLKIT);
			skin = Resources.Load<GUISkin>(GUI_SKIN);
		}
		
		private void OnGUI()
		{
			ShowButtons();
			Repaint();
		}
			
        /// <summary>
        /// Shows the buttons in the EditorWindow.
        /// </summary>
		private void ShowButtons()
		{
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height));
			if (toolkitBar == null || toolkitBar.items == null)
			{
				toolkitBar = Resources.Load<ToolkitBar>(TOOLKIT);
			}
            else
            {
				foreach (ToolkitItem item in toolkitBar.items)
				{
					CreateButton(item);
				} 
            }
			EditorGUILayout.EndScrollView();
		}

		/// <summary>
		/// Creates the button in the EditorWindow.
		/// </summary>
		/// <param name="item">ToolkitItem.</param>
		private void CreateButton(ToolkitItem item)
		{
			if (GUILayout.Button(item.icon, skin.button))
			{
				CallFunction(item);
			}
		}

        /// <summary>
        /// Calls the function that is specified for the given item.
        /// </summary>
        /// <param name="item">ToolkitItem.</param>
		private static void CallFunction(ToolkitItem item)
		{
            if (!EditorApplication.isPlaying)
            {
                try
                {
                    Type type = item.script.GetClass();
                    object classObject = null;

                    if (!type.IsAbstract && !type.IsSubclassOf(typeof(EditorWindow)))
                    {
                        classObject = CreateInstance(type);
                    }

                    type.GetMethod(item.functionName, FLAGS).Invoke(classObject, null);
                }
                catch
                {
                    Debug.LogError("Something went wrong, check the name of the function you want to call");
                }
            }
		}
	}
}