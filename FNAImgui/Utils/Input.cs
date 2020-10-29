using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Nez
{
	public static class Input
	{
		public const float DEFAULT_DEADZONE = 0.1f;

		internal static Vector2 _resolutionScale;
		internal static Point _resolutionOffset;
		static KeyboardState _currentKbState;
		static MouseState _currentMouseState;


		static Input()
		{
			_currentKbState = Keyboard.GetState();

			_currentMouseState = Mouse.GetState();

		}


		public static void Update()
		{
			_currentKbState = Keyboard.GetState();

			_currentMouseState = Mouse.GetState();

		}

		/// <summary>
		/// this takes into account the SceneResolutionPolicy and returns the value scaled to the RenderTargets coordinates
		/// </summary>
		/// <value>The scaled position.</value>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ScaledPosition(Vector2 position)
		{
			var scaledPos = new Vector2(position.X - _resolutionOffset.X, position.Y - _resolutionOffset.Y);
			return scaledPos * _resolutionScale;
		}

		/// <summary>
		/// returns the KeyboardState from this frame
		/// </summary>
		/// <value></value>
		public static KeyboardState CurrentKeyboardState => _currentKbState;


		/// <summary>
		/// true the entire time the key is down
		/// </summary>
		/// <returns><c>true</c>, if key down was gotten, <c>false</c> otherwise.</returns>
		public static bool IsKeyDown(Keys key)
		{
			return _currentKbState.IsKeyDown(key);
		}




		#region Mouse

		/// <summary>
		/// returns the current mouse state. Use with caution as it only contains raw data and does not take camera scaling into affect like
		/// Input.mousePosition does.
		/// </summary>
		public static MouseState CurrentMouseState => _currentMouseState;

		#endregion
	}


}