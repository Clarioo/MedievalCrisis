using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesProductor : MonoBehaviour
{
    [SerializeField] ProductionType productionType;

    private int buildingLevel = 1;
    private const int minBuildingLevel = 1;
    private const int maxBuildingLevel = 10;
    private Text buildingLevelTxt;
    private Text outsideLevelTxt;

    private int production = 2;
    private const int minProduction = 0;
    private const int maxProduction = 100;
    private Text productionTxt;

    private float efficiency;
    private const float minEfficiency = 0f;
    private const float maxEfficiency = 1f;
    private Text efficiencyTxt;

    [SerializeField] QTEManager productionQTE;
    [SerializeField] ResourcesProductionUI resourcesProductionUI;
    [SerializeField] LevelUpRequirements levelUpRequirements;
    [SerializeField] KingdomState kingdomState;


    public int BuildingLevel
    {
        get { return buildingLevel; }
        set
        {
            if (value >= minBuildingLevel && value <= maxBuildingLevel)
            {
                buildingLevel = value;
                SetLevelOnUI(value);
            }
        }
    }
    public int Production
    {
        get { return production; }
        set
        {
            if(value >= minProduction && value <= maxProduction)
            {
                production = value;
                SetProductionOnUi(value);
            }
        }
    }
    private void Start()
    {
        SetUIComponents();
    }

    public void StartProductorQTE()
    {
        productionQTE?.StartQTE(QTEType.Gold, BuildingLevel);
    }

    public void LevelUpBuilding()
    {
        if (levelUpRequirements.CheckRequirements(kingdomState.GetResState()))
        {
            BuildingLevel ++;
            Production = buildingLevel * 5;
            kingdomState.GetResState().UpdateResourcesOnLevelUp(levelUpRequirements.upgradeCost);
            levelUpRequirements.SetRequirements(BuildingLevel);
        }
    }

    
    private void SetLevelOnUI(int value)
    {
        buildingLevelTxt.text = value.ToString();
        outsideLevelTxt.text = value.ToString();
    }
    private void SetProductionOnUi(int value)
    {
        productionTxt.text = value.ToString();
    }

    private void SetUIComponents()
    {
        buildingLevelTxt = resourcesProductionUI.productorLevelTxt;
        productionTxt = resourcesProductionUI.productorProductionTxt;
        outsideLevelTxt = resourcesProductionUI.outsideLevelText;
    }

}

public enum ProductionType {
    Gold = 0,
    Wood = 1,
    Iron = 2,
    Food = 3,
    Oil = 4
}
