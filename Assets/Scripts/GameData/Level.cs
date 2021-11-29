using System.Collections.Generic;
using UnityEngine;

namespace TutoTOONS_Task.Data
{
    public class Level
    {
        public List<Vector2> Points { private set; get; } = new List<Vector2>();

        public Level(int[] pointCoordinates, float displayHeight)
        {
            for(int i = 0; i < pointCoordinates.Length; i += 2)
            {
                if (i + 1 >= pointCoordinates.Length)
                {
                    Debug.LogWarning("Missing Y coordinate. Skipping last point data.");
                    return;
                }

                Points.Add(CoordinatesConversion.ConvertCoordinates(pointCoordinates[i], pointCoordinates[i+1], displayHeight));
            }
        }
    }
}