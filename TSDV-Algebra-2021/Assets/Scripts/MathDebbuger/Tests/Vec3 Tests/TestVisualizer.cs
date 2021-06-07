using EjerciciosAlgebra;
using UnityEngine;
using CustomMath;

public class TestVisualizer : MonoBehaviour
{
    enum Ejercicio
    {
        Uno, Dos,
        Tres, Cuatro,
        Cinco, Seis,
        Siete, Ocho,
        Nueve, Diez
    }

    [SerializeField] Ejercicio ejercicio;
    [SerializeField] Color vectorColor;
    [SerializeField] Vec3 vectorA;
    [SerializeField] Vec3 vectorB;
    private Vec3 vectorResult = Vec3.Zero;
    private float timerToLerp = 0;

    void Start()
    {
        VectorDebugger.AddVector(vectorA,"A");
        VectorDebugger.AddVector(vectorB,"B");
        VectorDebugger.AddVector(vectorResult,"R");
        VectorDebugger.UpdateColor("A", Color.white);
        VectorDebugger.UpdateColor("B", Color.white);
        VectorDebugger.UpdateColor("R", vectorColor);
        VectorDebugger.EnableCoordinates();
        VectorDebugger.EnableEditorView();
    }

    void Update()
    {
        timerToLerp += Time.deltaTime;

        switch (ejercicio)
        {
            case Ejercicio.Uno:

                vectorResult = vectorA + vectorB;

                break;
            case Ejercicio.Dos:

                vectorResult = Vec3.Min(vectorA, vectorB);

                break;
            case Ejercicio.Tres:

                vectorResult = vectorA * vectorB.x;

                break;
            case Ejercicio.Cuatro:

                vectorResult = Vec3.Cross(vectorA, vectorB);

                break;
            case Ejercicio.Cinco:

                vectorResult = Vec3.Lerp(vectorA, vectorB, timerToLerp);

                if (timerToLerp > 1)
                    timerToLerp = 0;

                break;
            case Ejercicio.Seis:

                vectorResult = Vec3.Max(vectorA, vectorB);

                break;
            case Ejercicio.Siete:

                vectorResult = Vec3.Project(vectorA, vectorB);

                break;
            case Ejercicio.Ocho: //No se muy bien que es

                Vec3 sumVecs = vectorA + vectorB;

                vectorResult =  sumVecs.normalized * Vec3.Distance(vectorA, vectorB);

                break;
            case Ejercicio.Nueve: //Es reflect pero a veces funca y otras no

                vectorResult = Vec3.Reflect(vectorA, vectorB);
                
                break;
            case Ejercicio.Diez: 

                vectorResult = Vec3.LerpUnclamped(vectorA, vectorB, timerToLerp);
                break;
            default:
                break;
        }

        VectorDebugger.UpdatePosition("A", vectorA);
        VectorDebugger.UpdatePosition("B", vectorB);
        VectorDebugger.UpdatePosition("R", vectorResult);
    }
}
