using new_ga_e.Entities;
using new_ga_e.Models;
using new_ga_e.View;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Policy;
namespace new_ga_e.Controlles
{
    public partial class MapPaint
    {
        public const int mapHeight = 19;
        public const int mapWidth = 20;
        public static int cellSize = 31;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;
        public static Image evil;
        public static List<MapModel> mapObjects;
        public static npcEntity npc;

        public static PlayerPaint player;
        public static Image kind;
        public static Image notkind;
        public static npcEntity npcEntity1;
        public static  int HealedCount;
        public static Image playerSheet;

        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\backSheet.png"));
            mapObjects = new List<MapModel>();
            evil = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\evil.png"));
            kind = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\kind.png"));
            notkind = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\evill.png"));
            playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\gero.png"));

            player = new PlayerPaint(120, 110, PlayerPaint.rightFrame, playerSheet);
            npcEntity1 = new npcEntity(140, 140);
            HealedCount = 0;

        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 10)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize * 2)), 193, 160, 45, 90, GraphicsUnit.Pixel);
                        MapModel mapEntity = new MapModel(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize * 2));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 273, 176, 32, 34, GraphicsUnit.Pixel);
                        MapModel mapEntity = new MapModel(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);

                    }
                    if (map[i, j] == 12)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 208, 128, 32, 34, GraphicsUnit.Pixel);
                        MapModel mapEntity = new MapModel(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 13)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 386, 289, 32, 31, GraphicsUnit.Pixel);
                        MapModel mapEntity = new MapModel(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                    //if (map[i, j] == 14)
                    //{
                    //    PaintAudioGame.PlayAnimation(g);
                    //    if (player.IsHealing)
                    //    {
                    //        PaintAudioGame.Init();

                    //        if (npcNhero.IsNearby(player.posX, npcEntity1.posX, player.posY, npcEntity1.posY))
                    //        {
                    //            PaintAudioGame.PlayAnimationForHeal(g, 100, 140);

                    //            if (HealSibiling.IsHealSuccses(100, 140))
                    //            {
                    //                npcEntity1.IsHealed = true;
                    //                HealedCount += 1;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
        }

        public static int[,] GetMap()
        {
            return new int[,]
            {
                {1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                {5,13,13,10,10,10,10,10,0,0,0,0,0,12,12,12,10,10,0,7},
                {5,0,10,13,0,0,0,10,0,0,0,0,0,12,10,10,10,0,0,7},
                {5,0,-1,10,0,0,0,-1,0,0,0,0,0,0,-1,0,-1,0,0,7},
                {5,0,0,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,12,7},
                {5,0,0,0,12,13,0,0,0,0,10,0,0,0,0,0,0,0,13,7},
                {5,0,0,0,0,12,0,0,0,13,10,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,10,13,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,10,10,0,0,0,10,10,0,0,0,0,0,13,0,0,0,7},
                {5,0,10,12,13,0,0,0,-1,-1,0,0,0,13,12,0,0,0,0,7},
                {5,0,10,13,0,0,0,0,0,0,0,0,0,0,13,0,0,0,0,7},
                {5,0,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,10,-1,0,11,11,0,0,0,0,0,0,0,0,0,0,10,0,10,7},
                {5,-1,10,0,11,0,0,0,0,0,0,0,0,11,0,0,0,10,-1,7},
                {5,0,10,10,-1,0,0,0,12,0,0,0,11,11,0,0,13,0,0,7},
                {5,0,-1,-1,0,0,0,0,13,12,0,0,0,0,0,0,13,13,0,7},
                {3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 1)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 35, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 2)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 45, 35, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 3)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 64, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 4)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 45, 64, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 5)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 45, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 6)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 15, 32, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 7)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 45, 45, 15, 15, GraphicsUnit.Pixel);
                    else

                    if (map[i, j] == 8)
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 11, 64, 4, 15, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 15, 55, 15, 15, GraphicsUnit.Pixel);
                }
            }
            SeedMap(g);

        }

        public static int GetWidth()
        {
            return cellSize * (mapWidth) + 15;
        }
        public static int GetHeight()
        {
            return cellSize * (mapHeight + 1) + 10;
        }

    }
}
