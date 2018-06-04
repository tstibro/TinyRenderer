using System;
namespace GeometryDataStructures.Vectors
{
    public struct Vector3i
    {
		public int x, y, z;

        public Vector3i(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3i operator +(Vector3i v1, Vector3i v2)
        {
            return new Vector3i(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3i operator -(Vector3i v1, Vector3i v2)
        {
            return new Vector3i(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3i operator *(Vector3i v1, Vector3i v2)
        {
            return new Vector3i(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static Vector3i operator /(Vector3i v1, Vector3i v2)
        {
            return new Vector3i(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector3i operator *(Vector3i v1, int c)
        {
            return new Vector3i(v1.x * c, v1.y * c, v1.z * c);
        }

        public Vector3i Cross(Vector3i v)
        {
            return new Vector3i(y * v.z - z * v.y, z * v.x - x * v.z, x * v.y - y * v.x);
        }
    }
}
