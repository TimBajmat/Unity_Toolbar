using UnityEngine;

public class Demo : MonoBehaviour
{
	public void PublicFunction()
	{
		Debug.Log("Called PublicFuntion");
	}

	private void PrivateFunction()
	{
		Debug.Log("Called PrivateFunction");
	}

	public static void PublicStaticFunction()
	{
		Debug.Log("Called PublicStaticFuntion");
	}

	private static void PrivateStaticFunction()
	{
		Debug.Log("Called PrivateStaticFuntion");
	}
}
