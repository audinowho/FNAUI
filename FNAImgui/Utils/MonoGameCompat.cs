#if FNA
using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Nez
{
	/// <summary>
	/// implements some methods available in MonoGame that do not exist in FNA/XNA to make transitioning a codebase from MG/XNA to FNA
	/// a little bit easier.
	/// </summary>
	public static class MonoGameCompat
	{
		#region Point

		/// <summary>
		/// Gets a <see cref="Vector2"/> representation for this object.
		/// </summary>
		/// <returns>A <see cref="Vector2"/> representation for this object.</returns>
		public static Vector2 ToVector2( this Point self )
		{
			return new Vector2( (float)self.X, (float)self.Y );
		}

		#endregion


	}
}

#endif