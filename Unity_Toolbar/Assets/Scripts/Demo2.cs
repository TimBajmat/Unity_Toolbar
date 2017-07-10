using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Demo2 
{
	public static void PublicTest()
	{
		Debug.Log("Called PublicTest");
	}

	private static void PrivateTest()
	{
		Debug.Log("Called PrivateTest");
	}
}
