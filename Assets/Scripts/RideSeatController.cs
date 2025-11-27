using UnityEngine;

public class RideSeatController:MonoBehaviour
{
    public Transform seatPoint;      // จุดนั่งบนเครื่องเล่น
    public Transform exitPoint;      // จุดวางตัวเมื่อออก
    public Transform xrOrigin;       // XR Origin (Camera Rig)
    public KeyCode interactKey = KeyCode.JoystickButton0; // ปุ่ม A บน Quest

    bool isPlayerInsideEnterZone = false;
    bool isPlayerInsideExitZone = false;
    bool isRiding = false;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (isPlayerInsideEnterZone && !isRiding)
                SitOnRide();
            else if (isPlayerInsideExitZone && isRiding)
                ExitRide();
        }
    }

    // ---------- ENTER TRIGGER ----------
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInsideEnterZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInsideEnterZone = false;
    }

    // ---------- EXIT TRIGGER (เรียกจาก RideExitZone.cs) ----------
    public void OnExitZoneEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInsideExitZone = true;
    }

    public void OnExitZoneExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInsideExitZone = false;
    }

    // ---------- ACTION ----------
    private void SitOnRide()
    {
        xrOrigin.SetParent(seatPoint.parent);       // Parent เข้ากับเครื่องเล่น
        xrOrigin.position = seatPoint.position;     // ตั้งตำแหน่งศีรษะผู้เล่น
        xrOrigin.rotation = seatPoint.rotation;

        isRiding = true;
    }

    private void ExitRide()
    {
        xrOrigin.SetParent(null);                   // แกะออกจากเครื่องเล่น
        xrOrigin.position = exitPoint.position;     // วางกลับลงพื้น
        xrOrigin.rotation = exitPoint.rotation;

        isRiding = false;
    }
}
