using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class TestLerp : MonoBehaviour
{
    public GameObject start;
    public GameObject toReach;

    public float distanceElapsed;
    private Vec3 a;
    private Vec3 b;

    private bool reachMax;
    private bool reachMin;

    private void Start()
    {
        a.x = start.transform.position.x;
        a.y = start.transform.position.y;
        a.z = start.transform.position.z;
        b.x = toReach.transform.position.x;
        b.y = toReach.transform.position.y;
        b.z = toReach.transform.position.z;

        reachMax = false;
        reachMin = false;
    }
    void Update()
    {
        this.transform.position = new Vec3(Vec3.Lerp(b, a, distanceElapsed));

        #region // Move in time automatic

        if (reachMin && !reachMax)
            distanceElapsed += 1 * Time.deltaTime;
        if (reachMax && !reachMin)
            distanceElapsed -= 1 * Time.deltaTime;
        if (distanceElapsed <= 0)
        {
            reachMin = true;
            reachMax = false;
        }
        else if (distanceElapsed >= 1)
        {
            reachMin = false;
            reachMax = true;
        }
        #endregion

        #region // Move manually
        if (Input.GetKey(KeyCode.D))
        {
            if (distanceElapsed < 1)
                distanceElapsed += 2 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (distanceElapsed > 0)
                distanceElapsed -= 2 * Time.deltaTime;
        }
        #endregion
    }
}
