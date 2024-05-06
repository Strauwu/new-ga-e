﻿using new_ga_e.Entities;
using System;
using System.Drawing;

namespace new_ga_e.Controlles
{
    public static class PhysicsController
    {
        public static bool IsCollide(PlayerEntity entity, Point dir)
        {
            if (entity.posX + dir.X <= 0 || entity.posX + dir.X >= MapModel.cellSize * (MapModel.mapWidth-1) || entity.posY + dir.Y <= 0 || entity.posY + dir.Y >= MapModel.cellSize * (MapModel.mapHeight-1))
                return true;
            for (int i = 0; i < MapModel.mapObjects.Count; i++)
            {
                var currentObject = MapModel.mapObjects[i];
                PointF delta = new PointF();
                delta.X = (entity.posX + entity.size / 2) - (currentObject.position.X + currentObject.size.Width / 2);
                delta.Y = (entity.posY + entity.size / 2) - (currentObject.position.Y + currentObject.size.Height / 2);
                if (Math.Abs(delta.X) <= entity.size / 2 + currentObject.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= entity.size / 2 + currentObject.size.Height / 2)
                    {
                        if (delta.X < 0 && dir.X == 2 && entity.posY + entity.size / 2 > currentObject.position.Y &&entity.posY + entity.size / 2 < currentObject.position.Y + currentObject.size.Height)
                            return true;
                        if (delta.X > 0 && dir.X == -2 && entity.posY + entity.size / 2 > currentObject.position.Y && entity.posY + entity.size / 2 < currentObject.position.Y + currentObject.size.Height)
                            return true;
                        if (delta.Y < 0 && dir.Y == 2 && entity.posX + entity.size / 2 > currentObject.position.X && entity.posX + entity.size / 2 < currentObject.position.X+currentObject.size.Width)
                            return true;
                        if (delta.Y > 0 && dir.Y == -2 && entity.posX + entity.size / 2 > currentObject.position.X && entity.posX + entity.size / 2 < currentObject.position.X + currentObject.size.Width)
                            return true;
                    }
                }
            }
            return false;
        }

    }
}