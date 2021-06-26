using System.Collections.Generic;
using EjerciciosAlgebra;
using UnityEngine;
using CustomMath;

public class EjerciciosQuat : MonoBehaviour
{
    [SerializeField]
    public enum Ejercicio
    {
        Uno,
        Dos,
        Tres
    }
    public Ejercicio ejercicio;
    [SerializeField] public float Angle;

    private Vec3 vectorEejer1;

    private List<Vector3> vectoresEjer2 = new List<Vector3>();
    private List<Vector3> vectoresEjer3 = new List<Vector3>();

    private void Start()
    {
        vectorEejer1 = new Vec3(9, 0, 0);
        VectorDebugger.AddVector(vectorEejer1, Color.red, "vec");
        vectoresEjer2.Add(new Vec3(10, 0, 0));
        vectoresEjer2.Add(new Vec3(10, 10, 0));
        vectoresEjer2.Add(new Vec3(20, 10, 0));
        VectorDebugger.AddVectorsSecuence(vectoresEjer2, false, Color.blue, "vectores");

        vectoresEjer3.Add(new Vec3(10, 0, 0));
        vectoresEjer3.Add(new Vec3(10, 10, 0));
        vectoresEjer3.Add(new Vec3(20, 10, 0));
        vectoresEjer3.Add(new Vec3(20, 20, 0));
        VectorDebugger.AddVectorsSecuence(vectoresEjer3, false, Color.yellow, "vectores2");

        VectorDebugger.EnableCoordinates();
    }
    void FixedUpdate()
    {
        switch (ejercicio)  
        {
            case Ejercicio.Uno:
                vectorEejer1 = MyQuaternion.Euler(new Vec3(0,Angle, 0)) * vectorEejer1;
                VectorDebugger.UpdatePosition("vec", vectorEejer1);
                VectorDebugger.DisableEditorView("vectores2");
                VectorDebugger.DisableEditorView("vectores");
                VectorDebugger.EnableEditorView("vec");
                break;
            case Ejercicio.Dos:
                for (int i = 0; i < vectoresEjer2.Count; i++){
                    vectoresEjer2[i] = MyQuaternion.Euler(new Vec3(0, Angle, 0)) * new Vec3(vectoresEjer2[i]);
                }
                VectorDebugger.UpdatePositionsSecuence("vectores", vectoresEjer2);
                VectorDebugger.DisableEditorView("vectores2");
                VectorDebugger.EnableEditorView("vectores");
                VectorDebugger.DisableEditorView("vec");
                break;
            case Ejercicio.Tres:
                for (int i = 0; i < vectoresEjer3.Count; i++){
                    if((i % 2) != 0)
                    {
                        if(i == 3)
                            vectoresEjer3[i] = MyQuaternion.Euler(new Vec3(-Angle, -Angle, 0)) * new Vec3(vectoresEjer3[i]);
                        else
                            vectoresEjer3[i] = MyQuaternion.Euler(new Vec3(Angle, Angle, 0)) * new Vec3(vectoresEjer3[i]);
                    }
                }
                Matrix4x4 se = Matrix4x4.identity;
                VectorDebugger.DisableEditorView("vec");
                VectorDebugger.DisableEditorView("vectores");
                VectorDebugger.EnableEditorView("vectores2");
                VectorDebugger.UpdatePositionsSecuence("vectores2", vectoresEjer3);
                break;
        }
    }
}
