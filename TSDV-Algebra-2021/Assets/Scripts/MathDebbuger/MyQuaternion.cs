using System;

namespace CustomMath
{
    [Serializable]
    public struct MyQuaternion : IEquatable<MyQuaternion>
    {
        public float x;
        public float y;
        public float z;
        public float w;

        #region constants
        public const float kEpsilon = 1e-06f;
        public const float i = 1.0f;
        public const float j = 1.0f;
        public const float k = 1.0f;
        public const float e = 1.0f;

        private static MyQuaternion identityQuat = new MyQuaternion(0, 0, 0, 1);
        #endregion

        public MyQuaternion(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        public void Set(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        public static MyQuaternion identity
        {
            get
            {
                return identityQuat;
            }
        }
        public static float Dot(MyQuaternion a, MyQuaternion b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }
        public float Angle(MyQuaternion a, MyQuaternion b)
        {
            float dotProduct = Dot(a, b);

            return 0.0f; // ?
        }
        public static MyQuaternion operator *(MyQuaternion a, MyQuaternion b)
        {
            #region Rules
            //ixi = -1;
            //jxj = -1;
            //kxk = -1;
            //ijk = -1;
            #endregion
            float awXbw = a.w * b.w;
            float awXbx = a.w * b.x;
            float awXby = a.w * b.y;
            float awXbz = a.w * b.z;

            float axXbw = a.x * b.w;
            float axXbx = a.x * b.x; 
            float axXby = a.x * b.y; 
            float axXbz = a.x * b.z; 

            float ayXbw = a.y * b.w;
            float ayXbx = a.y * b.x; 
            float ayXby = a.y * b.y; 
            float ayXbz = a.y * b.z; 

            float azXbw = a.z * b.w;
            float azXbx = a.z * b.x; 
            float azXby = a.z * b.y; 
            float azXbz = a.z * b.z; 


            float rowRealResult = (awXbw - axXbx - ayXby - azXbz);//* w 
            float rowIResult = (awXbx + axXbw + ayXbz - azXby);   //* i
            float rowJResult = (awXby - axXbz + ayXbw + azXbx);   //* j
            float rowKResult = (awXbz + axXby - ayXbx + azXbw);   //* k

            return new MyQuaternion(rowIResult, rowJResult, rowKResult, rowRealResult);
        }
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString() + "   W = " + w.ToString();
        }

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is MyQuaternion)) return false;
            return Equals((MyQuaternion)other);
        }
        public bool Equals(MyQuaternion other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }
        #endregion
    }
}
