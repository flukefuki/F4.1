using UnityEngine;
using UnityEngine.Splines;

public class CarriageFollow : MonoBehaviour
{
    public SplineContainer spline;
    public float speed = 2f;
    public float offset = 0f;        // ระยะห่างจากหัวรถ
    public float rotationSmooth = 10f;

    private float t;

    void Update()
    {
        t += speed * Time.deltaTime;

        // loop 
        float splinePos = (t + offset) % 1f;

        // เอาตำแหน่งบน spline
        Vector3 pos = spline.EvaluatePosition(splinePos);
        Vector3 forward = spline.EvaluateTangent(splinePos);

        // ขยับแบบสมูท
        transform.position = pos;

        // หมุนแบบนุ่มนวล (ไม่หักทันที)
        if (forward != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotationSmooth * Time.deltaTime);

        }
    }
}
