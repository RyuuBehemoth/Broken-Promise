using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MinitaLooteadora.Content.clases;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class Tile
{
    private readonly Texture2D _texture;
    private readonly Vector2 _position;

    public Tile(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        CargarTiles.SpriteBatch.Draw(_texture, _position, Color.White);
    }
}