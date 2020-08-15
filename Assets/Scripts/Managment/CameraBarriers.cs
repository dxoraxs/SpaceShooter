using System.Collections.Generic;
using UnityEngine;

public class CameraBarriers
{
    private static Vector3[] pointsBarrier;

    public static float LeftBorrier => pointsBarrier[0].x;
    public static float RightBorrier => pointsBarrier[2].x;
    public static float TopBorrier => pointsBarrier[1].z;
    public static float BottomBorrier => -pointsBarrier[1].z;

    public static Vector3[] GetCameraBarrier(float yPosition = 0)
    {
        if (pointsBarrier == null)
        {
            InitCameraBarrier(yPosition);
        }

        return pointsBarrier;
    }

    private static void InitCameraBarrier(float yPosition)
    {
        var point = new List<Vector3>();
        RaycastHit hit = new RaycastHit();
        Camera camera = Camera.main;

        int height = Screen.height;
        int width = Screen.width;
        point.Add(GetPosition(hit, camera, new Vector2(0, height/2), yPosition));
        point.Add(GetPosition(hit, camera, new Vector2(0, height), yPosition));
        point.Add(GetPosition(hit, camera, new Vector2(width, height), yPosition));
        point.Add(GetPosition(hit, camera, new Vector2(width, height /2), yPosition));
        
        pointsBarrier = point.ToArray();
    }

    private static Vector3 GetPosition(RaycastHit hit, Camera camera, Vector2 point, float yPosition)
    {
        Ray ray = camera.ScreenPointToRay(point);
        Physics.Raycast(ray, out hit);
        return hit.point + Vector3.up * (yPosition - hit.point.y);
    }
}
