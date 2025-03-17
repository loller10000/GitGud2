using System.Collections;
using UnityEngine;


public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("FireTrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("SFX")]
    [SerializeField] private AudioClip fire;

    private bool triggered; // when the trap gets triggered
    private bool active; // when the trap gets activated and dam


    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if(active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }        
        }
    }
    private IEnumerator ActivateFireTrap()
    {
        // turn the sprite red to notify the player and trigger
        triggered = true;
        spriteRend.color = Color.red; 

        //Wait for delay, activate trap, turn on animation, return colour.
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(fire);
        spriteRend.color = Color.white; // turn the sprite back to initial color
        active = true;
        anim.SetBool("activated", true);

        //Wait X seconds, deactivate trap and rest all variables
        yield return new WaitForSeconds(activeTime);
        triggered = false;
        active = false;
        anim.SetBool("activated", false);

    }
}
