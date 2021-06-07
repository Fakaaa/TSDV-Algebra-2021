using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPoints : MonoBehaviour
{
    [SerializeField] GameObject pointRef;

    private LineRenderer myLine;
    void Start()
    {
        myLine = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        pointRef = FindObjectOfType<CreateFrustrum>().gameObject;

        myLine.SetPosition(0, transform.position);
        myLine.SetPosition(1, pointRef.transform.position);
    }
}
