using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MinitaLooteadora
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TiledMap _map;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // 👇 Cargar el mapa
            _map = TiledMapLoader.Load(Content, "Maps/Campito.tmx");
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            int tilesPerRow = _map.Tileset.Width / _map.TileWidth;

            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    int gid = _map.Tiles[x, y];
                    if (gid == 0) continue; // tile vacío

                    gid -= 1; // porque Tiled empieza desde 1

                    int srcX = (gid % tilesPerRow) * _map.TileWidth;
                    int srcY = (gid / tilesPerRow) * _map.TileHeight;

                    _spriteBatch.Draw(
                        _map.Tileset,
                        new Vector2(x * _map.TileWidth, y * _map.TileHeight),
                        new Rectangle(srcX, srcY, _map.TileWidth, _map.TileHeight),
                        Color.White
                    );
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
