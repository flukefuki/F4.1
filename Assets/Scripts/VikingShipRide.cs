using UnityEngine;

public class VikingShipRide : MonoBehaviour

{
    [Header("Swing Settings")]
    public float swingAngle = 30f;      // มุมแกว่งสูงสุด (องศา)
    public float swingSpeed = 1f;       // ความเร็วแกว่ง
    public enum SwingAxis { X, Y, Z }  // เลือกแกนแกว่ง
    public SwingAxis swingAxis = SwingAxis.X;

    private Vector3 initialRotation;

    void Start()
    {
        // เก็บมุมเริ่มต้นของทั้ง 3 แกน
        initialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        Vector3 newRotation = initialRotation;

        // แกว่งตามแกนที่เลือก
        switch (swingAxis)
        {
            case SwingAxis.X:
                newRotation.x = initialRotation.x + angle;
                break;
            case SwingAxis.Y:
                newRotation.y = initialRotation.y + angle;
                break;
            case SwingAxis.Z:
                newRotation.z = initialRotation.z + angle;
                break;
        }

        transform.localEulerAngles = newRotation;
    }
}
