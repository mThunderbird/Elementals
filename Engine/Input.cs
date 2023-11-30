using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
	internal static class Input
	{
		private static KeyboardState currentKeyboardState;
		private static KeyboardState previousKeyboardState;
		private static MouseState previousMouseState;
		
		public static void Update()
		{
			previousKeyboardState = currentKeyboardState;
			currentKeyboardState = Keyboard.GetState();
		}
		public static Vector2 getMouseCoordinates() => new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

		public static bool isMouseButtonPressed(MOUSE_BUTTON button) {
			if (button == MOUSE_BUTTON.LEFT)
			{
				return Mouse.GetState().LeftButton == ButtonState.Pressed ? true : false;
			}
			return Mouse.GetState().RightButton == ButtonState.Pressed ? true : false;
		}
		public static bool eventIsMouseReleased()
		{
			MouseState currentMouseState = Mouse.GetState();

			if (currentMouseState.LeftButton == ButtonState.Released &&
				previousMouseState.LeftButton == ButtonState.Pressed)
			{
				previousMouseState = currentMouseState;
				return true;
			}

			previousMouseState = currentMouseState;

			return false;
		}
		public static bool IsKeyReleased(Keys key)
		{
			if (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key)) 
				return true;
			return false;
		}

		public static bool IsKeyPressed(Keys key)
		{
            if (currentKeyboardState.IsKeyDown(key))
                return true;
            return false;
        }
	}
	public enum MOUSE_BUTTON
	{
		LEFT,
		RIGHT
	}
}
