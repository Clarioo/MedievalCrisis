using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoldQTE : QTEManager
{
    int housesToCollectCounter;
    int housesToCollectLimit = 3;

    #region UI Components
    [SerializeField] Transform housesPanel;
    [SerializeField] Button[] houses;
    [SerializeField] Button house;

    [SerializeField] KingdomState kingdomState;
    ResourcesState resState;
    #endregion
    public UnityEvent onHouseClick;


    public override void StartQTE(QTEType qteType, int buildingLevel)
    {
        housesToCollectLimit = buildingLevel + 5;
        housesToCollectCounter = 0;
        resState = kingdomState.GetResState();
        ManageHouses(1);
    }
    
    public void ManageHouses(int houseID)
    {
        HouseQTE houseQTE = houses[houseID].GetComponent<HouseQTE>();
        houseQTE.ShowHouseStatus();
    }

    public void ExecuteClick(HouseQTE houseQTE)
    {
        if (houseQTE.IsGoldAbleToCollect)
            CollectGold();
        else
            IrritatePeople();

        houseQTE.HideImage();
        housesToCollectCounter++;
        if(housesToCollectCounter <= housesToCollectLimit)
            ManageHouses(Random.Range(0, houses.Length)); //Show next house to collect/irritate
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
