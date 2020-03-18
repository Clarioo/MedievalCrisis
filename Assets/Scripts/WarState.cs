using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarState : MonoBehaviour
{
    int kingdomPopulation;
    int enemyPopulation;
    int winChance;
    #region

    public int KingdomPopulation
    {
        get => kingdomPopulation;
        set
        {
            if (value > 0)
            {
                kingdomPopulation = value;
                WarStateUI.kingdomPopulationTxt.text = "KINGDOM POPULATION: " + kingdomPopulation.ToString();
            }
        }
    }
    public int EnemyPopulation
    {
        get => enemyPopulation;
        set
        {
            if (value > 0)
            {
                enemyPopulation = value;
                WarStateUI.enemyPopulationTxt.text = "ENEMY POPULATION: " + enemyPopulation.ToString();
            }
        }
    }
    public int WinChance
    {
        get => winChance;
        set
        {
            if (value > 0)
            {
                winChance = value;
                WarStateUI.winChanceTxt.text = "WIN CHANCE: " + winChance.ToString() + "%";
            }
        }
    }
    #endregion
    WarStateUI WarStateUI;
    PopulationState populationState;
    ResourcesState resourcesState;
    SatisfactionCtrl satisfactionCtrl;

    private void Start()
    {
        WarStateUI = GetComponent<WarStateUI>();
        populationState = GetComponent<PopulationState>();
        satisfactionCtrl = GetComponent<SatisfactionCtrl>();
    }
    public void ExecWar(ResourcesState resourcesState, int day)
    {
        this.resourcesState = resourcesState;
        EnemyPopulation = Random.Range(day, day * 2);
        KingdomPopulation = populationState.Population;
        WinChance = CalculateChances(KingdomPopulation, EnemyPopulation);
        WarStateUI.ShowWarAllertPanel();
    }

    public void AcceptWar()
    {
        if(Random.Range(0, 100) >= 100-winChance)
        {
            WinWar();
        }
        else
        {
            LoseWar();
        }
    }
    public void Surrender()
    {
        foreach(Resources res in resourcesState.resourcesList)
        {
            res.Count =(int)(res.Count * (Random.Range(4, 8) * 0.1f));
        }
        WarStateUI.CloseWarAllertPanel();
    }
    private void WinWar()
    {
        float satisfactionUpdate = 0.1f;
        WarStateUI.ShowWinWarPanel(satisfactionUpdate);
        resourcesState.resourcesList[Random.Range(0, 4)].Count += Random.Range(populationState.Population, populationState.Population*3);
        satisfactionCtrl.Satisfaction += satisfactionUpdate;
    }
    private void LoseWar()
    {
        float satisfactionUpdate = 0.1f;
        WarStateUI.ShowLoseWarPanel(satisfactionUpdate);
        foreach(Resources res in resourcesState.resourcesList)
        {
            res.Count = (int)(res.Count * 0.4f);
        }
        populationState.Population = (int)(populationState.Population / 2);
        satisfactionCtrl.Satisfaction -= satisfactionUpdate;

    }
    private int CalculateChances(int kingdomPop, int enemyPop)
    {
        if (kingdomPop < enemyPop)
        {
            float chances = (kingdomPop*1f / enemyPop * 100f);
            return (int)(chances);
        }
        else
            return 100;
    }
}

