using EjerciciosAlgebra;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
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
                break;
            case Ejercicio.Cinco:
                break;
            case Ejercicio.Seis:
                break;
            case Ejercicio.Siete:
                break;
            case Ejercicio.Ocho:
                break;
            case Ejercicio.Nueve:
                break;
            case Ejercicio.Diez:
                break;
            default:
                break;
        }

        VectorDebugger.UpdatePosition("A", vectorA);
        VectorDebugger.UpdatePosition("B", vectorB);
        VectorDebugger.UpdatePosition("R", vectorResult);
    }
}
