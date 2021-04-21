using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class CreateFrustrum : MonoBehaviour
{
    public Plane front;
    public Plane back;
    public Plane left;
    public Plane right;
    public Plane top;
    public Plane bot;

    [SerializeField] GameObject prefabPoint;
    [SerializeField] GameObject[] pointsFrustrum;

    [SerializeField] public List<Vec3> points;

    [SerializeField] public List<int> objectsInScene;

    public int initID;
    void Start()
    {
        //for (int i = 0; i < points.Count; i++)
        //{
        //    Vector3Debugger.AddVector(points[i], i.ToString());
        //    Vector3Debugger.UpdateColor(i.ToString(), Color.white);
        //
        //}
        //Vector3Debugger.EnableEditorView();


        objectsInScene.Clear();
        initID = -1;
        objectsInScene.Add(initID);

        front = new Plane(points[4], points[6]);
        back = new Plane(points[0], points[2]);
        top = new Plane(points[3], points[6]);
        bot = new Plane(points[0], points[5]);
        left = new Plane(points[0], points[7]);
        right = new Plane(points[1], points[6]);

        for (int i = 0; i < pointsFrustrum.Length; i++)
        {
            pointsFrustrum[i] = Instantiate(prefabPoint, points[i], transform.rotation, transform);
            pointsFrustrum[i].name = "Point" + i.ToString();
        }
    }

    void Update()
    {
        //Vec3 papaPos = new Vec3(transform.position + transform.forward);

        //Debug.DrawLine(points[0] + papaPos, points[1] + papaPos, Color.red);// Back
        //Debug.DrawLine(points[1] + papaPos, points[2] + papaPos, Color.red);// Back
        //Debug.DrawLine(points[2] + papaPos, points[3] + papaPos, Color.red);// Back
        //Debug.DrawLine(points[3] + papaPos, points[0] + papaPos, Color.red);// Back
        ////----------
        //Debug.DrawLine(points[4] + papaPos, points[5] + papaPos, Color.green);// Front
        //Debug.DrawLine(points[5] + papaPos, points[6] + papaPos, Color.green);// Front
        //Debug.DrawLine(points[6] + papaPos, points[7] + papaPos, Color.green);// Front
        //Debug.DrawLine(points[7] + papaPos, points[4] + papaPos, Color.green);// Front
        ////----------
        //Debug.DrawLine(points[0] + papaPos, points[4] + papaPos, Color.yellow);// Sides
        //Debug.DrawLine(points[3] + papaPos, points[7] + papaPos, Color.yellow);// Sides
        //Debug.DrawLine(points[1] + papaPos, points[5] + papaPos, Color.yellow);// Sides
        //Debug.DrawLine(points[2] + papaPos, points[6] + papaPos, Color.yellow);// Sides

        //for (int i = 0; i < points.Count; i++)
        //{
        //    points[i] = new Vec3(pointsFrustrum[i].transform.position);
        //    Vector3Debugger.UpdatePosition(i.ToString(), points[i]);
        //}
    }

    public void SetVec3(float newx, float newy, float newz, ref Vec3 vec)
    {
        vec.x = newx;
        vec.y = newy;
        vec.z = newz;
    }
}
