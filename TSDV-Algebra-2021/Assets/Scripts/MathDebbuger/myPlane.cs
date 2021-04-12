using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomMath
{
    [Serializable]
    public struct myPlane
    {
        #region Variables
        public Vec3 normal;
        public Vec3 point;
        public float distance;
        public Vec3 a;
        public Vec3 b;
        public Vec3 c;
        #endregion

        #region Functions
       // public myPlane(Vec3 inNormal, Vec3 inPloint)
       // {
       //     normal = inNormal;
       //     point = inPloint;
       // }
       // public myPlane(Vec3 inNormal, float d)
       // {
       //     normal = inNormal;
       //     distance = d;
       // }
       // public myPlane(Vec3 inA, Vec3 inB, Vec3 inC)
       // {
       //     a = inA;
       //     b = inB;
       //     c = inC;
       // }
        #endregion
    }
}