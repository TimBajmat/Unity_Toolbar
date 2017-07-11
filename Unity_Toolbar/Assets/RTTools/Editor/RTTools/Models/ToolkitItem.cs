using UnityEditor;
using UnityEngine;
using UnityEditor.AnimatedValues;
using System.Reflection;

namespace RTTools.Models
{
    [System.Serializable]
    public class ToolkitItem
    {
        public string buttonName = "Name";
        public string summary = "Summary - What does this button do?";
        public Texture icon;
        public MonoScript script;
        public string functionName;

        [HideInInspector]
        public int index;

        [HideInInspector]
        public AnimBool showSummary;

        [HideInInspector]
        public MethodInfo[] monoMethods;

        [HideInInspector]
        public string[] methodNames;

        public ToolkitItem()
        {
            showSummary = new AnimBool(false)
            {
                target = false
            };
        }
    }
}
