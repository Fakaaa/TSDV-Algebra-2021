using UnityEngine;
using CustomMath;

public class TestMyPlane : MonoBehaviour
{
    private Plane planeUnity3Points;
    private Plane planeUnityNormPoint;
    private myPlane myPlane3Points;
    private myPlane myPlaneNormPoint;

    [SerializeField] private Vec3 pointToCheck;
    [SerializeField] private Vector3 pointToCheckUnity;

    private Vec3 inNormalTest;
    private Vec3 pointPlane;

    private Vec3 pointA;
    private Vec3 pointB;
    private Vec3 pointC;

    void Start()
    {
        pointA = new Vec3(5, 0, 0);
        pointB = new Vec3(10,0, 0);
        pointC = new Vec3(3, 5, 0);

        //Unity plains
        planeUnity3Points = new Plane(pointA, pointB,pointC);
        planeUnityNormPoint = new Plane(Vector3.forward, pointA);
        //Facu plains
        myPlane3Points = new myPlane(pointA, pointB, pointC);
        myPlaneNormPoint = new myPlane(Vec3.Forward, pointA);

        Matrix4x4 aka;
    }

    void Update()
    {
        Debug.Log("-----------Unity Plane------------");
        Debug.Log("Plano unity 3 puntos, normal= " + planeUnity3Points.normal);
        Debug.Log("Plano unity Punto y normal, normal= " + planeUnityNormPoint.normal);

        Debug.Log("Plano unity 3 puntos, distance= " + planeUnity3Points.distance);
        Debug.Log("Plano unity Punto y normal, distance = " + planeUnityNormPoint.distance);

        Debug.Log("Plano unity 3 puntos, Flipped = " + planeUnity3Points.flipped);
        Debug.Log("Plano unity Punto y normal,Flipped = " + planeUnityNormPoint.flipped);

        Debug.Log("Plano unity 3 puntos, Distance to point = " + planeUnity3Points.GetDistanceToPoint(pointToCheckUnity));
        Debug.Log("Plano unity Punto y normal, Distance to point = " + planeUnityNormPoint.GetDistanceToPoint(pointToCheckUnity));

        Debug.Log("------------My Plane------------");
        Debug.Log("Plano mio 3 puntos, normal = " + myPlane3Points.normal);
        Debug.Log("Plano mio Punto y normal, normal = " + myPlaneNormPoint.normal);

        Debug.Log("Plano mio 3 puntos, distance = " + myPlane3Points.distance);
        Debug.Log("Plano mio Punto y normal, distance = " + myPlaneNormPoint.distance);

        Debug.Log("Plano mio 3 puntos, Flipped = " + myPlane3Points.flipped);
        Debug.Log("Plano mio Punto y normal, Flipped = " + myPlaneNormPoint.flipped);

        Debug.Log("Plano mio 3 puntos, Distance to point = " + myPlane3Points.GetDistanceToThePoint(pointToCheck));
        Debug.Log("Plano mio Punto y normal, Distance to point = " + myPlane3Points.GetDistanceToThePoint(pointToCheck));

        Debug.Log("----------------------------------");
    }
}
