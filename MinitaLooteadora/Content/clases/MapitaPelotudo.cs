using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace MinitaLooteadora.Content.clases
{
    public class MapitaPelotudo
    {
        public readonly Microsoft.Xna.Framework.Point MAP_SIZE = new(6,4);

        public readonly Microsoft.Xna.Framework.Point TILE_SIZE;

        private readonly Tile[,] _tiles;

        public MapitaPelotudo()
        {
            _tiles = new Tile[MAP_SIZE.X, MAP_SIZE.Y];

            Texture2D[] textures =
            {
                CargarTiles.Content.Load<Texture2D>("tiles/DejandoDeTocarPasto1.png"),
                CargarTiles.Content.Load<Texture2D>("tiles/DejandoDeTocarPasto2.png"),
                CargarTiles.Content.Load<Texture2D>("tiles/DejandoDeTocarPasto3.png"),
                CargarTiles.Content.Load<Texture2D>("tiles/DejandoDeTocarPasto4.png"),
                CargarTiles.Content.Load<Texture2D>("tiles/Paston't.png"),
                CargarTiles.Content.Load<Texture2D>("tiles/TocandoPastoSiempre.png"),
            };

            TILE_SIZE.X = textures[0].Width;
            TILE_SIZE.Y = textures[0].Height;

            Random rand = new();

            for (int y = 0; y < MAP_SIZE.Y; y++)
            {
                for (int x = 0; x < MAP_SIZE.X; x++)
                {
                    int r = rand.Next(0, textures.Length);
                    _tiles[x, y] = new Tile(textures[r], MapToScreen(x,y));
                }
            }
        }

        private Vector2 MapToScreen(int mapX, int mapY)
        {
            var screenX = mapX * TILE_SIZE.X;
            var screenY = mapY * TILE_SIZE.Y;

            return new(screenX, screenY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < MAP_SIZE.Y; y++)
            {
                for (int x = 0; x < MAP_SIZE.X; x++)
                {
                    _tiles[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
