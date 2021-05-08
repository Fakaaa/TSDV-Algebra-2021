using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class CreateFrustrum : MonoBehaviour
{
    public myPlane far;
    public myPlane near;
    public myPlane left;
    public myPlane right;
    public myPlane top;
    public myPlane bot;

    [SerializeField] GameObject prefabPoint;
    [SerializeField] GameObject[] pointsFrustrum;

    [SerializeField] public List<Vec3> initialPoints;

    [SerializeField] private Vec3[] pointsToVec3;
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
            pointsFrustrum[i] = Instantiate(prefabPoint, initialPoints[i], transform.rotation, transform);
            pointsFrustrum[i].name = "Point" + i.ToString();
        }

        for (int i = 0; i < pointsToVec3.Length; i++)
        {
            pointsToVec3[i] = new Vec3(pointsFrustrum[i].transform.position);
        }

        near = new myPlane(pointsToVec3[0], pointsToVec3[1], pointsToVec3[3]);
        right = new myPlane(pointsToVec3[5], pointsToVec3[4], pointsToVec3[3]);
        left = new myPlane(pointsToVec3[2], pointsToVec3[7], pointsToVec3[6]);
        bot = new myPlane(pointsToVec3[2], pointsToVec3[3], pointsToVec3[4]);
        top = new myPlane(pointsToVec3[5], pointsToVec3[6], pointsToVec3[0]);
        far = new myPlane(pointsToVec3[6], pointsToVec3[5], pointsToVec3[4]);

        /*
        far = new Plane(points[4], points[6]);
        near = new Plane(points[0], points[2]);
        top = new Plane(points[3], points[6]);
        bot = new Plane(points[0], points[5]);
        left = new Plane(points[0], points[7]);
        right = new Plane(points[1], points[6]);
        */
    }

    void Update()
    {
        RenderObjects();

        UpdatePointsPositions();

        UpdateFrustrumPlanes();
    }

    private void OnDrawGizmos()
    {
        
    }

    public void UpdatePointsPositions()
    {
        for (int i = 0; i < pointsToVec3.Length; i++)
        {
            pointsToVec3[i].Set(pointsFrustrum[i].transform.position.x, pointsFrustrum[i].transform.position.y, pointsFrustrum[i].transform.position.z);
        }
    }

    public void UpdateFrustrumPlanes()
    {
        near.Set3Points(pointsToVec3[0], pointsToVec3[1], pointsToVec3[3]);

        right.Set3Points(pointsToVec3[5], pointsToVec3[4], pointsToVec3[3]);

        left.Set3Points(pointsToVec3[2], pointsToVec3[7], pointsToVec3[6]);

        bot.Set3Points(pointsToVec3[2], pointsToVec3[3], pointsToVec3[4]);

        top.Set3Points(pointsToVec3[5], pointsToVec3[6], pointsToVec3[0]);

        far.Set3Points(pointsToVec3[6], pointsToVec3[5], pointsToVec3[4]);

    }

    public void RenderObjects()
    {
        foreach (CanBeRender renderThing in objectsInScene)
        {

            upBool = top.GetSide(renderThing.getRenderPos());
            downBool = bot.GetSide(renderThing.getRenderPos());
            leftBool = left.GetSide(renderThing.getRenderPos());
            rightBool = right.GetSide(renderThing.getRenderPos());
            farBool = far.GetSide(renderThing.getRenderPos());
            nearBool = near.GetSide(renderThing.getRenderPos());

            Debug.Log("Plano top :" + top.GetSide(renderThing.getRenderPos()));
            Debug.Log("Plano bot :" + bot.GetSide(renderThing.getRenderPos()));
            Debug.Log("Plano left :" + left.GetSide(renderThing.getRenderPos()));
            Debug.Log("Plano right :" + right.GetSide(renderThing.getRenderPos()));
            Debug.Log("Plano far :" + far.GetSide(renderThing.getRenderPos()));
            Debug.Log("Plano near :" + near.GetSide(renderThing.getRenderPos()));

            if (nearBool && farBool && upBool && downBool && leftBool && rightBool)
                renderThing.RenderMe(true);
            else
                renderThing.RenderMe(false);

        }
    }
}
