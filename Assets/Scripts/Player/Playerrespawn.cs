using System;
using UnityEngine;

public class Playerrespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointsfx; //sound made when touch checkpoint
    private Transform currentCheckpoint; //stores last gotten checkpoint
    private Health playerHealth;
    private UIManager UIManager;
    [SerializeField] private CameraController mainCamera;
    [SerializeField] private Transform checkpoint0;
    [SerializeField] private Transform checkpoint1;
    [SerializeField] private Transform checkpoint2;
    [SerializeField] private Transform activeCheckpoint;
    private int currentCheckpointIndex;
    

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        UIManager = GetComponent<UIManager>();
    }

    private void FixedUpdate()
    {
        switch (currentCheckpointIndex)
        {
            case 0:
                currentCheckpoint = checkpoint0;
                break;
            case 1:
                currentCheckpoint = checkpoint1;
                break;
            case 2:
                currentCheckpoint = checkpoint2;
                break;
        }
    }

    public void CheckRespawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
        mainCamera.MoveToNewRoom(activeCheckpoint);
        print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointsfx);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
            currentCheckpointIndex =+ 1;
        }
    }
}
