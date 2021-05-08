using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun
{
	protected float fireRate;
	protected int capacity;
	protected float reloadTime;

	public abstract float FireRate{get;protected set;}
	public abstract int Capacity {get;protected set;}
	public abstract float ReloadTime { get;protected set; }

	public abstract bool CanFire();
	public abstract void Fire();
	public abstract void SetCapacity(int capacity);
	public abstract void SetFireRate(float fireRate);
	public abstract void SetReloadTime(float reloadTime);
}
