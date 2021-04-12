using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFrustrum : MonoBehaviour
{
    public Plane front;
    public Plane back;
    public Plane left;
    public Plane right;
    public Plane top;
    public Plane bot;

    [SerializeField] GameObject prefabPoint;
    [SerializeField] GameObject [] pointsFrustrum;

    [SerializeField] Vector3 point1;
    [SerializeField] Vector3 point2;
    [SerializeField] Vector3 point3;
    [SerializeField] Vector3 point4;
    [SerializeField] Vector3 point5;
    [SerializeField] Vector3 point6;
    [SerializeField] Vector3 point7;
    [SerializeField] Vector3 point8;
    void Start()
    {
        point1 = new Vector3(-2,-1,-1);
        point2 = new Vector3( 2,-1,-1);
        point3 = new Vector3( 2, 1,-1);
        point4 = new Vector3(-2, 1,-1);
        point5 = new Vector3(-5,-5, 15);
        point6 = new Vector3( 5,-5, 15);
        point7 = new Vector3( 5, 5, 15);
        point8 = new Vector3(-5, 5, 15);

        front = new Plane(point5, point7);
        back = new Plane(point1, point3);
        top = new Plane(point4, point7);
        bot = new Plane(point1, point6);
        left = new Plane(point1, point8);
        right = new Plane(point2, point7);

        for (int i = 0; i < pointsFrustrum.Length; i++)
        {
            pointsFrustrum[i] = Instantiate(prefabPoint);
        }
    }

    void Update()
    {
        if(pointsFrustrum[0]!= null)
        pointsFrustrum[0].gameObject.transform.position = point1;
        if(pointsFrustrum[1]!= null)
        pointsFrustrum[1].gameObject.transform.position = point2;
        if(pointsFrustrum[2]!= null)
        pointsFrustrum[2].gameObject.transform.position = point3;
        if(pointsFrustrum[3]!= null)
        pointsFrustrum[3].gameObject.transform.position = point4;
        if(pointsFrustrum[4]!= null)
        pointsFrustrum[4].gameObject.transform.position = point5;
        if(pointsFrustrum[5]!= null)
        pointsFrustrum[5].gameObject.transform.position = point6;
        if(pointsFrustrum[6]!= null)
        pointsFrustrum[6].gameObject.transform.position = point7;
        if(pointsFrustrum[7]!= null)
        pointsFrustrum[7].gameObject.transform.position = point8;
    }
}
