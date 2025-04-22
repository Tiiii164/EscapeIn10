using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    [SerializeField] private string currentState;
    public Paths path;
    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10)]
    public float fireRate;
    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }
    public bool CanSeePlayer()
    {
        if(player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angleToPlayer >= - fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    { 
                        if(hitInfo.transform.root.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }

                    }
                }
            }
        }
        return false;
    }
}