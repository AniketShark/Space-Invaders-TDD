using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;

public class InputStickPosition : MonoBehaviour
{
    public MyInput input;

    void Start()
    {
        input = new MyInput();
        input.Enable();
        input.Player.PrimaryTouch.performed += PrimaryTouch;
    }
	private void OnDestroy()
	{
	    input.Player.PrimaryTouch.performed -= PrimaryTouch;
        input.Dispose();
    }

	private void PrimaryTouch(InputAction.CallbackContext obj)
	{
		transform.position = obj.ReadValue<Vector2>();
	}

}
