using UnityEngine;

public class Playerrespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointsfx; //sound made when touch checkpoint
    private Transform currentCheckpoint; //stores last gotten checkpoint
    private Health playerHealth;
    private UIManager UIManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        UIManager = GetComponent<UIManager>();
    }

    public void CheckRespawn()
    {
        if(currentCheckpoint == null)
        {
            UIManager.GameOver();

            return;
        }

        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointsfx);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
