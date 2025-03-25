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
        if (spawnerEnemy.activeSelf == false && childrenCount < 2)
        {
                
            for (int i = 1; i < 3; i++)
            {
                Instantiate(children, transform.position, Quaternion.identity);
                enemyChildSpawner.position = enemyChildSpawner.position + new Vector3(100 * i, 0, 0);
                childrenCount++;
                print("bruh");
            }
                
        }
    }
}
