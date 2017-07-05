using UnityEngine;

namespace RTTools.Models
{
	public class ToolkitBar : ScriptableObject
	{
		public ToolkitItem[] items;

		public ToolkitBar()
		{
			items = new ToolkitItem[1];
		}
	}
}
