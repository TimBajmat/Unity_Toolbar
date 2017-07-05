using UnityEditor;
using UnityEngine;

namespace RTTools.Models
{
	[System.Serializable]
	public class ToolkitItem
	{
		public string buttonName;
		public string summary;
		public Texture icon;
		public MonoScript script;
		public string functionName;
	}
}
