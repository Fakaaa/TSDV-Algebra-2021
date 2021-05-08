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
        public float distance;
        #endregion

        #region Functions
        public myPlane(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal.normalized;
            distance = -Vec3.Dot(normal, inPoint);      //Plano definido por una normal y un punto
        }
        public myPlane(Vec3 inA, Vec3 inB, Vec3 inC)
        {
            Vec3 line1 = inB-inA;
            Vec3 line2 = inC-inA;   //Plano definido por 3 puntos, 2 sobre la misma linea y uno no colineal

            normal = Vec3.Cross(line1, line2).normalized;
            distance = - Vec3.Dot(normal, inA);
        }

        public float GetDistanceToThePoint(Vec3 point)
        {
            return Vec3.Dot(normal,point) + distance;
        }



        #endregion
    }
}