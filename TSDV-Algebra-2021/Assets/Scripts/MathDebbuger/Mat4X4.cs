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

        public float this[int index]
        {
            get
            {
                float val = -1;
                switch (index)
                {
                    case 0: val = m00;
                        break;
                    case 1: val = m10;
                        break;
                    case 2: val = m20;
                        break;
                    case 3: val = m30;
                        break;
                    case 4: val = m01;
                        break;
                    case 5: val = m11;
                        break;
                    case 6: val = m21;
                        break;
                    case 7: val = m31;
                        break;
                    case 8: val = m02;
                        break;
                    case 9: val = m12;
                        break;
                    case 10: val = m22;
                        break;
                    case 11: val = m32;
                        break;
                    case 12: val = m03;
                        break;
                    case 13: val = m13;
                        break;
                    case 14: val = m23;
                        break;
                    case 15: val = m33;
                        break;
                }
                if (val == -1)
                    throw new IndexOutOfRangeException("Invalid index");

                return val;
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
        public Mat4X4 transpose
        {
            get
            {
                //Columns where rows and rows where columns
                Mat4X4 matT = new Mat4X4(new Vector4(m00, m01, m02, m03), new Vector4(m10, m11, m12, m13), new Vector4(m20, m21, m22, m23), new Vector4(m30, m31, m32, m33));
                return matT;
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
        public Vector4 GetColumn(int index)
        {
            if (index >= 0 && index <= 3)
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
        public void SetRow(int index, Vector4 row)
        {
            if (index >= 0 && index <= 3)
            {
                switch (index)
                {
                    case 0:
                        m00 = row.x; m01 = row.y; m02 = row.z; m03 = row.w;
                        break;
                    case 1:
                        m10 = row.x; m11 = row.y; m12 = row.z; m13 = row.w;
                        break;
                    case 2:
                        m20 = row.x; m21 = row.y; m22 = row.z; m23 = row.w;
                        break;
                    case 3:
                        m30 = row.x; m31 = row.y; m32 = row.z; m33 = row.w;
                        break;
                }
            }
            else
            {
                Debug.LogError("Error: index out of range.");
            }
        }
        public void SetColumn(int index, Vector4 column)
        {
            if (index >= 0 && index <= 3)
            {
                switch (index)
                {
                    case 0:
                        m00 = column.x; m10 = column.y; m20 = column.z; m30 = column.w;
                        break;
                    case 1:
                        m01 = column.x; m11 = column.y; m21 = column.z; m31 = column.w;
                        break;
                    case 2:
                        m02 = column.x; m12 = column.y; m22 = column.z; m32 = column.w;
                        break;
                    case 3:
                        m03 = column.x; m13 = column.y; m23 = column.z; m33 = column.w;
                        break;
                }
            }
            else
            {
                Debug.LogError("Error: index out of range.");
            }
        }
        public static Mat4X4 Translate(Vector3 vec)
        {
            Mat4X4 matTrans = identity;

            Vector4 vecTranslate = new Vector4(vec.x + matTrans.m03, vec.y + matTrans.m13, vec.z + matTrans.m23, 1);

            matTrans.m03 = vecTranslate.x;
            matTrans.m13 = vecTranslate.y;
            matTrans.m23 = vecTranslate.z;
            matTrans.m33 = vecTranslate.w;

            return matTrans;
        }
        public static Mat4X4 Scale(Vector3 vec)
        {
            Mat4X4 matScale = identity;

            Vector4 vecScale = new Vector4(vec.x * matScale.m00, vec.y * matScale.m11, vec.z * matScale.m22, 1);

            matScale.m00 = vecScale.x;
            matScale.m11 = vecScale.y;
            matScale.m22 = vecScale.z;
            matScale.m33 = vecScale.w;

            return matScale;
        }
        public static Mat4X4 Rotate(Quaternion q)
        {
            /*
            Mat4X4 mat = identity;
            Quaternion rotX = new Quaternion(a.x,
                                            (Mathf.Cos(mat.m11) * a.y - Mathf.Sin(mat.m12) * a.z),
                                            (Mathf.Sin(mat.m21) * a.y + Mathf.Cos(mat.m22) * a.z), 1);
            
            Quaternion rotY = new Quaternion((Mathf.Cos(mat.m00)* a.x + Mathf.Sin(mat.m02) * a.z), a.y,
                                            (-Mathf.Sin(mat.m02)* a.x + Mathf.Cos(mat.m22)* a.z), 1);

            Quaternion rotZ = new Quaternion((Mathf.Cos(mat.m00)* a.x - Mathf.Sin(mat.m01)*a.y), 
                                             (Mathf.Sin(mat.m10)* a.x + Mathf.Cos(mat.m11)*a.y),a.z,1);


            Vector4 rotXVec = new Vector4(rotX.x, rotX.y, rotX.z, rotX.w); 
            Vector4 rotYVec = new Vector4(rotY.x, rotY.y, rotY.z, rotY.w); 
            Vector4 rotZVec = new Vector4(rotZ.x, rotZ.y, rotZ.z, rotZ.w); 
            mat.SetRow(0, rotXVec);
            mat.SetRow(1, rotYVec);
            mat.SetRow(2, rotZVec);
            mat.SetRow(3, new Vector4(0,0,0,1));

            return mat;
             */

            //Magia pura :/

            Mat4X4 mat = identity;
            mat.m02 = 2.0f * (q.x * q.z) + 2.0f * (q.y * q.w);
            mat.m12 = 2.0f * (q.y * q.z) - 2.0f * (q.x * q.w);
            mat.m22 = 1 - 2.0f * (q.x * q.x) - 2.0f * (q.y * q.y);

            mat.m00 = 1 - 2.0f * (q.y * q.y) - 2.0f * (q.z * q.z);
            mat.m10 = 2.0f * (q.x * q.y) + 2.0f * (q.z * q.w);
            mat.m20 = 2.0f * (q.x * q.z) - 2.0f * (q.y * q.w);

            mat.m01 = 2.0f * (q.x * q.y) - 2.0f * (q.z * q.w);
            mat.m11 = 1 - 2.0f * (q.x * q.x) - 2.0f * (q.z * q.z);
            mat.m21 = 2.0f * (q.y * q.z) + 2.0f * (q.x * q.w);
            return mat;
        }

        public static Mat4X4 operator *(Mat4X4 mat1, Mat4X4 mat2)
        {
            Mat4X4 matResult = identity;

            //Row 0
            float m00 = Vector4.Dot(mat1.GetRow(0), mat2.GetColumn(0));
            float m01 = Vector4.Dot(mat1.GetRow(0), mat2.GetColumn(1));
            float m02 = Vector4.Dot(mat1.GetRow(0), mat2.GetColumn(2));
            float m03 = Vector4.Dot(mat1.GetRow(0), mat2.GetColumn(3));
            //Row 1
            float m10 = Vector4.Dot(mat1.GetRow(1), mat2.GetColumn(0));
            float m11 = Vector4.Dot(mat1.GetRow(1), mat2.GetColumn(1));
            float m12 = Vector4.Dot(mat1.GetRow(1), mat2.GetColumn(2));
            float m13 = Vector4.Dot(mat1.GetRow(1), mat2.GetColumn(3));
            //Row 2
            float m20 = Vector4.Dot(mat1.GetRow(2), mat2.GetColumn(0));
            float m21 = Vector4.Dot(mat1.GetRow(2), mat2.GetColumn(1));
            float m22 = Vector4.Dot(mat1.GetRow(2), mat2.GetColumn(2));
            float m23 = Vector4.Dot(mat1.GetRow(2), mat2.GetColumn(3));
            //Row 3
            float m30 = Vector4.Dot(mat1.GetRow(3), mat2.GetColumn(0));
            float m31 = Vector4.Dot(mat1.GetRow(3), mat2.GetColumn(1));
            float m32 = Vector4.Dot(mat1.GetRow(3), mat2.GetColumn(2));
            float m33 = Vector4.Dot(mat1.GetRow(3), mat2.GetColumn(3));

            matResult.SetRow(0, new Vector4(m00, m01, m02, m03));
            matResult.SetRow(1, new Vector4(m10, m11, m12, m13));
            matResult.SetRow(2, new Vector4(m20, m21, m22, m23));
            matResult.SetRow(3, new Vector4(m30, m31, m32, m33));

            return matResult;
        }
        public static Vector4 operator *(Mat4X4 mat, Vector4 vector)
        {
            float x = Vector4.Dot(mat.GetRow(0), vector);
            float y = Vector4.Dot(mat.GetRow(1), vector);
            float z = Vector4.Dot(mat.GetRow(2), vector);
            float w = Vector4.Dot(mat.GetRow(3), vector);

            return new Vector4(x,y,z,w);
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