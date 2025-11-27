using UnityEngine;

public class RealisticVikingRide : MonoBehaviour
{
    [Header("Swing Settings")]
    public float maxAngle = 45f;       // มุมสูงสุด
    public float initialSpeed = 20f;   // ความเร็วเริ่มต้น
    public float gravity = 9.8f;       // แรงชะลอใกล้จุดสูงสุด

    public enum SwingAxis { X, Y, Z } // เลือกแกนแกว่ง
    public SwingAxis swingAxis = SwingAxis.X;

    private float currentAngle = 0f;
    private float swingSpeed;
    private int direction = 1; // 1 = ไป, -1 = กลับ

    private Vector3 initialRotation;

    void Start()
    {
        swingSpeed = initialSpeed;
        initialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        // ปรับความเร็วตามมุม
        swingSpeed -= direction * gravity * Time.deltaTime;

        // อัปเดตมุม
        currentAngle += swingSpeed * Time.deltaTime * direction;

        // เช็คเกิน maxAngle
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
            direction *= -1; // กลับทิศทาง
            swingSpeed = Mathf.Abs(swingSpeed); // reset speed
        }

        // ใส่ลงแกนที่เลือก
        Vector3 newRotation = initialRotation;
        switch (swingAxis)
        {
            case SwingAxis.X: newRotation.x = currentAngle; break;
            case SwingAxis.Y: newRotation.y = currentAngle; break;
            case SwingAxis.Z: newRotation.z = currentAngle; break;
        }

        transform.localEulerAngles = newRotation;
    }
}
