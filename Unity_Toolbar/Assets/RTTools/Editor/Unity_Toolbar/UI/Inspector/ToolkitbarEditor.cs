using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;
using RTTools.Models;
using RTTools.UI.Elements;

namespace RTTools.UI.Inspector
{
	[CustomEditor(typeof(ToolkitBar))]
	public class ToolkitBarEditor : Editor
	{
		private const BindingFlags BINDING_FLAGS = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
		private const int VERTICAL_ELEMENTS_WIDTH = 145;
		private const int ENTRY_BUTTON_HEIGHT = 28;
		private const int OBJECTFIELD_SIZE = 60;

		private ToolkitBar toolkitBar;

		private void OnEnable()
		{
			toolkitBar = (ToolkitBar)target;
		}

        /// <summary>
        /// Overrides the inspector GUI.
        /// </summary>
		public override void OnInspectorGUI()
		{
			GUILayout.BeginVertical("Box");
			GUILayout.Label("Total entries: " + toolkitBar.items.Count);
			
            DrawUpperButtons();
			DrawButtonEntries();
			
            GUILayout.EndVertical();

			Repaint();
		}

		/// <summary>
		/// Draws the 'Add Button' and 'Delete All' buttons.
		/// </summary>
		private void DrawUpperButtons()
		{
			if (GUILayout.Button("Save Setup"))
			{
                HandleSaving();
			}

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Add Button"))
			{
				AddButton();
			}

			if (ColoredButton.Draw("Remove All", Color.red))
			{
				if (EditorUtility.DisplayDialog("Delete items",
					"Are you sure you want to delete all buttons?",
					"Delete all",
					"Cancel"))
				{
					RemoveAll();
					return;
				}
			}
			GUILayout.EndHorizontal();
		}

		/// <summary>
		/// Draws the button entries.
		/// </summary>
		private void DrawButtonEntries()
		{
			foreach (ToolkitItem item in toolkitBar.items.ToArray())
			{
				GUILayout.BeginVertical("Box");

				DrawInputFields(item);
				DrawSummaryDropdown(item);
				GetMethodsInScript(item);

				GUILayout.EndVertical();
			}
		}

        /// <summary>
        /// Gets the methods in the specified script.
        /// </summary>
        /// <param name="item">ToolkitItem.</param>
		private void GetMethodsInScript(ToolkitItem item)
		{
			if (item.script != null)
			{
				item.monoMethods = item.script.GetClass().GetMethods(BINDING_FLAGS);

				List<string> items = new List<string>();

				foreach (MethodInfo method in item.monoMethods)
				{
					items.Add(method.Name);
					item.methodNames = items.ToArray();
				}
				item.functionName = item.methodNames[item.index];
			}
		}

        /// <summary>
        /// Draws the input fields for the icon, name, script and function.
        /// </summary>
        /// <param name="item">ToolkitItem.</param>
		private void DrawInputFields(ToolkitItem item)
		{
			GUILayout.BeginHorizontal("Box");

			DrawEntryButtons(item);
			item.icon = (Texture)EditorGUILayout.ObjectField(string.Empty, item.icon, typeof(Texture), true, GUILayout.Width(OBJECTFIELD_SIZE), GUILayout.Height(OBJECTFIELD_SIZE));

			EditorGUILayout.BeginVertical();
			item.buttonName = GUILayout.TextField(item.buttonName, GUILayout.Width(VERTICAL_ELEMENTS_WIDTH));
			item.script = (MonoScript)EditorGUILayout.ObjectField(string.Empty, item.script, typeof(MonoScript), true, GUILayout.Width(VERTICAL_ELEMENTS_WIDTH));

			if (item.methodNames != null)
			{
				item.index = EditorGUILayout.Popup(item.index, item.methodNames, GUILayout.Width(VERTICAL_ELEMENTS_WIDTH));
			}
			EditorGUILayout.EndVertical();

			GUILayout.EndHorizontal();
		}

		/// <summary>
		/// Draws the delete and summary button.
		/// </summary>
		/// <param name="item">ToolkitItem.</param>
		private void DrawEntryButtons(ToolkitItem item)
		{
			GUILayout.BeginVertical();
			if (ColoredButton.Draw("X", Color.red, GUILayout.Height(ENTRY_BUTTON_HEIGHT)))
			{
				if (EditorUtility.DisplayDialog("Delete item",
					"Are you sure you want to delete: " + item.buttonName + "?",
					"Delete",
					"Cancel"))
				{
					RemoveButton(item);
					return;
				}
			}

			if (ToggleButton.Draw("?", item.showSummary.target, GUILayout.Height(ENTRY_BUTTON_HEIGHT)))
			{
				item.showSummary.target = !item.showSummary.target;
			}
			GUILayout.EndVertical();
		}

        /// <summary>
        /// Draws the summary dropdown.
        /// </summary>
        /// <param name="item">ToolkitItem.</param>
		private void DrawSummaryDropdown(ToolkitItem item)
		{
			if (EditorGUILayout.BeginFadeGroup(item.showSummary.faded))
			{
				item.summary = GUILayout.TextArea(item.summary);
				GUILayout.Space(16);
			}
			EditorGUILayout.EndFadeGroup();
		}

        /// <summary>
        /// Adds a button.
        /// </summary>
		private void AddButton()
		{
			toolkitBar.items.Add(new ToolkitItem());
			HandleSaving();
		}

        /// <summary>
        /// Removes all buttons.
        /// </summary>
		private void RemoveAll()
		{
			toolkitBar.items.Clear();
			HandleSaving();
		}

        /// <summary>
        /// Removes a button.
        /// </summary>
        /// <param name="item">ToolkitItem.</param>
		private void RemoveButton(ToolkitItem item)
		{
			toolkitBar.items.Remove(item);
			HandleSaving();
		}

        /// <summary>
        /// Sets the asset dirty so we can save it. 
        /// </summary>
		private void HandleSaving()
		{
			EditorUtility.SetDirty(toolkitBar);
			AssetDatabase.SaveAssets();
		}
	}

}
