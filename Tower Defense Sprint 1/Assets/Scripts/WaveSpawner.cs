using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
   // public GameObject enemy;

    public Transform enemyPrefab;

    public Transform spawnPoint;

    // The time between different waves
    public float waveTime = 5f;

    // Time for first wave
    private float countdown = 2f;

    //Number of enemies
    private int waveIndex = 1;

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
            StartCoroutine(SpawnWave());
            countdown = waveTime;


        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave() { 
    waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    { 
        if (enemyPrefab != null)
        {
            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
    }
}
