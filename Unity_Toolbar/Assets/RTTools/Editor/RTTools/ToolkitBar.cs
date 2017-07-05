using UnityEngine;
using System.Collections.Generic;

namespace RTTools.Models
{
	[System.Serializable]
	public class ToolkitBar : ScriptableObject
	{
//		public ToolkitItem[] items;
//
//		public ToolkitBar()
//		{
//			items = new ToolkitItem[1];
//		}

		public List<ToolkitItem> items = new List<ToolkitItem>();
	}
}
