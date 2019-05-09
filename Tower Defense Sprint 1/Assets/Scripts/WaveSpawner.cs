using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // public GameObject enemy;

    public Transform enemyTrashPrefab;
    public Transform enemyCloudPrefab;

    public Transform spawnPoint;

    // The time between different waves
    public float waveTime = 5f;

    // Time for first wave
    private float countdown = 2f;

    //Number of enemies
    private int waveIndex = 1;

    //


    // Start is called before the first frame update
    void Start()
    {
        //clone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave1());
            countdown = waveTime;


        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave1()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {


            SpawnEnemyTrash();
            yield return new WaitForSeconds(0.5f);

            SpawnEnemyCloud();
            yield return new WaitForSeconds(1.0f);

        }
    }

    void SpawnEnemyTrash()
    {
        if (enemyTrashPrefab != null)
        {
            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyTrashPrefab, spawnPoint.position, spawnPoint.rotation);

        }
    }

    void SpawnEnemyCloud()
    {
        if (enemyCloudPrefab != null)
        {
            Vector3 cloudInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 8, spawnPoint.position.z);
            
            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyCloudPrefab, cloudInitial, spawnPoint.rotation);

        }

    }
}
  /*  int NumberEnemyTrash(int waveIndex)
    {
        this.waveIndex = waveIndex * wave
        return 0;
    }
}
*/
