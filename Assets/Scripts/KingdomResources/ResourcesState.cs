using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesState
{
    ResourcesUIManager resourcesUIManager;

    private Gold gold;
    private Wood wood;
    private Iron iron;
    private Food food;
    private Oil oil;

    public Gold Gold { get { return gold; } set { gold = value; } }
    public Wood Wood { get { return wood; } set { wood = value; } }
    public Iron Iron { get { return iron; } set { iron = value; } }
    public Food Food { get { return food; } set { food = value; } }
    public Oil Oil { get { return oil; } set { oil = value; } }

    public List<Resources> resourcesList = new List<Resources>();
    List<ResourcesProductor> productorsList = new List<ResourcesProductor>();

    public ResourcesState(ResourcesUIManager resourcesUIManager, PopulationState populationState)
    {
        this.resourcesUIManager = resourcesUIManager;
        CreateResources(populationState);
        SetResourcesUITexts();
        SetStartValues();
    }


    private void CreateResources(PopulationState populationState)
    {
        resourcesList.Add(Gold = new Gold());
        resourcesList.Add(Wood = new Wood());
        resourcesList.Add(Iron = new Iron());
        resourcesList.Add(Food = new Food());
        resourcesList.Add(Oil = new Oil());

        int id = 0;
        foreach(Resources res in resourcesList)
        {
            res.SetPopulation(populationState);
            res.SetHelperImage(resourcesUIManager.resHelperList[id]);
            id++;
        }
    }

    public void UpdateResourcesOnLevelUp(UpgradeCost upgradeCost)
    {
        Gold.Count -= upgradeCost.gold;
        Wood.Count -= upgradeCost.wood;
        Iron.Count -= upgradeCost.iron;
        Food.Count -= upgradeCost.food;
        Oil.Count -= upgradeCost.oil;
    }

    public void GetResourcesAtTheEndOfDay(ProductionState productionState)
    {
        for(int i = 0; i<productionState.GetResourcesProductors().Count; i++)
        {
            //resourcesList[i].Count += productionState.GetResourcesProductors()[i].Production;//To Change
            productionState.GetResourcesProductors()[i].StartProductorQTE();
        }
    }

    public void ExecPlague()
    {
        if(Random.Range(0, 6) == 0)
        {
            Resources plagueRes = resourcesList[Random.Range(0, 4)];
            plagueRes.Count = (int)(plagueRes.Count * 0.5f);
        }
    }
    public bool ExecWeekEnd(PopulationState populationState)
    {
        foreach(Resources res in resourcesList)
        {
            if (res.Count < populationState.Population)
                return false;
        }
        return true;
    }
    #region
    private void SetStartValues()
    {
        foreach(Resources res in resourcesList)
        {
            res.SetStartValue();
        }
    }
    public void SetResourcesUITexts()
    {
        int id = 0;
        foreach (Resources res in resourcesList)
        {
            res.SetUIText(resourcesUIManager.resTextList[id]);
            id++;
        }
        
    }
    #endregion
}



