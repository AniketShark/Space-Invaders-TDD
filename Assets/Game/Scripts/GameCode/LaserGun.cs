using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Gun
{
	public LaserGun(float fireRate,int capacity, float reloadTime)
	{
		Capacity = capacity;
		FireRate = fireRate;
		ReloadTime = reloadTime;
		BulletRemaining = capacity;
	}

	public override float FireRate { get; protected set; }
	public override int Capacity { get; protected set; }
	public override float ReloadTime { get; protected set; }
	public  float BulletRemaining { get; set; }

	public override bool CanFire()
	{
		if (BulletRemaining > 0)
			return true;
		return false;
	}

	public override void Fire()
	{
		BulletRemaining--;

		if (BulletRemaining <= 0)
			BulletRemaining = 0;
	}

	public override void SetCapacity(int capacity)
	{
		Capacity = capacity;
	}

	public override void SetFireRate(float fireRate)
	{
		FireRate = fireRate;
	}

	public override void SetReloadTime(float reloadTime)
	{
		ReloadTime = reloadTime;
	}
}