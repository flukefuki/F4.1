using UnityEngine;

public class SeatInteract : MonoBehaviour
{
    public Transform seatAnchor;
    public GameObject playerRig; // ใส่ [BuildingBlock] Camera Rig

    bool isSeated = false;

    void OnTriggerStay(Collider other)
    {
        if (!isSeated && other.CompareTag("PlayerHand"))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) // ปุ่ม VR
            {
                Sit();
            }
        }
    }

    public void Sit()
    {
        isSeated = true;
        // ย้าย Player ไป SeatAnchor และ Parent
        playerRig.transform.position = seatAnchor.position;
        playerRig.transform.rotation = seatAnchor.rotation;
        playerRig.transform.SetParent(seatAnchor);

        Debug.Log("Player is seated.");
    }

    public void StandUp()
    {
        isSeated = false;
        // เลิกเป็นลูก
        playerRig.transform.SetParent(null);

        Debug.Log("Player stands up.");
    }
}
