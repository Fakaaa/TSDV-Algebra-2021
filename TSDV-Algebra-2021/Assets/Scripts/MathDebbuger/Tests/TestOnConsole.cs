using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class TestOnConsole : MonoBehaviour
{
    void Start()
    {
        #region // Vectores nuestros y de unity
        Vec3 vec3_1 = new Vec3(2, 2, 2);
        Vector3 vectororiginal = new Vec3(2, 2, 2);

        //Para producto punto
        Vec3 vecToDot = new Vec3(4, 6, 8);
        Vec3 vecToCross = new Vec3(2, 3, 6);
        #endregion

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

        #region//Visualizar producto cruz vector original y nuestro
        Debug.Log("Producto cruz Original vector: " + Vector3.Cross(vectororiginal, vecToCross));
        Debug.Log("Producto cruz Vec3: " + Vec3.Cross(vec3_1, vecToCross));
        #endregion
    }

    void Update()
    {

    }
}
