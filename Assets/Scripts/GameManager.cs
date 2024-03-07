using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject menu;

    [SerializeField] private int score = 0;
    [SerializeField] private ScoreSystem scoreSystem;

    
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private Ennemy[] enemies;
    private Coroutine SpawningEnemies = null;

    [SerializeField] private Star[] stars;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Singleton for Game Manager already exist, destroying the old one");
            Destroy(Instance.gameObject);
        }   
        Instance = this;      
    }

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        player.SetActive(false);
        StartCoroutine(SpawnStars());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        if(!menu.activeInHierarchy)
        {
            score++;
            scoreSystem.UpdateScore(score);
        }
    }

    public void PlayGame()
    {
        score = 0;
        scoreSystem.UpdateScore(score);
        menu.SetActive(false);
        player.SetActive(true);
        SpawningEnemies = StartCoroutine(SpawnEnemy());
    }

    public void GameOver()
    {
        menu.SetActive(true);
        player.SetActive(false);
        StopCoroutine(SpawningEnemies);
    }

    private IEnumerator SpawnEnemy()
    {
        spawnRate = 1f;
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randSpawn = Random.Range(0, enemySpawners.Length - 1);
            int randEnemy = Random.Range(0,enemies.Length - 1);
            enemySpawners[randSpawn].Spawn(enemies[randEnemy]);

            if(spawnRate > 0.2f)
                spawnRate -= 0.01f;
        }
    }

    private IEnumerator SpawnStars()
    {
        while (true)
        {
            int randTime = Random.Range(0, 3);
            yield return new WaitForSeconds(randTime);
            int randStar = Random.Range(0, stars.Length - 1);
            Instantiate(stars[randStar]);
        }

        
    }
}
