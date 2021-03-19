using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class TestOnConsole : MonoBehaviour
{
    void Start()
    {
        Vec3 vec3_1 = new Vec3(2, 2, 2);
        Vec3 vecToDot = new Vec3(4, 6, 8);
        Vector3 vectororiginal = new Vec3(2, 2, 2);

        #region //Visualizar vector original y nuestro
        Debug.Log("Vector Original: " + vectororiginal);
        Debug.Log("Vector Vec3: " + vec3_1);
        #endregion

        #region //Visualizar magnitud vector original y nuestro
        Debug.Log("Vector Original magnitud: " + vectororiginal.magnitude);
        Debug.Log("Vector Vec3 magnitud: " + vec3_1.magnitude);
        #endregion

        #region//Visualizar producto punto vector original y nuestro
        Debug.Log("Producto punto Original vector: " + Vector3.Dot(vectororiginal, vecToDot));
        Debug.Log("Producto punto Vec3: " + Vec3.Dot(vec3_1, vecToDot));
        #endregion
    }

    void Update()
    {

    }
}
