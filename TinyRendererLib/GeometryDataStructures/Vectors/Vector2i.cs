using System;
namespace TinyRendererLib.GeometryDataStructures.Vectors
{
    public struct Vector2i
    {
		public int x, y;
        
        public Vector2i(int x, int y)
        {
			this.x = x;
            this.y = y;
        }

		public static Vector2i operator +(Vector2i v1, Vector2i v2)
        {
			return new Vector2i(v1.x + v2.x, v1.y + v2.y);
        }

		public static Vector2i operator -(Vector2i v1, Vector2i v2)
        {
			return new Vector2i(v1.x - v2.x, v1.y - v2.y);
        }

		public static Vector2i operator *(Vector2i v1, Vector2i v2)
        {
			return new Vector2i(v1.x * v2.x, v1.y * v2.y);
        }

		public static Vector2i operator /(Vector2i v1, Vector2i v2)
        {
			return new Vector2i(v1.x / v2.x, v1.y / v2.y);
        }

		public static Vector2i operator *(Vector2i v1, int c)
        {
			return new Vector2i(v1.x * c, v1.y * c);
        }      
    }
}
