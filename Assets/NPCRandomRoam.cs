using UnityEngine;
using UnityEngine.AI;

public class NPCRandomRoam : MonoBehaviour
{
    public float roamRadius = 15f;     // รัศมีเดินเล่นจากจุดเริ่ม
    public float waitTimeMin = 1f;     // เวลาหยุดพักขั้นต่ำ
    public float waitTimeMax = 4f;     // เวลาหยุดพักสูงสุด

    private NavMeshAgent agent;
    private Animator anim;
    private Vector3 startPos;
    private float waitTimer;
    private bool isWaiting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        startPos = transform.position;

        GoToNewRandomPoint();
    }

    void Update()
    {
        float speed = agent.desiredVelocity.magnitude;
        anim.SetBool("isWalking", speed > 0.1f);

        //float speed = agent.velocity.magnitude;
        //anim.SetBool("isWalking", speed > 0.1f);

        //bool walking = agent.velocity.magnitude > 0.1f;
        //anim.SetBool("isWalking", walking);


        // ถ้าเดินถึงจุดแล้ว
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                waitTimer = Random.Range(waitTimeMin, waitTimeMax);
                agent.ResetPath();
            }
        }

        // ช่วงเวลายืนเฉย ๆ
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                GoToNewRandomPoint();

             
            }
        }
    }

    void GoToNewRandomPoint()
    {
        // สุ่มทิศทางรอบ ๆ จุดเริ่ม
        Vector3 randomDir = Random.insideUnitSphere * roamRadius;
        randomDir += startPos;
        randomDir.y = startPos.y; // ล็อกระดับความสูง

        NavMeshHit hit;
        // หาจุดที่อยู่บน NavMesh จริง ๆ
        if (NavMesh.SamplePosition(randomDir, out hit, roamRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }



}

