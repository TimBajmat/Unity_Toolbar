using UnityEditor;
using RTTools;
using RTTools.Models;
using UnityEngine;
using System.IO;

public static class ScriptableObjectUtility
{
	private const string PATH = "Assets/RTTools/Editor/RTTools/Resources/";
	private const string ASSET_NAME = "Toolkit";
	private const string ASSET_EXTENSION = ".asset";

	[MenuItem("Assets/Create/Create ScriptableObject %l")]
	private static void CreateScriptableObject()
	{
		CreateAsset<ToolkitBar>();
	}

	private static void CreateAsset<T> () where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T> ();

		string path = AssetDatabase.GetAssetPath (Selection.activeObject);
		if (path == string.Empty) 
		{
			path = "Assets";
		} 
		else if (Path.GetExtension (path) != string.Empty) 
		{
			path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), string.Empty);
		}

		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (PATH + "/" + ASSET_NAME + ASSET_EXTENSION);

		AssetDatabase.CreateAsset (asset, assetPathAndName);

		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}
}