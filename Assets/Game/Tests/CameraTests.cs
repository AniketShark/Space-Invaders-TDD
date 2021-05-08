using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraTests
{
    [Test]
    public void Camera_Exists()
    {
        Assert.IsNotNull(Camera.main);
    }

    [Test]
    public void Camera_Configuration()
    {
        Assert.AreEqual(true,Camera.main.orthographic);
        Assert.AreEqual(10,Camera.main.orthographicSize);
        Assert.AreEqual(Vector3.forward * -5, Camera.main.transform.position);
    }

}
