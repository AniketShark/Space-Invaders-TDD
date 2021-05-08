using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover
{
	Vector3 Position { get; set; }
	float Speed { get; set; }
	void Move(float x, float y);
}
