using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FNAImgui
{
	public class GlobalManager
	{
		/// <summary>
		/// this gets called by a Scene so that the final render can be handled. The render should be done into finalRenderTarget.
		/// In most cases, finalRenderTarget will be null so the render will just be to the backbuffer. The only time finalRenderTarget
		/// will be set is the first frame of a SceneTransition where the transition has requested the previous Scene render.
		/// </summary>
		/// <param name="finalRenderTarget"></param>
		/// <param name="letterboxColor"></param>
		/// <param name="source"></param>
		/// <param name="finalRenderDestinationRect"></param>
		/// <param name="samplerState"></param>
		/// <returns></returns>
		public virtual void HandleFinalRender(RenderTarget2D finalRenderTarget, Color letterboxColor, RenderTarget2D source,
							   Rectangle finalRenderDestinationRect, SamplerState samplerState)
		{

		}


		#region GlobalManager Lifecycle

		/// <summary>
		/// called each frame before Scene.update
		/// </summary>
		public virtual void Update(float deltaTime)
		{
		}

		#endregion
	}
}