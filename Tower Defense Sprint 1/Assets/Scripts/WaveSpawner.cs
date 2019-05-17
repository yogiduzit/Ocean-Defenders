using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // public GameObject enemy;

    public Transform enemyTrashPrefab;
    public Transform enemyCloudPrefab;
    //B
    public Transform enemyDumpPrefab;
    public Transform enemyTrashCanPrefab;
    public Transform bossPrefab;

    public Transform spawnPoint;

    // The time between different waves
    public float waveTime = 10f;

    // Time for first wave
    private float countdown = 7f;

    //Number of enemies
    private int yearIndex = 2023;

    private int waveNumber = 10;
    public GameObject camRotate;




    //

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
        //clone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(1f);
        switch (yearIndex)
        {
            case 2019:
                StartCoroutine(SpawnWave1());
                break;
            case 2020:
                StartCoroutine(SpawnWave2());
                break;
            case 2021:
                StartCoroutine(SpawnWave3());
                break;
            case 2022:
                StartCoroutine(SpawnWave4());
                break;
            case 2023:
                StartCoroutine(SpawnWave5());
                break;
            case 2024:
                StartCoroutine(SpawnWave6());
                break;
            case 2025:
                StartCoroutine(SpawnWave7());
                break;
            case 2026:
                StartCoroutine(SpawnWave8());
                break;
            case 2027:
                StartCoroutine(SpawnWave9());
                break;
            case 2028:
                StartCoroutine(SpawnWave10());
                break;
            case 2040:
                SpawnBoss();
                break;

        }



    }
    IEnumerator SpawnWave1()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 4; i++)
        {
            SpawnEnemyTrash();
            yield return new WaitForSeconds(2f);
        }


        yield return new WaitForSeconds(countdown);
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave2()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 6; i++)
        {
            SpawnEnemyTrash();

            yield return new WaitForSeconds(2f);

        }

        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave3()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 7; i++)
        {
            SpawnEnemyTrash();
            if (i > 2 && i < 5)
            {
                yield return new WaitForSeconds(2f);
                SpawnEnemyTrashCan();

                yield return new WaitForSeconds(2f);
            }
            //Time between waves
            yield return new WaitForSeconds(countdown);

            //Calls the main function again
            StartCoroutine(SpawnWaves());
        }
    }
    IEnumerator SpawnWave4()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 10; i++)
        {
            if (i != 8 && i != 3)
            {
                SpawnEnemyTrash();
            }

            if (i > 2 && i < 5)
            {
                yield return new WaitForSeconds(2f);
                SpawnEnemyTrashCan();


            }
            if (i % 2 < Mathf.Epsilon)
            {
                yield return new WaitForSeconds(2f);
                SpawnEnemyCloud();
            }
            yield return new WaitForSeconds(2f);
            /*if (true)
            {
                SpawnEnemyDump();
            }
            */
        }
        /*  for (int i = 0; i < 4; i++)
          {
              SpawnEnemyTrashCan();
              yield return new WaitForSeconds(3f);
          }
          */


        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave5()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies

        for (int i = 0; i < 15; i++)
        {
            if (!(i < 11 && i > 8))
            {
                SpawnEnemyTrash();
            }

            if (i > 1 && i < 7)
            {
                yield return new WaitForSeconds(2f);
                SpawnEnemyTrashCan();


            }
            if (i % 3 < Mathf.Epsilon || i % 4 < Mathf.Epsilon)
            {
                yield return new WaitForSeconds(2f);
                SpawnEnemyCloud();
            }
            yield return new WaitForSeconds(2f);
            /*if (true)
            {
                SpawnEnemyDump();
            }
            */
        }



        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave6()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 20; i++)
        {
            if (i != 0 && i != 1)
            {
                SpawnEnemyTrash();
            }
            if (i >= 0 && i <= 5)
            {

                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(2f);

            }
            if (i > 8)
            {

                SpawnEnemyCloud();
                yield return new WaitForSeconds(2f);


            }
            if (i == 6)
            {
                SpawnEnemyDump();


            }

            yield return new WaitForSeconds(2f);

        }
        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave7()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        /* for (int i = 0; i < 10; i++)
         {
             SpawnEnemyTrash();
             yield return new WaitForSeconds(2f);
         }
         */
        for (int i = 0; i < 22; i++)
        {
            if (i % 2 < Mathf.Epsilon)
            {
                SpawnEnemyTrash();
            }
            if (i < 18)
            {

                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(2f);

            }
            if (i > 13 && i % 2 < Mathf.Epsilon)
            {

                SpawnEnemyCloud();
                yield return new WaitForSeconds(2f);
                SpawnEnemyCloud();


            }
            if (i == 1 || i == 10)
            {
                SpawnEnemyDump();


            }

            yield return new WaitForSeconds(2f);

        }


        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave8()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 29; i++)
        {
            if (i > 18)
            {
                for (int a = 0; a < 2; a++)
                {
                    SpawnEnemyTrash();
                    yield return new WaitForSeconds(0.5f);
                }
            }
            if (i < 18 || i > 24)
            {

                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(2f);

            }
            if (i % 3 < Mathf.Epsilon)
            {

                SpawnEnemyCloud();
                yield return new WaitForSeconds(2f);
                SpawnEnemyCloud();


            }
            if (i == 0 || i == 4 || i == 14)
            {
                SpawnEnemyDump();


            }

            yield return new WaitForSeconds(2f);

        }

        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave9()
    {

        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 37; i++)
        {
            if (i % 2 < Mathf.Epsilon)
            {
                SpawnEnemyTrash();
            }
            if (i < 17)
            {

                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(2f);

            }
            if (i > 30)
            {
                for (int a = 0; a < i - 30; a++)
                {
                    SpawnEnemyTrashCan();
                    yield return new WaitForSeconds(0.5f);
                }

            }
            if (i > 17 && i < 27)
            {

                SpawnEnemyCloud();
                yield return new WaitForSeconds(1f);
                SpawnEnemyCloud();


            }
            if (i % 5 < Mathf.Epsilon && i != 20)
            {
                SpawnEnemyDump();


            }

            yield return new WaitForSeconds(2f);

        }

        //Time between waves
        yield return new WaitForSeconds(countdown);

        //Calls the main function again
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWave10()
    {

        // Sets the incremented year value to the UI
        // Sub-Wave 1

        if (yearIndex <= 2040)
        {
            InvokeRepeating("IncrementAndSet", 0, 10f);
        }



        // Spawns enemies
        // InvokeRepeating("SpawnEnemyTrash", 1f, 2f);
        /* InvokeRepeating("SpawnEnemyDump", 5f, 8f);
         InvokeRepeating("SpawnEnemyCloud", 3f, 5f);
         InvokeRepeating("SpawnEnemyTrashCan", 3f, 5f);
         */
        for (int i = 0; yearIndex <= 2040; i++)
        {

            int trashNum = (int)(Random.value * 100);
            int cloudNum = (int)(Random.value * 100);
            int trashCanNum = (int)(Random.value * 100);
            int dumpNum = (int)(Random.value * 100);

            // StartCoroutine(BaseWave((int) time));
            // Additional wave
            if (dumpNum + i > 80)
            {
                for (int j = 0; j < i; j++)
                {
                    SpawnEnemyDump();
                    yield return new WaitForSeconds(3f);
                }
            }
            Debug.Log(trashCanNum);
            if (trashCanNum + i > 60)
            {
                
                for (int j = 0; j < 2 * i + 1; j++)
                {

                    SpawnEnemyTrashCan();
                    yield return new WaitForSeconds(1f);
                }
            }
            if (cloudNum + i > 60)
            {
                for (int j = 0; j < 2 * i + 1; j++)
                {

                    SpawnEnemyCloud();
                    yield return new WaitForSeconds(1.5f);
                }

            }
            if (trashNum + i > 50)
            {
                for (int j = 0; j < 3 * i + 1; j++)
                {
                    SpawnEnemyTrash();
                    Debug.Log("trash");
                    yield return new WaitForSeconds(0.5f);
                }
               
            }





           if (yearIndex == 2040)
            {
                StartCoroutine(SpawnWaves());
            }
            yield return new WaitForSeconds(2f);
        }

    }
   /* IEnumerator BossWave()
    {

    }*/
    /*void SpawnWave()
    {
        SpawnEnemyTrash();
        SpawnEnemyTrash();
        SpawnEnemyTrash();
        SpawnEnemyTrash();
    }*/



    void SpawnEnemyTrash()
        {
            if (enemyTrashPrefab != null)
            {
                Vector3 trashInitial = new Vector3(spawnPoint.position.x - 1, spawnPoint.position.y - 1, spawnPoint.position.z);
                // Instantiates new enemies at a certain position every second.
                Instantiate(enemyTrashPrefab, trashInitial, camRotate.transform.rotation);


            }
        }

        void SpawnEnemyDump()
        {
            if (enemyDumpPrefab != null)
            {
                Vector3 trashInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1, spawnPoint.position.z);
                // Instantiates new enemies at a certain position every second.
                Instantiate(enemyDumpPrefab, trashInitial, camRotate.transform.rotation);

            }
        }

        void SpawnEnemyCloud()
        {
            if (enemyCloudPrefab != null)
            {
                Vector3 cloudInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 8, spawnPoint.position.z);

                // Instantiates new enemies at a certain position every second.
                Instantiate(enemyCloudPrefab, cloudInitial, camRotate.transform.rotation);

            }

        }
        void SpawnEnemyTrashCan()
        {
            if (enemyTrashCanPrefab != null)
            {
                Vector3 cloudInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1, spawnPoint.position.z);

                // Instantiates new enemies at a certain position every second.
                Instantiate(enemyTrashCanPrefab, cloudInitial, camRotate.transform.rotation);

            }

        }
        void IncrementAndSet()
        {
            waveNumber++;
            yearIndex++;
            PlayerStats.Waves = yearIndex;
        }
        

    void SpawnBoss()
    {
            if (bossPrefab != null)
        {
            Vector3 boss = new Vector3(spawnPoint.position.x, spawnPoint.position.y - 2, spawnPoint.position.z);
            Instantiate(bossPrefab, boss, spawnPoint.rotation);
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
