using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomMath
{
    [Serializable]
    public struct myPlane
    {
        #region Propierties

        public Vec3 normal { get; set; }
        public float distance { get; set; }
        public myPlane flipped
        {
            get
            {
                return new myPlane(-normal, -normal * distance);
            }
        }
        #endregion

        #region Functions
        //Constructor de Plano definido por una normal y un punto
        public myPlane(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal;
            distance = -Vec3.Dot(normal, inPoint);     
        }

        public void SetNormalAndPoint(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal;
            distance = -Vec3.Dot(normal, inPoint);
        }
        //Constructor de Plano definido por 3 puntos, 2 sobre la misma linea y uno no colineal
        public myPlane(Vec3 inA, Vec3 inB, Vec3 inC)
        {
            Vec3 line1 = inB-inA;
            Vec3 line2 = inC-inA;   

            normal = Vec3.Cross(line1, line2).normalized;
            distance = -Vec3.Dot(normal, inA);
        }
        public void Set3Points(Vec3 inA, Vec3 inB, Vec3 inC)
        {
            Vec3 line1 = inB - inA;
            Vec3 line2 = inC - inA;   

            normal = Vec3.Cross(line1, line2).normalized;
            distance = -Vec3.Dot(normal, inA);
        }
        public void Translate(Vec3 vec)
        {
            Vec3 aux;
            aux = (normal * distance + vec);
            distance = Vec3.Dot(normal, aux);
        }
        public float GetDistanceToThePoint(Vec3 point)
        {
            return Vec3.Dot(normal,point) + distance;
        }
        public bool GetSide(Vec3 point)
        {
            return GetDistanceToThePoint(point) > 0;
        }

        public bool SameSide(Vec3 point1, Vec3 point2)
        {
            if(GetSide(point1) == GetSide(point2))
                return true;
            else
                return false;
        }
        public Vec3 ClosestPointInPlane(Vec3 point)
        {
            return (point - normal * GetDistanceToThePoint(point));
        }
        public void Flip()
        {
            normal = -normal;
            distance = -distance;
        }
        public override string ToString()
        {
            return "normal: "+ normal.x + "|" + normal.y + "|" + normal.z + 
                " / distance:" + distance;
        }
        #endregion
    }
}