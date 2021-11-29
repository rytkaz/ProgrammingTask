using UnityEngine;

namespace TutoTOONS_Task.Data
{
    public static class CoordinatesConversion
    {
        private const int MaxDataCoordinate = 1000;
        private const int MinDataCoordinate = 0;

        public static Vector2 ConvertCoordinates(int x, int y, float displayHeight)
        {
            int maxDataDistance = MaxDataCoordinate - MinDataCoordinate;

            float convertedX = Mathf.Clamp(x, MinDataCoordinate, MaxDataCoordinate);
            convertedX = displayHeight / maxDataDistance * convertedX - displayHeight / 2;

            float convertedY = Mathf.Clamp(y, MinDataCoordinate, MaxDataCoordinate);
            convertedY = -displayHeight / maxDataDistance * convertedY + displayHeight / 2;

            return new Vector2(convertedX, convertedY);
        }
    }
}