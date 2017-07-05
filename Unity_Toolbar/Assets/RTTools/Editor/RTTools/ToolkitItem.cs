using UnityEditor;
using UnityEngine;
using UnityEditor.AnimatedValues;

namespace RTTools.Models
{
	[System.Serializable]
	public class ToolkitItem
	{
		public string buttonName = "ButtonName";
		public string summary = "Summary - What does this button do?";
		public Texture icon;
		public MonoScript script;
		public string functionName = "FunctionName";

		[HideInInspector]
		public AnimBool showSummary;

		public ToolkitItem()
		{
			showSummary = new AnimBool(false);
			showSummary.target = false;
		}
	}
}
