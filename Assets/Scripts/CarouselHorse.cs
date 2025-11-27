using UnityEngine;

public class CarouselHorse:MonoBehaviour
{
    public float rotationSpeed = 15f;  // องศาต่อวินาที
    public Transform centerPoint;       // จุดกลางของม้าหมุน

    void Update()
    {
        if (centerPoint != null)
        {
            // หมุนรอบจุดกลาง แกน Y
            transform.RotateAround(centerPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

}
