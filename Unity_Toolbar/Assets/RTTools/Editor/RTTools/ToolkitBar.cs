using UnityEngine;
using System.Collections.Generic;

namespace RTTools.Models
{
	[System.Serializable]
	public class ToolkitBar : ScriptableObject
	{
		public List<ToolkitItem> items = new List<ToolkitItem>();
	}
}
