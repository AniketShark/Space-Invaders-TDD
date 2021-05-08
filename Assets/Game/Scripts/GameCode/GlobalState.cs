using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState
{
	private static GlobalState _instance;
	public static GlobalState Instance
	{
		get {
			if (_instance == null)
				_instance = new GlobalState();
			return _instance;
		}
	}

	public Bounds WorldCameraBounds
	{
		get
		{
			Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
			Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
			Bounds bound = new Bounds();
			bound.SetMinMax(bottomLeft, topRight);
			bound.Encapsulate(Vector3.forward * 100);
			return bound;
		}
	}
}
