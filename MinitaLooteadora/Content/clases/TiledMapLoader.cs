using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class TiledMap
{
    public int Width;
    public int Height;
    public int TileWidth;
    public int TileHeight;
    public int[,] Tiles;
    public Texture2D Tileset;
}

public static class TiledMapLoader
{
    public static TiledMap Load(ContentManager content, string mapPath)
    {
        var map = new TiledMap();

        // Cargar el archivo TMX desde Content
        string fullPath = Path.Combine(content.RootDirectory, mapPath);
        var doc = XDocument.Load(fullPath);
        var mapElement = doc.Element("map");

        map.Width = int.Parse(mapElement.Attribute("width").Value);
        map.Height = int.Parse(mapElement.Attribute("height").Value);
        map.TileWidth = int.Parse(mapElement.Attribute("tilewidth").Value);
        map.TileHeight = int.Parse(mapElement.Attribute("tileheight").Value);

        // Leer tileset
        var tilesetElement = mapElement.Element("tileset");
        XElement imageElement;

        if (tilesetElement.Attribute("source") != null)
        {
            // Tileset externo (.tsx)
            string tsxPath = Path.Combine("Content/Maps", tilesetElement.Attribute("source").Value);
            var tsxDoc = XDocument.Load(tsxPath);
            var tsxTileset = tsxDoc.Element("tileset");
            imageElement = tsxTileset.Element("image");
        }
        else
        {
            // Tileset embebido en el .tmx
            imageElement = tilesetElement.Element("image");
        }

        // Ahora sí puedes acceder al atributo "source"
        string imageSource = imageElement.Attribute("source").Value.Replace("\\", "/");
        string imageFileName = Path.GetFileNameWithoutExtension(imageSource);

        // Cargar textura
        map.Tileset = content.Load<Texture2D>($"Maps/{imageFileName}");

        // Leer capa principal
        var layer = mapElement.Element("layer");
        var data = layer.Element("data").Value
            .Trim()
            .Split(',')
            .Select(s => int.Parse(s))
            .ToArray();

        map.Tiles = new int[map.Width, map.Height];

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                map.Tiles[x, y] = data[y * map.Width + x];
            }
        }

        return map;
    }
}
