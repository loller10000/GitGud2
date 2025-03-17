using UnityEngine;

public class meleeenemy : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask PlayerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Attack sound")]
    [SerializeField] private AudioClip attackSound;

    //references
    private Animator anim;
    private Health playerHealth;

    private enemypatrol enemypatrol;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemypatrol = GetComponentInParent<enemypatrol>();
    }
    private void Update()
    {
        cooldownTimer = Time.deltaTime;
        
        //Attack only on sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown && playerHealth.currentHealth > 0)
            {
                cooldownTimer  = 0;
                anim.SetTrigger("melee attack");
                SoundManager.instance.PlaySound(attackSound);
            }
        
        if(enemypatrol != null)
                enemypatrol.enabled = !PlayerInSight();
        
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, PlayerLayer);

        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();
       
        return hit.collider !=null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        // if player still in range damage
        if(PlayerInSight())
           playerHealth.TakeDamage(damage);
        
    }

}
