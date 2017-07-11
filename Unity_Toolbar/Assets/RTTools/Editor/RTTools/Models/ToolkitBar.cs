using System.Collections.Generic;
using UnityEngine;

namespace RTTools.Models
{
	[System.Serializable]
	public class ToolkitBar : ScriptableObject
	{
		public List<ToolkitItem> items = new List<ToolkitItem>();
	}
}

