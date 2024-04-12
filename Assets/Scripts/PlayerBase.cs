using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int maxLifePoints=30;
    public int currentLifePoints;

    public int numMetal;
    public int numGold;

    public bool isPlayer = true;

    public GameObject goldGathererPrefab;
    public GameObject metalGathererPrefab;
    public GameObject soldierPrefab;
    public GameObject heavySoldierPrefab;

    public Transform goldSpawnPoint;
    public Transform metalSpawnPoint;
    public Transform soldierSpawnPoint;
    public Transform heavySoldierSpawnPoint;

    public Transform m_GoldPoint;
    public Transform m_RunningPoint;

    public GoldGathererController goldGatherer;

    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
        goldGatherer = FindObjectOfType<GoldGathererController>();
        //goldGatherer.m_PlayerBase = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGoldGatherer()
    {
        Instantiate(goldGathererPrefab, goldSpawnPoint.position, goldSpawnPoint.rotation);
        numGold -= 1;
        numMetal -= 5;
        //goldGatherer.isPlayer = true;
        
    }

    public void GenerateMetalGatherer()
    {
        Instantiate(metalGathererPrefab, metalSpawnPoint.position, metalSpawnPoint.rotation);
        numGold -= 5;
        numMetal -= 1;
        isPlayer = true;
    }

    public void GenerateSoldier()
    {
        Instantiate(soldierPrefab, soldierSpawnPoint.position, soldierSpawnPoint.rotation);
        numGold -= 15;
        numMetal -= 15;
        isPlayer = true;
    }

    public void GenerateHeavySoldier()
    {  
        Instantiate(heavySoldierPrefab, heavySoldierSpawnPoint.position, heavySoldierSpawnPoint.rotation);
        numGold -= 30;
        numMetal -= 30;
        isPlayer = true;
    }

    public void AddGold(int gold)
    {
        numGold++;
    }
}
        