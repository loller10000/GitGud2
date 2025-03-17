using UnityEngine;
//Dit laat zien dat als een speler een hartje op pakt in het spel, dat de health value van de speler dus ook echt omhoog gaat.
public class Healthpickup : MonoBehaviour
{
    [SerializeField] private float healthValue;

    [Header("SFX")]
    [SerializeField] private AudioClip healthClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(healthClip);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
