using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float damage;

    private Bullet bullet;

	private void Awake()
	{
        if(bullet == null)
            bullet = new Bullet(speed, damage);
        bullet.Position = transform.position;
    }

    private void OnEnable()
	{
        if (bullet == null)
            bullet = new Bullet(speed, damage);

        bullet.SetActive(true);
        bullet.Position = transform.position;
    }


	private void Update()
	{
		if(bullet.Active)
		{
            bullet.Move(0, 1);
		}
	}
}

public class Bullet : IMover 
{
    private float damage;
    private float ttl;
    private float activateTime;
    private bool active;
    private Vector3 tempPosition;
    private Bounds worldBounds;

    public float Damage => damage;
    public float TTL => ttl;
    public bool Active => active;
    public Vector3 Position { get; set; }
	public float Speed { get; set; }

    public Bullet(float damage,float ttl)
	{
        this.damage = damage;
        this.ttl = ttl;
        worldBounds = GlobalState.Instance.WorldCameraBounds;
        active = true;
    }

    public void Move(float x, float y)
	{
        tempPosition = Position;
        //tempPosition.x += x * Speed * Time.deltaTime;
        tempPosition.y += y * Speed * Time.deltaTime;
        Position = tempPosition;

        if (Position.y > worldBounds.max.y)
            active = false;
    }

    public void SetActive(bool activate)
	{
        this.active = activate;
	}
    
}
