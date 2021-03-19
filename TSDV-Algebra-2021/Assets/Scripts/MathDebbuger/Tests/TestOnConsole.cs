using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class TestOnConsole : MonoBehaviour
{
    void Start()
    {
        Vec3 vectorVec3 = new Vec3(2,2,2);
        Vector3 vectororiginal = new Vec3(2,2,2);

        Debug.Log("Vector Original: " + vectororiginal);
        Debug.Log("Vector Vec3: " + vectorVec3);

        Debug.Log("Vector Original magnitud: " + vectororiginal.magnitude);
        Debug.Log("Vector Vec3 magnitud: " + vectorVec3.magnitude);
    }

    void Update()
    {

    }
}
