﻿using UnityEngine;
using CustomMath;

public class TestQuaternion : MonoBehaviour
{
    private Quaternion unityQuaternion;
    private Quaternion unityQuaternion2;
    private MyQuaternion myQuaternion;
    private MyQuaternion myQuaternion2;

    void Start()
    {
        unityQuaternion = new Quaternion(3, 5, 0, 1);
        unityQuaternion2 = new Quaternion(1, 0, 0, 1);
        myQuaternion = new MyQuaternion(3, 5, 0, 1);
        myQuaternion2 = new MyQuaternion(1, 0, 0, 1);

        myQuaternion = MyQuaternion.AngleAxis(45, Vec3.Up);
        unityQuaternion = Quaternion.AngleAxis(45, Vec3.Up);
        //Quaternion.
        //MyQuaternion.i
        Debug.Log("Unity quaternion:" + unityQuaternion);
        Debug.Log("--------------------------------");
        Debug.Log("My quaternion:" + myQuaternion);
        //Debug.Log("Unity quaternion DOT:" + Quaternion.Dot(unityQuaternion,unityQuaternion2));
        //Debug.Log("My quaternion DOT:" + MyQuaternion.Dot(myQuaternion, myQuaternion2));
        //Debug.Log("--------------------------------");
        //Debug.Log("Unity quaternion product:" + (unityQuaternion * unityQuaternion2).ToString());
        //Debug.Log("My quaternion product:" + (myQuaternion * myQuaternion2).ToString());
        //Debug.Log("--------------------------------");
    }
}
