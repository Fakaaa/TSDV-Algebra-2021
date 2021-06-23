using System;
using UnityEngine;

namespace CustomMath
{
    [Serializable]
    public struct Mat4X4 : IEquatable<Mat4X4>
    {
        public float m00;
        public float m01;
        public float m02;
        public float m03; // Columns
        public float m10; // 0   1   2   3  
        public float m11; // -   -   -   -
        public float m12; //|00, 01, 02, 03 | - 0
        public float m13; //|10, 11, 12, 13 | - 1 Rows
        public float m20; //|20, 21, 22, 23 | - 2
        public float m21; //|30, 31, 32, 33 | - 3
        public float m22; 
        public float m23;
        public float m30;
        public float m31;
        public float m32;
        public float m33;
    
        public Vector4 GetColumn(int index)
        {
            if(index >= 0 && index <= 3)
            {
                Vector4 column = Vector4.zero;
                switch (index)
                {
                    case 0:
                        column = new Vector4(m00, m10, m20, m30);
                        break;
                    case 1:
                        column = new Vector4(m01, m11, m21, m31);
                        break;
                    case 2:
                        column = new Vector4(m02, m12, m22, m32);
                        break;
                    case 3:
                        column = new Vector4(m03, m13, m23, m33);
                        break;
                }
                return column;
            }
            else
            {
                Debug.LogError("Invalid index: Out of range");
                return Vector4.zero;
            }
        }
        public Vector4 GetRow(int index)
        {
            if (index >= 0 && index <= 3)
            {
                Vector4 column = Vector4.zero;
                switch (index)
                {
                    case 0:
                        column = new Vector4(m00, m01, m02, m03);
                        break;
                    case 1:
                        column = new Vector4(m10, m11, m12, m13);
                        break;
                    case 2:
                        column = new Vector4(m20, m21, m22, m23);
                        break;
                    case 3:
                        column = new Vector4(m30, m31, m32, m33);
                        break;
                }
                return column;
            }
            else
            {
                Debug.LogError("Invalid index: Out of range");
                return Vector4.zero;
            }
        }
        public static Mat4X4 identity
        {
            get
            {
                return new Mat4X4(new Vector4(1, 0, 0, 0), new Vector4(0, 1, 0, 0), new Vector4(0, 0, 1, 0), new Vector4(0, 0, 0, 1));
            }
        }
        public static Mat4X4 zero
        {
            get
            {
                return new Mat4X4(new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
            }
        }
        public Mat4X4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            //X
            m00 = column0.x; 
            m01 = column1.x; 
            m02 = column2.x; 
            m03 = column3.x; 
            //Y
            m10 = column0.y; 
            m11 = column1.y; 
            m12 = column2.y; 
            m13 = column3.y;
            //Z
            m20 = column0.z;    //       Columns
            m21 = column1.z;    //       0   1   2   3  
            m22 = column2.z;    //       -   -   -   -
            m23 = column3.z;    //      |00, 01, 02, 03 | - 0
            //W                 //      |10, 11, 12, 13 | - 1 Rows
            m30 = column0.w;    //      |20, 21, 22, 23 | - 2
            m31 = column1.w;    //      |30, 31, 32, 33 | - 3
            m32 = column2.w;
            m33 = column3.w;
        }
        public static Mat4X4 Translate(Vector3  vec)
        {
            Mat4X4 matTrans = identity;

            Vector4 vecTranslate = new Vector4(vec.x + matTrans.m03, vec.y + matTrans.m13, vec.z + matTrans.m23, 1);

            matTrans.m03 = vecTranslate.x;
            matTrans.m13 = vecTranslate.y;
            matTrans.m23 = vecTranslate.z;
            matTrans.m33 = vecTranslate.w;

            return matTrans;
        }
        public Mat4X4 transpose
        {
            get
            {
                Mat4X4 matT = new Mat4X4(new Vector4(m00, m01, m02, m03), new Vector4(m10, m11, m12, m13), new Vector4(m20, m21, m22, m23), new Vector4(m30, m31, m32, m33));
                return matT;
            }
        }
        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Mat4X4)) return false;
            return Equals((Mat4X4)other);
        }
        public bool Equals(Mat4X4 other)
        {
            if (GetColumn(0).Equals(other.GetColumn(0)) && GetColumn(1).Equals(other.GetColumn(1)) &&
                GetColumn(2).Equals(other.GetColumn(2)) && GetColumn(3).Equals(other.GetColumn(3)))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return GetColumn(0).GetHashCode() ^ (GetColumn(1).GetHashCode() << 2) ^ (GetColumn(2).GetHashCode() >> 2);
        }
        #endregion
    }
}