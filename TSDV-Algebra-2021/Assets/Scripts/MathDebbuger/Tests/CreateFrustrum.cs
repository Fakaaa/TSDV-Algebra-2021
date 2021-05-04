using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class CreateFrustrum : MonoBehaviour
{
    public Plane far;
    public Plane near;
    public Plane left;
    public Plane right;
    public Plane top;
    public Plane bot;

    [SerializeField] GameObject prefabPoint;
    [SerializeField] GameObject[] pointsFrustrum;

    [SerializeField] public List<Vec3> points;

    [SerializeField] public CanBeRender[] objectsInScene;

    private bool upBool;
    private bool downBool;
    private bool leftBool;
    private bool rightBool;
    private bool farBool;
    private bool nearBool;

    void Start()
    {
        objectsInScene = FindObjectsOfType<CanBeRender>();

        for (int i = 0; i < pointsFrustrum.Length; i++)
        {
            pointsFrustrum[i] = Instantiate(prefabPoint, points[i], transform.rotation, transform);
            pointsFrustrum[i].name = "Point" + i.ToString();
        }

        far = new Plane(points[4], points[6]);
        near = new Plane(points[0], points[2]);
        top = new Plane(points[3], points[6]);
        bot = new Plane(points[0], points[5]);
        left = new Plane(points[0], points[7]);
        right = new Plane(points[1], points[6]);

        left.Flip();
        right.Flip();
        near.Flip();
    }

    void Update()
    {
        RenderObjects();

        UpdateFrustrumPlanes();
    }

    public void UpdateFrustrumPlanes()
    {
        far = new Plane(points[4], points[6]);
        near = new Plane(points[0], points[2]);
        top = new Plane(points[3], points[6]);
        bot = new Plane(points[0], points[5]);
        left = new Plane(points[0], points[7]);
        right = new Plane(points[1], points[6]);

        left.Flip();
        right.Flip();
        near.Flip();
    }

    public void RenderObjects()
    {
        foreach (CanBeRender renderThing in objectsInScene)
        {
            upBool = top.GetSide(renderThing.transform.position);
            downBool = bot.GetSide(renderThing.transform.position);
            leftBool = left.GetSide(renderThing.transform.position);
            rightBool = right.GetSide(renderThing.transform.position);
            farBool = far.GetSide(renderThing.transform.position);
            nearBool = near.GetSide(renderThing.transform.position);

            Debug.Log("Plano top :" + top.GetSide(renderThing.transform.position));
            Debug.Log("Plano bot :" + bot.GetSide(renderThing.transform.position));
            Debug.Log("Plano left :" + left.GetSide(renderThing.transform.position));
            Debug.Log("Plano right :" + right.GetSide(renderThing.transform.position));
            Debug.Log("Plano far :" + far.GetSide(renderThing.transform.position));
            Debug.Log("Plano near :" + near.GetSide(renderThing.transform.position));

            if (upBool && nearBool && leftBool && rightBool && downBool && farBool)
                renderThing.RenderMe(true);
            else
                renderThing.RenderMe(false);
        }
    }
}
