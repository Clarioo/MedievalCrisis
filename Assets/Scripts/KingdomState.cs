using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KingdomState : MonoBehaviour
{

    #region
    bool isGameActive = false;
    private IEnumerator countDaysEnum;

    [SerializeField] int day = 1;
    [SerializeField] Text dayTxt;

    int nextWarDay = 9;
    public int Day
    {
        get => day;
        set
        {
            if(value >= 1)
            {
                day = value;
                dayTxt.text = day.ToString();
            }
        }
    }
    #endregion
    float seconds = 5f; //seconds represents how long day lasts
    [SerializeField] ResourcesState resourcesState;
    [SerializeField] ProductionState productionState;
    [SerializeField] PopulationState populationState;
    [SerializeField] WarState warState;

    [SerializeField] TradeManager tradeManager;
    [SerializeField] SatisfactionCtrl satisfactionCtrl;
    [SerializeField] ResourcesProductionUI resourcesProductionUI;
    [SerializeField] ResourcesUIManager resourcesUIManager;
    [SerializeField] KingdomStateUI kingdomStateUI;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject losePanel;
    private void Start()
    {
        satisfactionCtrl = GetComponent<SatisfactionCtrl>();
        productionState = GetComponent<ProductionState>();
        populationState = GetComponent<PopulationState>();
        warState = GetComponent<WarState>();
        tradeManager = GetComponent<TradeManager>();
        resourcesUIManager = GetComponent<ResourcesUIManager>();
        resourcesState = new ResourcesState(resourcesUIManager, populationState);
        kingdomStateUI = GetComponent<KingdomStateUI>();
        tradeManager.SetResourcesListToTrader(GetResState().resourcesList);

        SetUIComponents();

        countDaysEnum = CountDays(seconds); // setting coroutine as object
    }
    public ResourcesState GetResState()
    {
        return resourcesState;
    }

    public void ExecuteDayEffects()
    {
        if(Day == nextWarDay)
        {
            warState.ExecWar(resourcesState, day);
            nextWarDay = Random.Range(day + 7, day + 12);
            isGameActive = false;
            StopCoroutine(countDaysEnum);
        }
        if(Day % 7 == 0)
        {
            if (!resourcesState.ExecWeekEnd(populationState))
            {
                losePanel.SetActive(true);
                isGameActive = false;
                StopAllCoroutines();
            }
        }
        resourcesState.GetResourcesAtTheEndOfDay(productionState); //Get resources from productors
        resourcesState.ExecPlague();
        populationState.SetMaxPopulation(productionState.GetResourcesProductors()[0].BuildingLevel); //to fix
        populationState.ChangePopulation(satisfactionCtrl.Satisfaction);
        satisfactionCtrl.ChangeSatisfactionAtTheEndOfDay(resourcesState, populationState.Population);
    }
    
    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void StartGameAfterPause()
    {
        isGameActive = true;
        StartCoroutine(countDaysEnum);
    }
    public void SetUIComponents()
    {
        dayTxt = kingdomStateUI.dayTxt;
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        isGameActive = true;
        StartCoroutine(countDaysEnum);
    }

    public void StartNewDay()
    {
        ExecuteDayEffects();     
        Day++;
    }
    IEnumerator CountDays(float sec)
    {
        do
        {
            yield return new WaitForSeconds(sec);
            ExecuteDayEffects();
            Day++;
        } while (isGameActive);
        
    }
}
