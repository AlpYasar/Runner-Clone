using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OppenentMovement : MonoBehaviour
{
    public Animator animator;
    public bool isMoving = false;
    public float speed;
    public GameObject target;
    public NavMeshAgent agent;
    
    [Header("WanderParams")]
    public float wanderRadius;
    public float wanderTimer;
    public bool isMoveToTarget = true;

    public float corutineTime = 5f;
    private Transform wanderTarget;
    private float timer ;
    private IEnumerator coroutine;
    private float firstTimeValue;

    void OnEnable () {
        agent = GetComponent<NavMeshAgent> ();
        firstTimeValue = timer = wanderTimer;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isRunning", false);
        agent.SetDestination(target.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshController();
    }

    public void NavMeshController()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        float speed = rb.velocity.magnitude;
        
        isMoving = !(speed < 0.1f);
        
        animator.SetBool("isRunning", isMoving);
        
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            
            isMoveToTarget = false;
            wanderControl();
        }

        if ((!isMoveToTarget) && (timer >= 0.6f))
        {
            agent.SetDestination(target.transform.position);
            isMoveToTarget = true;
        }
        
    }

    public void wanderControl()
    { 
        /*
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
        wanderTimer = Random.Range(firstTimeValue - 2f, firstTimeValue + 2f);
        timer = Random.Range(0f, 0.4f);
        */

    }
    
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Girls hit");
        if (collision.gameObject.tag == "Obs")
        {
            transform.position = new Vector3(-1.75f, 1f, Random.Range(-0.25f, 0.25f));
        }
    }
    
    
}
