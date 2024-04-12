using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int enemySpawnInterval = 30; // Intervalo de generación de NPC enemigos en segundos
    public GameObject[] enemyNPCPrefabs; // Array de prefabs de NPC enemigos a generar

    private float spawnTimer = 0;

    public Transform goldSpawnPoint;
    public Transform metalSpawnPoint;
    public Transform soldierSpawnPoint;
    public Transform heavySoldierSpawnPoint;

    public Transform m_GoldPoint;
    public Transform m_RunningPoint;

    public GoldGathererController goldGatherer;

    public bool isPlayer=false;

    void Start()
    {
        currentHealth = maxHealth;
        goldGatherer = FindObjectOfType<GoldGathererController>();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= enemySpawnInterval)
        {
            SpawnEnemyNPC();
            spawnTimer = 0;
        }
    }

    void SpawnEnemyNPC()
    {
        // Elegir aleatoriamente un prefab de NPC enemigo del array
        GameObject randomEnemyPrefab = enemyNPCPrefabs[Random.Range(0, enemyNPCPrefabs.Length)];

        // Generar NPC enemigo en una posición específica
        if(randomEnemyPrefab.CompareTag("GoldGatherer"))
        {
           // goldGatherer.isPlayer = true;
            // FindObjectsOfType<>;
            Instantiate(randomEnemyPrefab, goldSpawnPoint.position, goldSpawnPoint.rotation);
        }
        else if (randomEnemyPrefab.CompareTag("MetalGatherer"))
        {
            Instantiate(randomEnemyPrefab, metalSpawnPoint.position, metalSpawnPoint.rotation);
        }
        else if (randomEnemyPrefab.CompareTag("Soldier"))
        {
            Instantiate(randomEnemyPrefab, soldierSpawnPoint.position, soldierSpawnPoint.rotation);
        }
        else if(randomEnemyPrefab.CompareTag("HeavySoldier"))
        {
            Instantiate(randomEnemyPrefab, heavySoldierSpawnPoint.position, heavySoldierSpawnPoint.rotation);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // La base enemiga ha sido destruida
            Destroy(gameObject);
        }
    }
}
