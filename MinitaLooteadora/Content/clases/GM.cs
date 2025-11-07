using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MinitaLooteadora.Content.clases
{
    public class GM
    {
        private readonly MapitaPelotudo _map = new();

        private void Update()
        {
            Controles.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _map.Draw(spriteBatch);
        }
    }
}
