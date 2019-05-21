using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public float countdown = 1f;

    //Number of enemies
    private int yearIndex = 2018;

    private int waveNumber = 1;
    public GameObject camRotate;

    public bool waveIsComplete;
    public Button nextWave;
    public Text waveText;
    public Text nextWaveText;

    private GameObject[] enemies;
    


    // Start is called before the first frame update
    void Start()
    {
        waveIsComplete = true;

        nextWave.onClick.AddListener(Wrapper);
        //clone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(IsWaveComplete());

        if (waveIsComplete && waveNumber != 1)
        {

            waveText.text = "Wave is complete";
        }
        else
        {
            waveText.text = "";
        }
        ButtonApperance();

    }
    IEnumerator SpawnWaves()
    {
        yield return null;
        switch (waveNumber)
        {
            case 1:
                StartCoroutine(SpawnWave1());
                break;
            case 2:
                StartCoroutine(SpawnWave2());
                break;
            case 3:
                StartCoroutine(SpawnWave3());
                break;
            case 4:
                StartCoroutine(SpawnWave4());
                break;
            case 5:
                StartCoroutine(SpawnWave5());
                break;
            case 6:
                StartCoroutine(SpawnWave6());
                break;
            case 7:
                StartCoroutine(SpawnWave7());
                break;
            case 8:
                StartCoroutine(SpawnWave8());
                break;
            case 9:
                StartCoroutine(SpawnWave9());
                break;
            case 10:
                StartCoroutine(SpawnWave10());
                break;
            case 11:
                BossWave();
                break;

        }



    }
    IEnumerator SpawnWave1()
    {

        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();

        Debug.Log("Wave1");
        // Spawns enemies
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemyTrash();

        }


        enemies = GameObject.FindGameObjectsWithTag("Enemy");

       /* Debug.Log(enemies[enemies.Length - 1].GetComponent<Pathing>().OutOfBounds);
        if (enemies[enemies.Length - 1].GetComponent<Pathing>().OutOfBounds)
        {
            waveIsComplete = true;
        }*/


    }
    IEnumerator SpawnWave2()
    {

        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave2");
        // Spawns enemies
        for (int i = 0; i < 9; i++)
        {
            SpawnEnemyTrash();

            yield return new WaitForSeconds(1f);

        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");



    }
    IEnumerator SpawnWave3()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave3");
        // Spawns enemies
        for (int i = 0; i < 7; i++)
        {
            SpawnEnemyTrash();
            if (i < 3)
            {
                yield return new WaitForSeconds(1f);
                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(2f);
        }


        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }
    IEnumerator SpawnWave4()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave4");
        // Spawns enemies
        for (int i = 0; i < 10; i++)
        {
            if (i != 3)
            {
                yield return new WaitForSeconds(0.5f);
                SpawnEnemyTrash();
            }

            if (i > 2 && i < 6)
            {
                yield return new WaitForSeconds(1f);
                SpawnEnemyTrashCan();


            }
            if (i % 2 < Mathf.Epsilon && i != 6 && i != 8)
            {
                yield return new WaitForSeconds(1f);
                SpawnEnemyCloud();
            }
            yield return new WaitForSeconds(1f);
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }
    IEnumerator SpawnWave5()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave5");
        // Spawns enemies

        for (int i = 0; i < 15; i++)
        {
            if (!(i < 11 && i > 8))
            {
                SpawnEnemyTrash();
            }

            if (i > 1 && i < 7)
            {
                yield return new WaitForSeconds(1f);
                SpawnEnemyTrashCan();


            }
            if (i % 3 < Mathf.Epsilon && i != 9)
            {
                yield return new WaitForSeconds(1.7f);
                SpawnEnemyCloud();
            }
            yield return new WaitForSeconds(1.5f);
            }



        enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }
    IEnumerator SpawnWave6()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave6");
        // Spawns enemies
        for (int i = 0; i < 20; i++)
        {
            if (i > 4)
            {
                SpawnEnemyTrash();
            }
            if (i >= 0 && i <= 6)
            {
                SpawnEnemyTrash();
                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(1f);

            }
            if (i > 10 && 1 != 17)
            {
                SpawnEnemyCloud();
                yield return new WaitForSeconds(1.7f);


            }
            if (i == 6)
            {
                SpawnEnemyDump();


            }

            yield return new WaitForSeconds(1f);

        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");



    }
    IEnumerator SpawnWave7()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave7");
        // Spawns enemies

        for (int i = 0; i < 22; i++)
        {
            if (i % 2 < Mathf.Epsilon)
            {
                SpawnEnemyTrash();
                yield return new WaitForSeconds(0.5f);
                SpawnEnemyTrash();
            }
            if (i < 13)
            {

                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(1f);

            }
            if (i > 15 && i % 2 < Mathf.Epsilon && 1 != 16)
            {

                SpawnEnemyCloud();
                yield return new WaitForSeconds(2f);
                SpawnEnemyCloud();


            }
            if (i == 1 || i == 10)
            {
                SpawnEnemyDump();
                SpawnEnemyTrash();
                SpawnEnemyTrash();
            }

            yield return new WaitForSeconds(1f);

        }


        enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }
    IEnumerator SpawnWave8()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave8");
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
            if (i < 17 || i > 25)
            {

                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(0.5f);

            }
            if (i % 3 < Mathf.Epsilon && i != 9 && i != 15)
            {

                SpawnEnemyCloud();
                yield return new WaitForSeconds(2f);
                SpawnEnemyCloud();


            }
            if (i == 0 || i == 4 || i == 14)
            {
                SpawnEnemyDump();
                SpawnEnemyTrash();
                SpawnEnemyTrash();
            }

            yield return new WaitForSeconds(1f);

        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }
    IEnumerator SpawnWave9()
    {
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();
        Debug.Log("Wave9");
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
                yield return new WaitForSeconds(1.5f);

            }
            if (i > 31)
            {
                for (int a = 0; a < i - 30; a++)
                {
                    SpawnEnemyTrashCan();
                    yield return new WaitForSeconds(1f);
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
                SpawnEnemyTrash();
                SpawnEnemyTrash();
            }

            yield return new WaitForSeconds(1f);

        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }

    IEnumerator SpawnWave10()
    {
        waveIsComplete = false;

        // Sets the incremented year value to the UI
        // Sub-Wave 1

        if (yearIndex <= 2040)
        {
            InvokeRepeating("IncrementAndSet", 0, 10f);
        }

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
                enemies = GameObject.FindGameObjectsWithTag("Enemy");

            }
           
        }

    }
    void BossWave()
    {
        if (bossPrefab != null)
        {
            Quaternion boss = new Quaternion(spawnPoint.rotation.x, spawnPoint.rotation.y + 180, spawnPoint.rotation.z, spawnPoint.rotation.w);
            Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
    void IncrementAndSet()
        {
            waveNumber++;
            yearIndex++;
            PlayerStats.Waves = yearIndex;
        }

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
    void Wrapper()
    {
        if (waveIsComplete)
        {
            StartCoroutine(SpawnWaves());
        }
    }
    IEnumerator IsWaveComplete()
    {
        if (enemies != null && enemies[enemies.Length - 1] != null)
        {

            if (enemies[enemies.Length - 1].GetComponent<Pathing>().OutOfBounds)
            {

                yield return new WaitForSeconds(1.0f);
                //Debug.Log(enemies[enemies.Length - 1].GetComponent<Pathing>().OutOfBounds);
                waveIsComplete = true;
            }
        }

    }
    void ButtonApperance()
    {
        if (!waveIsComplete)
        {
            nextWaveText.text = "Wave \nrunning";
            nextWave.interactable = false;
            nextWave.GetComponent<Image>().color = Color.gray;
            

        }
        else if (waveIsComplete && waveNumber == 1)
        {
            nextWaveText.text = "Start Wave";
            nextWave.interactable = true;
            nextWave.GetComponent<Image>().color = Color.white;
        }
        else 
        {
            nextWaveText.text = "Start Next \nWave";
            nextWave.interactable = true;
            nextWave.GetComponent<Image>().color = Color.white;
        } 

    }
    void SetTransparency()
    {
        //var col = nextWave.GetComponent<Renderer>().material.color;
        //col.a = 0.5f;
    }



}

