using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTests
{
	[Test]
	[TestCase(10,10,1)]
	public void Bullet_Config(float speed,float damage, float ttl)
	{
		var bullet = new Bullet(damage,ttl);
		bullet.Speed = speed;
		Assert.IsTrue(bullet.Damage > 0);
		Assert.IsTrue(bullet.Speed > 0);
		Assert.IsTrue(bullet.TTL > 0);
	}

	[Test]
	public void Bullet_Damage_SpaceShip()
	{
		var bullet = new Bullet(10,1);
		var spaceShip = new SpaceShip(1, 1);
		float beforeDamage = spaceShip.Health;
		spaceShip.TakeDamage(bullet.Damage);
		Assert.IsTrue(spaceShip.Health == beforeDamage - bullet.Damage);
	}

	[Test]
	[TestCase(1,1)]
	[TestCase(100,100)]
	public void Bullet_Destroyed_After_Screen_Bounds(float x,float y)
	{
		var bullet = new Bullet(10,1);
		bullet.Position = new Vector3(x,y);
		bullet.Move(0,0); // move bullet by 0 amount just to run the position check
		Assert.IsTrue(bullet.Active);
	}
}
