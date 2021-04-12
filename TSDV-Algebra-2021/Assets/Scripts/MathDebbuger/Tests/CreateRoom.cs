using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour
{
    public Plane up;
    public Plane down;
    public Plane left;
    public Plane rigth;
    public Plane front;
    public Plane back;

    [SerializeField] Vector3 pointToCheck;
    [SerializeField] GameObject cubePoint;

    private bool upBool;
    private bool downBool;
    private bool leftBool;
    private bool rightBool;
    private bool frontBool;
    private bool backBool;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 point1 = new Vector3(-5,-5,-5);
        Vector3 point2 = new Vector3( 5,-5,-5);
        Vector3 point3 = new Vector3( 5, 5,-5);
        Vector3 point4 = new Vector3(-5, 5,-5);
        Vector3 point5 = new Vector3(-5,-5, 5);
        Vector3 point6 = new Vector3( 5,-5, 5);
        Vector3 point7 = new Vector3( 5, 5, 5);
        Vector3 point8 = new Vector3(-5, 5, 5);

        front = new Plane(point5, point7);
        back = new Plane(point1, point3);
        up = new Plane(point4, point7);
        down = new Plane(point1, point6);
        left = new Plane(point1, point8);
        rigth = new Plane(point2, point7);
    }

    void Update()
    {
        upBool = up.GetSide(cubePoint.transform.position);
        downBool = down.GetSide(cubePoint.transform.position);
        leftBool = left.GetSide(cubePoint.transform.position);
        rightBool = rigth.GetSide(cubePoint.transform.position);
        frontBool = front.GetSide(cubePoint.transform.position);
        backBool = back.GetSide(cubePoint.transform.position);

        if ( upBool && backBool && leftBool && rightBool && downBool && frontBool)
        {
            Debug.Log("El cubo esta dentro de la habitacion");
        }
        else
        {
            Debug.Log("El cubo esta fuera de la habitacion");
        }
    }
}
