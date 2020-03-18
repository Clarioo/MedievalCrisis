using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoldQTE : QTEManager
{
    [SerializeField] Transform housesPanel;
    [SerializeField] Button[] houses;
    [SerializeField] Button house;

    [SerializeField] KingdomState kingdomState;
    ResourcesState resState;

    public UnityEvent onHouseClick;


    public override void StartQTE(QTEType qteType, int buildingLevel)
    {
        resState = kingdomState.GetResState();
        
        houses = new Button[3]; 
        for(int i = 0; i < 3; i++)
        {
            Button houseButton = GameObject.Instantiate(house, housesPanel);
            houses[i] = houseButton;
        }
        ManageHouses();
    }
    
    public void ManageHouses()
    {
        foreach(Button house in houses)
        {
            HouseQTE houseQTE = house.GetComponent<HouseQTE>();
            houseQTE.ShowHouseStatus();
        }
    }

    public void ExecuteClick(HouseQTE houseQTE)
    {
        if (houseQTE.IsGoldAbleToCollect)
            CollectGold();
        else
            IrritatePeople();

        houseQTE.HideImage();
    }
    public void CollectGold()
    {
        Debug.Log("collected");
    }
    public void IrritatePeople()
    {
        Debug.Log("Irritated");
    }


}
