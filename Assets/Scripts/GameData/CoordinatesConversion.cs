using UnityEngine;

namespace TutoTOONS_Task
{
    public static class CoordinatesConversion
    {
        private const int MaxDataCoordinate = 1000;
        private const int MinDataCoordinate = 0;

        public static Vector2 ConvertCoordinates(int x, int y)
        {
            int maxDataDistance = MaxDataCoordinate - MinDataCoordinate;
            float screenHeight = Screen.height;

            float convertedX = Mathf.Clamp(x, MinDataCoordinate, MaxDataCoordinate);
            convertedX = screenHeight / maxDataDistance * convertedX - screenHeight / 2;

            float convertedY = Mathf.Clamp(y, MinDataCoordinate, MaxDataCoordinate);
            convertedY = -screenHeight / maxDataDistance * convertedY + screenHeight / 2;

            Debug.Log($"Original: {x} {y} ; Converted: {convertedX} {convertedY} ; Screen Height: {screenHeight}");
            return new Vector2(convertedX, convertedY);
        }
    }
}