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

    [SerializeField] public List<CanBeRender> objectsInScene;

    public int initID;
    void Start()
    {
        objectsInScene.Clear();
        objectsInScene.Add(FindObjectOfType<CanBeRender>());
        


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
        
    }
    public void SetVec3(float newx, float newy, float newz, ref Vec3 vec)
    {
        vec.x = newx;
        vec.y = newy;
        vec.z = newz;
    }

    public void OnRender()
    {
        
    }
}
