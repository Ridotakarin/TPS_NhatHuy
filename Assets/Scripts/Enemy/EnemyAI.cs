using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform targetPlayer;
    public float chaseDistance = 15f;
    public float attackDistance = 2f;

    private NavMeshAgent agent;
    private Animator animator;
    private bool isDead = false; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (targetPlayer == null)
        {
            GameObject player = GameObject.Find("Space_Solider");
            if (player != null) targetPlayer = player.transform;
        }
    }

    void Update()
    {
        if (isDead) return;

        if (targetPlayer == null) return;

        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        if (distance <= chaseDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(targetPlayer.position);
            animator.SetBool("Attack",false);
            animator.SetBool("Move", true);
            

            if (distance <= attackDistance)
            {
                agent.isStopped = true;
                animator.SetBool("Attack",true);
            }
            
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("Move", false);

        }
    }

    public void SetDead()
    {
        isDead = true;
        agent.isStopped = true;
        animator.SetBool("Move", false);
        animator.enabled = false; 
    }
}
