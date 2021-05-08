using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

public class SpaceShipBehaviour : MonoBehaviour
{
	[SerializeField]
	private float speed;
	
	private SpaceShip spaceShip;
	private MyInput input;
	private Vector2 inputVector;
	private bool fire;
	private bool readyToFire;
	public void Awake()
	{
		input = new MyInput();
		Vector2 size = GetComponent<SpriteRenderer>().bounds.size;
		spaceShip = new SpaceShip((int)size.x,size.y);
		spaceShip.Position = transform.position;
		spaceShip.Speed = speed;

		input.Enable();
		input.Player.Move.performed += OnMove;
		input.Player.PrimaryTouch.performed += PrimaryTouch;
	}

	private void PrimaryTouch(InputAction.CallbackContext callback)
	{
		Vector2 position = callback.ReadValue<Vector2>();
	}

	private void OnMove(InputAction.CallbackContext callback)
	{
		inputVector = callback.ReadValue<Vector2>();
		Debug.Log($"Move {inputVector}");
	}

	public void OnDestroy()
	{
		input.Player.Move.performed -= OnMove;
		input.Player.PrimaryTouch.performed -= PrimaryTouch;
		input.Dispose();
	}

	public void Update()
	{
		spaceShip.Move(inputVector.x, inputVector.y);
		transform.position = spaceShip.Position;
	}

	public void OnRespawn()
	{
		Vector3 min = GlobalState.Instance.WorldCameraBounds.min;
		min.y -= 10;
		min.x += GlobalState.Instance.WorldCameraBounds.extents.x;
		Debug.Log("Update");
		transform.position = min;
	}
}

public enum FireState
{
	Idle,
	Firing,
	Reloading
}

public class SpaceShip : IMover,IDamagable
{
	private int bullets;
	private float shipHalfWidth;
	private float shipHalfHeight;
	private Vector3 topRight;
	private Vector3 bottomLeft;
	private Vector3 tempPosition;
	public Vector3 Position { get; set; }
	public float Speed { get; set; }
	public float Health { get; set; }
	public Gun CurrentGun { get; set; }


	public SpaceShip(float width,float height,float health = 100,float speed = 10,Gun gun = default)
	{
		shipHalfWidth = width / 2;
		shipHalfHeight = height / 2;
		topRight   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
		bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Health = health;
		Speed = speed;
		CurrentGun = gun;
	}

	public void Move(float x, float y)
	{
		tempPosition = Position;
		tempPosition.x += x * Speed * Time.deltaTime;
		tempPosition.y += y * Speed * Time.deltaTime;
		tempPosition.x = Mathf.Clamp(tempPosition.x, bottomLeft.x + shipHalfWidth, topRight.x - shipHalfWidth);
		tempPosition.y = Mathf.Clamp(tempPosition.y, bottomLeft.y + shipHalfHeight, topRight.y - shipHalfHeight);
		Position = tempPosition;
	}

	public void SetClipSize(int bullets)
	{
		this.bullets = bullets;
	}

	public bool CanFire()
	{
		bool canFire = bullets > 0;
		return canFire;
	}

	public void Fire()
	{
		if(CurrentGun.CanFire())
		{
			CurrentGun.Fire();
		}
	}

	public void TakeDamage(float damage)
	{
		Health -= damage; 
	}
}




