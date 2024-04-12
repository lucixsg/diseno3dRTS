using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI numGoldText;
    public TextMeshProUGUI numMetalText;

    //public int numGold = 0;
    //public int numMetal = 0;

    public Button goldGathererButton;
    public Button metalGathererButton;
    public Button soldierButton;
    public Button heavySoldierButton;

    public PlayerBase playerBase;

    private void Start()
    {
        UpdateResourceUI();
    }

    private void UpdateResourceUI()
    {
        numGoldText.text = playerBase.numGold.ToString();
        numMetalText.text = playerBase.numMetal.ToString();
    }

    public void GenerateGoldGatherer()
    {
        if (playerBase.numGold >= 1 && playerBase.numMetal >= 5 && playerBase.currentLifePoints > 0)
        {
            playerBase.GenerateGoldGatherer();
            playerBase.numGold -= 1;
            playerBase.numMetal -= 5;
            UpdateResourceUI();
        }
    }

    public void GenerateMetalGatherer()
    {
        if (playerBase.numGold >= 5 && playerBase.numMetal >= 1 && playerBase.currentLifePoints > 0)
        {
            playerBase.GenerateMetalGatherer();
            playerBase.numGold -= 5;
            playerBase.numMetal -= 1;
            UpdateResourceUI();
        }
    }

    public void GenerateSoldier()
    {
        if (playerBase.numGold >= 15 && playerBase.numMetal >= 15 && playerBase.currentLifePoints > 0)
        {
            playerBase.GenerateSoldier();
            playerBase.numGold -= 15;
            playerBase.numMetal -= 15;
            UpdateResourceUI();
        }
    }

    public void GenerateHeavySoldier()
    {
        if (playerBase.numGold >= 30 && playerBase.numMetal >= 30 && playerBase.currentLifePoints > 0)
        {
            playerBase.GenerateHeavySoldier();
            playerBase.numGold -= 30;
            playerBase.numMetal -= 30;
            UpdateResourceUI();
        }
    }

    public void AddGold()
    {
        playerBase.AddGold(playerBase.numGold);
        UpdateResourceUI();
    }
}