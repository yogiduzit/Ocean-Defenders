using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //The enemy prefabs
    public Transform enemyTrashPrefab;
    public Transform enemyCloudPrefab;
    public Transform enemyDumpPrefab;
    public Transform enemyTrashCanPrefab;
    public Transform bossPrefab;

    //Enemy spawn point
    public Transform spawnPoint;

    //Wave Number
    private int yearIndex = 2019;

    //Starting Wave
    private int waveNumber = 1;

    //Camera object
    public GameObject camRotate;

    //Wave control variables
    public bool waveIsComplete;
    public Button nextWave;
    public Text waveText;
    public Text nextWaveText;
    private bool waveDeployed;

    //Array to hold enemies
    private GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        waveDeployed = false;
        waveIsComplete = true;
        nextWave.onClick.AddListener(Wrapper);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            BossWave();
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(IsWaveComplete());
        StartCoroutine(SetWaveCompleteText());
        ButtonApperance();
    }

    //Wave control 
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
        }
    }

    //Wave one
    IEnumerator SpawnWave1()
    {
        //Set control variables
        waveDeployed = false;
        waveIsComplete = false;
        // Sets the incremented year value to the UI
        IncrementAndSet();

        // Spawns enemies
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemyTrash();
        }
        //End of wave
        waveDeployed = true;
    }

    //Wave two
    IEnumerator SpawnWave2()
    {
        // Sets the incremented year value to the UI
        IncrementAndSet();
        // Spawns enemies
        for (int i = 0; i < 7; i++)
        {
            SpawnEnemyTrash();
            if (i == 4)
            {
                SpawnEnemyTrashCan();
            }
            yield return new WaitForSeconds(1f);
        }
        //End of wave
        waveDeployed = true;
    }

    //Wave three
    IEnumerator SpawnWave3()
    {
        // Sets the incremented year value to the UI
        IncrementAndSet();
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
        //End of wave
        waveDeployed = true;
    }

    //Wave four
    IEnumerator SpawnWave4()
    {
        // Sets the incremented year value to the UI
        IncrementAndSet();
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
        //End of wave
        waveDeployed = true;
    }

    //Wave five
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
        //End of wave
        waveDeployed = true;
    }

    //Wave six
    IEnumerator SpawnWave6()
    {
        // Sets the incremented year value to the UI
        IncrementAndSet();
        // Spawns enemies
        for (int i = 0; i < 20; i++)
        {
            if (i > 4)
            {
                SpawnEnemyTrash();
            }
            if (i >= 0 && i < 6)
            {
                SpawnEnemyTrash();
                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(1f);
            }
            if (i > 12 && i != 17)
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
        //End of wave
        waveDeployed = true;
    }

    //Wave seven
    IEnumerator SpawnWave7()
    {
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
            if (i < 14)
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
            if (i == 1 || i == 6 || i == 10 || i == 11)
            {
                SpawnEnemyDump();
                SpawnEnemyTrash();
                SpawnEnemyTrash();
            }
            yield return new WaitForSeconds(1f);
        }
        //End of wave
        waveDeployed = true;
    }

    //Wave eight
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
            if (i < 17 || i > 24)
            {
                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(0.5f);
            }
            if (i % 3 < Mathf.Epsilon)
            {
                SpawnEnemyCloud();
                yield return new WaitForSeconds(3f);
                SpawnEnemyCloud();
            }
            if (i == 0 || i == 4 || i == 14 || i == 17)
            {
                SpawnEnemyDump();
                SpawnEnemyTrash();
                SpawnEnemyTrash();
            }
            yield return new WaitForSeconds(1f);
        }
       //End of wave
        waveDeployed = true;
    }

    //Wave nine
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
            if (i < 19)
            {
                SpawnEnemyTrashCan();
                yield return new WaitForSeconds(1.5f);
            }
            if (i > 30)
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
            if (i > 34)
            {
                SpawnEnemyCloud();
            }
            if (i % 5 < Mathf.Epsilon)
            {
                SpawnEnemyDump();
                SpawnEnemyTrash();
                SpawnEnemyTrash();
            }

            yield return new WaitForSeconds(1f);

        }
        //End of wave
        waveDeployed = true;

    }

    //Final wave
    IEnumerator SpawnWave10()
    {
        //Base wave
        InvokeRepeating("SpawnEnemyTrash", 0f, 1f);
        InvokeRepeating("SpawnEnemyTrashCan", 0f, 5f);
        InvokeRepeating("SpawnEnemyCloud", 0f, 6f);
        InvokeRepeating("SpawnEnemyDump", 0f, 8f);
        InvokeRepeating("SpawnEnemyTrashCan", 10f, 5.5f);
        InvokeRepeating("SpawnEnemyTrashCan", 60f, 1f);
        //Set years to ten seconds long in final wave
        InvokeRepeating("IncrementAndSet", 0, 10f);
        
        //Additional random enemies spawned during final
        for (int i = 0; yearIndex <= 3000; i++)
        {
            int trashNum = (int)(Random.value * 100);
            int cloudNum = (int)(Random.value * 100);
            int trashCanNum = (int)(Random.value * 100);
            int dumpNum = (int)(Random.value * 100);

            // Additional wave
            if (dumpNum + i > 80)
            {
                for (int j = 0; j < i; j++)
                {
                    SpawnEnemyDump();
                    yield return new WaitForSeconds(1f);
                }
            }
            if (trashCanNum + i > 65)
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
                    yield return new WaitForSeconds(1f);
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
            //Spawns the boss near the beginning of the wave
            if (i == 2)
            {
                BossWave();
            }
        }
        waveDeployed = true;
    }

    //Spawns the boss
    void BossWave()
    {
        if (bossPrefab != null)
        {
            Quaternion boss = new Quaternion(spawnPoint.rotation.x, spawnPoint.rotation.y + 180, spawnPoint.rotation.z, spawnPoint.rotation.w);
            Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    //Increments and sets the new wave number as the year
    void IncrementAndSet()
        {
            waveNumber++;
            yearIndex++;
            PlayerStats.Waves = yearIndex;
        }

    //Spawns an enemy trash prefab
    void SpawnEnemyTrash()
    {
        if (enemyTrashPrefab != null)
        {
            Vector3 trashInitial = new Vector3(spawnPoint.position.x - 2, spawnPoint.position.y - 1, spawnPoint.position.z);
            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyTrashPrefab, trashInitial, spawnPoint.rotation);
        }
    }

    //Spawns an enemy dump prefab
    void SpawnEnemyDump()
    {
        if (enemyDumpPrefab != null)
        {
            Vector3 trashInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1, spawnPoint.position.z);
            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyDumpPrefab, trashInitial, spawnPoint.rotation);
        }
    }

    //Spawns an enemy cloud prefab
    void SpawnEnemyCloud()
    {
        if (enemyCloudPrefab != null)
        {
            Vector3 cloudInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 8, spawnPoint.position.z);

            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyCloudPrefab, cloudInitial, spawnPoint.rotation);
        }
    }

    //Spawns an enemy trashcan prefab
    void SpawnEnemyTrashCan()
    {
        if (enemyTrashCanPrefab != null)
        {
            Vector3 cloudInitial = new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1, spawnPoint.position.z);
            // Instantiates new enemies at a certain position every second.
            Instantiate(enemyTrashCanPrefab, cloudInitial, spawnPoint.rotation);
        }
    }

    //Controls waves
    void Wrapper()
    {
        if (waveIsComplete)
        {
            waveDeployed = false;
            waveIsComplete = false;
            StartCoroutine(SpawnWaves());
        }
    }

    //Checks if wave is running
    IEnumerator IsWaveComplete()
    {
        if (waveDeployed && enemies.Length < 1)
        {
            yield return null;
            waveIsComplete = true;
            waveDeployed = false;
        }
    }

    //Controls the button to spawn waves
    void ButtonApperance()
    {
        if (!waveIsComplete)
        {
            nextWaveText.text = "Wave \nOngoing";
            nextWave.interactable = false;
            nextWave.GetComponent<Image>().color = Color.gray;
        }
        else if (waveIsComplete && waveNumber == 1)
        {
            nextWaveText.text = "Start Wave";
            nextWave.interactable = true;
            nextWave.GetComponent<Image>().color = Color.white;
        }
        else if (waveIsComplete)
        {
            nextWaveText.text = "Start Next \nWave";
            nextWave.interactable = true;
            nextWave.GetComponent<Image>().color = Color.white;
        } 
    }

    //Displays text when wave is completed
    IEnumerator SetWaveCompleteText()
    {
        yield return new WaitForSeconds(1.0f);
        if (waveIsComplete && waveNumber != 1)
        {

            waveText.text = "Wave is complete";
        }
        else
        {
            waveText.text = "";
        }
    }
}

