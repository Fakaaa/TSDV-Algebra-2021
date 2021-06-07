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
        Vec3 vec3_2 = new Vec3(4, 2, 6);

        Vector3 vectororiginal_1 = new Vec3(2, 2, 2);
        Vector3 vectororiginal_2 = new Vec3(4, 2, 6);

        //Para producto punto
        Vec3 vecToDot = new Vec3(4, 6, 8);
        Vec3 vecToCross = new Vec3(2, 3, 6);
        #endregion

        #region //Visualizar vector original y nuestro
        Debug.Log("Coordenadas Vector3: " + vectororiginal_1);
        Debug.Log("Coordenadas Vec3: " + vec3_1);
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar magnitud vector original y nuestro
        Debug.Log("Vector3 magnitud: " + vectororiginal_1.magnitude);
        Debug.Log("Vec3 magnitud: " + vec3_1.magnitude);
        #endregion
        Debug.Log("------------------------------");
        #region//Visualizar producto punto vector original y nuestro
        Debug.Log("Producto punto Vector3: " + Vector3.Dot(vectororiginal_1, vecToDot));
        Debug.Log("Producto punto Vec3: " + Vec3.Dot(vec3_1, vecToDot));
        #endregion
        Debug.Log("------------------------------");
        #region//Visualizar producto cruz vector original y nuestro
        Debug.Log("Producto cruz Vector3: " + Vector3.Cross(vectororiginal_1, vecToCross));
        Debug.Log("Producto cruz Vec3: " + Vec3.Cross(vec3_1, vecToCross));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar distancia entre dos vectores
        Debug.Log("Distancia entre vectores Vector3 : " + Vector3.Distance(vectororiginal_1, vectororiginal_2));
        Debug.Log("Distancia entre vectores Vec3: " + Vec3.Distance(vec3_1, vec3_2));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar el angulo entre dos vectores
        Debug.Log("Angulo entre vectores (Vector3):" + Vector3.Angle(vectororiginal_1, vectororiginal_2));
        Debug.Log("Angulo entre vectores (Vec3):" + Vec3.Angle(vec3_1, vec3_2));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar magnitud clampeada
        Debug.Log("Magnitud clampeada vectores (Vector3):" + Vector3.ClampMagnitude(vectororiginal_1, 2));
        Debug.Log("Magnitud clampeada vectores (Vec3):" + Vec3.ClampMagnitude(vec3_1, 2));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar maximo entres dos Vectores
        Debug.Log("Maximo entre vectores (Vector3):" + Vector3.Max(vectororiginal_1, vectororiginal_2));
        Debug.Log("Maximo entre vectores (Vec3):" + Vec3.Max(vec3_1, vec3_2));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar minimo entres dos Vectores
        Debug.Log("Minimo entre vectores (Vector3):" + Vector3.Min(vectororiginal_1, vectororiginal_2));
        Debug.Log("Minimo entre vectores (Vec3):" + Vec3.Min(vec3_1, vec3_2));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar Projection
        Debug.Log("Projection (Vector3):" + Vector3.Project(vectororiginal_1, vectororiginal_2));
        Debug.Log("Projection (Vec3):" + Vec3.Project(vec3_1, vec3_2));
        #endregion
        Debug.Log("------------------------------");
        #region //Visualizar Reflect
        Debug.Log("Reflection (Vector3):" + Vector3.Reflect(vectororiginal_1, vectororiginal_2).normalized);
        Debug.Log("Reflection (Vec3):" + Vec3.Reflect(vec3_1, vec3_2).normalized);
        #endregion
    }
}
