using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinitaLooteadora.Content.clases
{
    public static class Controles
    {
        private static KeyboardState _lastKeyboardState;
        private static Point _direction;
        private static Point Direction => _direction;
        private static Point MousePosition => Mouse.GetState().Position;

        public static void Update()
        {
            var movimiento = Keyboard.GetState();

            _direction = Point.Zero;

            if (movimiento.IsKeyDown(Keys.W))
                _direction.Y -= 1;
            if (movimiento.IsKeyDown(Keys.S))
                _direction.Y += 1;
            if (movimiento.IsKeyDown(Keys.A))
                _direction.X -= 1;
            if (movimiento.IsKeyDown(Keys.D))
                _direction.X += 1;
            _lastKeyboardState = movimiento;
        }
    }
}
