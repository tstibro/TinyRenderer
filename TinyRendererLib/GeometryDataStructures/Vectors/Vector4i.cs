using System;
namespace TinyRendererLib.GeometryDataStructures.Vectors
{
    public struct Vector4i
    {
		public int x, y, z, w;

        public Vector4i(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Vector4i operator +(Vector4i v1, Vector4i v2)
        {
            return new Vector4i(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        public static Vector4i operator -(Vector4i v1, Vector4i v2)
        {
            return new Vector4i(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        public static Vector4i operator *(Vector4i v1, Vector4i v2)
        {
            return new Vector4i(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }

        public static Vector4i operator /(Vector4i v1, Vector4i v2)
        {
            return new Vector4i(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }

        public static Vector4i operator *(Vector4i v1, int c)
        {
            return new Vector4i(v1.x * c, v1.y * c, v1.z * c, v1.w * c);
        }
    }
}
