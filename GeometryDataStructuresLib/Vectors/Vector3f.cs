using System;
namespace GeometryDataStructures.Vectors
{
    public struct Vector3f
    {
		public float x, y, z;
        
		public Vector3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
			this.z = z;
        }

		public static Vector3f operator +(Vector3f v1, Vector3f v2)
        {
            return new Vector3f(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

		public static Vector3f operator -(Vector3f v1, Vector3f v2)
        {
            return new Vector3f(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

		public static Vector3f operator *(Vector3f v1, Vector3f v2)
        {
            return new Vector3f(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

		public static Vector3f operator /(Vector3f v1, Vector3f v2)
        {
            return new Vector3f(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector3f operator *(Vector3f v1, float c)
        {
            return new Vector3f(v1.x * c, v1.y * c, v1.z * c);
        }

		public Vector3f Cross(Vector3f v)
        {
            return new Vector3f(y * v.z - z * v.y, z * v.x - x * v.z, x * v.y - y * v.x);
        }
    }
}
