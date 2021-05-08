using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

public class GunTests
{
	[Test]
	[TestCase(10,30,2)]
	[TestCase(30,30,2)]
	[TestCase(30,0,2)]
	[TestCase(10,30,-1)]
	public void Gun_Config(float fireRate,int capacity,float reloadTime)
	{
		var spaceShip = new SpaceShip(1,1);
		var gun = new LaserGun(fireRate,capacity,reloadTime);
		Assert.IsTrue(gun.FireRate < gun.Capacity); // fire rate is bullets per second
		Assert.IsTrue(gun.FireRate > 0);
		Assert.IsTrue(gun.ReloadTime > 0);
		Assert.IsTrue(gun.Capacity > 0);
	}


	[Test]
	public void Dont_Fire_If_No_Bullets()
	{
		var gun = new LaserGun(10, 30, 2);
		var spaceShip = new SpaceShip(1, 1,100,10,gun);

		for(int i = 0; i <= gun.Capacity;i++)
		{
			spaceShip.Fire();
		}
		Assert.IsTrue(!gun.CanFire());
	}

	[Test]
	public void Dont_Fire_When_Reloading()
	{

	}



}
