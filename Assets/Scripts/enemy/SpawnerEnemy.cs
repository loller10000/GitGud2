using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private GameObject children;
    [SerializeField] private GameObject spawnerEnemy;
    private int childrenCount;
    [SerializeField] private Transform enemyChildSpawner;


    void Update()
    {
        if (spawnerEnemy.activeSelf == false && childrenCount < 1)
        {
            for (int i = 1; i < 2; i++)
            {
                print("bruh");
                Instantiate(children, enemyChildSpawner.position, Quaternion.identity);
                childrenCount++;
            }


        }
    }
}
