using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class SpaceShipTests
{

	[Test]
	public void Space_Ship_Configuration()
	{
		var spaceShip = new SpaceShip(1,1);
		Assert.IsTrue(spaceShip.Health > 0);
		Assert.IsTrue(spaceShip.Speed > 0);
		bool positionInsideScreen = GlobalState.Instance.WorldCameraBounds.Contains(spaceShip.Position);
		Assert.IsTrue(positionInsideScreen);
	}

	[Test]
	[TestCase(80,50)]
	public void SpaceShip_Stays_Inside_Screen(float x,float y)
	{
		var spaceShip = new SpaceShip(1,1);
		spaceShip.Move(x, y);
		Vector3 topRight   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
		Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Debug.Log($" bottomLeft : {bottomLeft} topRight : {topRight}");
		
		Assert.IsTrue(spaceShip.Position.x >= bottomLeft.x);
		Assert.IsTrue(spaceShip.Position.x <= topRight.x);
		Assert.IsTrue(spaceShip.Position.y <= topRight.y);
		Assert.IsTrue(spaceShip.Position.y >= bottomLeft.y);
	}

	[Test]
	public void Gun_Assigned_Properly()
	{
		var spaceShip = new SpaceShip(1, 1);
		spaceShip.CurrentGun = new LaserGun(10,60,2);
		Assert.IsTrue(spaceShip.CurrentGun.Capacity > 0);
		Assert.IsTrue(spaceShip.CurrentGun.FireRate > 0);
		Assert.IsTrue(spaceShip.CurrentGun.ReloadTime > 0);
	}

	[Test]
	public void Space_Ship_Instantiates_OutsideScreen()
	{
		var spawnedPlayer = Resources.Load("Player") as GameObject;
		var spaceShip = spawnedPlayer.GetComponent<SpaceShipBehaviour>();
		spaceShip.OnRespawn();
		bool positionOutside = !GlobalState.Instance.WorldCameraBounds.Contains(spaceShip.transform.position);
		Assert.IsTrue(positionOutside);
	}
	
}
