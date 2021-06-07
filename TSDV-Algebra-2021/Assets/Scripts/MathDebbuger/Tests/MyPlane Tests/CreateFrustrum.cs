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

        near = new Plane(pointsFrustrum[0].transform.position, pointsFrustrum[1].transform.position,
            pointsFrustrum[2].transform.position);
        right = new Plane(pointsFrustrum[5].transform.position, pointsFrustrum[4].transform.position,
            pointsFrustrum[3].transform.position);
        left = new Plane(pointsFrustrum[6].transform.position, pointsFrustrum[7].transform.position,
            pointsFrustrum[2].transform.position);
        bot = new Plane(pointsFrustrum[7].transform.position, pointsFrustrum[4].transform.position,
            pointsFrustrum[3].transform.position);
        top = new Plane(pointsFrustrum[5].transform.position, pointsFrustrum[6].transform.position,
            pointsFrustrum[0].transform.position);
        far = new Plane(pointsFrustrum[6].transform.position, pointsFrustrum[5].transform.position,
            pointsFrustrum[4].transform.position);

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

        near.Set3Points(pointsFrustrum[0].transform.position, pointsFrustrum[1].transform.position,
            pointsFrustrum[2].transform.position);

        right.Set3Points(pointsFrustrum[5].transform.position, pointsFrustrum[4].transform.position,
            pointsFrustrum[3].transform.position);

        left.Set3Points(pointsFrustrum[6].transform.position, pointsFrustrum[7].transform.position,
            pointsFrustrum[2].transform.position);

        bot.Set3Points(pointsFrustrum[7].transform.position, pointsFrustrum[4].transform.position,
            pointsFrustrum[3].transform.position);

        top.Set3Points(pointsFrustrum[5].transform.position, pointsFrustrum[6].transform.position,
            pointsFrustrum[0].transform.position);

        far.Set3Points(pointsFrustrum[6].transform.position, pointsFrustrum[5].transform.position,
            pointsFrustrum[4].transform.position);

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

            if (nearBool && upBool && downBool && farBool && leftBool && rightBool)
                renderThing.RenderMe(true);
            else
                renderThing.RenderMe(false);
        }
    }
}
