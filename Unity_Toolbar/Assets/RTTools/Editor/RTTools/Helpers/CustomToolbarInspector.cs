using UnityEngine;
using UnityEditor;
using RTTools.Models;
using System.Reflection;

[CustomEditor(typeof(ToolkitBar))]
public class CustomToolbarInspector : Editor 
{
	private const BindingFlags FLAGS = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
	ToolkitBar tb;

	private void OnEnable()
	{
		tb = (ToolkitBar)target;
	}
		
	public override void OnInspectorGUI()
	{
		GUILayout.BeginVertical("Box");


		GUILayout.Label("Total entries: " + tb.items.Count);

		DrawUpperButtons();
		DrawButtonEntries();

		GUILayout.EndVertical();

		Repaint();
	}

	private void DrawUpperButtons()
	{
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Add Button"))
		{
			AddButton();
			Repaint();
		}

		if(ColoredButton.Draw("Remove All", Color.red))
		{
			if( EditorUtility.DisplayDialog("Delete items",
				"Are you sure you want to delete all buttons?", 
				"Delete all", 
				"Cancel"))
			{
				RemoveAll();
			}
		}
		GUILayout.EndHorizontal();
	}

	private void DrawButtonEntries()
	{
		foreach (ToolkitItem item in tb.items.ToArray()) 
		{
			item.showSummary.valueChanged.AddListener(Repaint);

			GUILayout.BeginVertical("Box");
			GUILayout.BeginHorizontal("Box");

			GUILayout.BeginVertical();
			DrawEntryButtons(item);
			GUILayout.EndVertical();

			item.icon = (Texture)EditorGUILayout.ObjectField (string.Empty, item.icon, typeof(Texture), true, GUILayout.Width(60), GUILayout.Height(60));

			GUILayout.BeginVertical();
			item.buttonName = GUILayout.TextField(item.buttonName, GUILayout.Width(145));
			item.functionName = GUILayout.TextField(item.functionName, GUILayout.Width(145));
			item.script = (MonoScript)EditorGUILayout.ObjectField (string.Empty, item.script, typeof(MonoScript), true, GUILayout.Width(145));
			GUILayout.EndVertical();

			GUILayout.EndHorizontal();

			if (EditorGUILayout.BeginFadeGroup(item.showSummary.faded))
			{
				item.summary = GUILayout.TextArea(item.summary);
				GUILayout.Space(16);
			}
			EditorGUILayout.EndFadeGroup();
		
			GUILayout.EndVertical();
		}
	}

	private void DrawEntryButtons(ToolkitItem item)
	{
		if(ColoredButton.Draw("X", Color.red, GUILayout.Height(28)))
		{
			if( EditorUtility.DisplayDialog("Delete item",
				"Are you sure you want to delete: " + item.buttonName + "?", 
				"Delete", 
				"Cancel"))
			{
				RemoveButton(item);
			}
		}
		if(ToggleButton.Draw("?", item.showSummary.target, GUILayout.Height(28)))
		{
			item.showSummary.target = !item.showSummary.target;
		}
	}
		
	private void AddButton()
	{
		tb.items.Add(new ToolkitItem());
	}

	private void RemoveAll()
	{
		tb.items.Clear();
	}

	private void RemoveButton(ToolkitItem item)
	{
		
		tb.items.Remove(item);
		
	}
		
}
