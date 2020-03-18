using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactionCtrl : MonoBehaviour
{
    float satisfaction = 0.5f;
    float minSatisfaction = 0;
    float maxSatisfaction = 1f;

    [SerializeField] Text satisfactionTxt;

    public float Satisfaction
    {
        get => satisfaction;
        set
        {
            if (value < minSatisfaction)
                satisfaction = 0;
            else if (value > maxSatisfaction)
                satisfaction = 1;
            else
                satisfaction = value;

            satisfactionTxt.text = Satisfaction.ToString();
        }
    }


    public void ChangeSatisfactionAtTheEndOfDay(ResourcesState resourcesState, int population)
    {
        if (ArePeopleSatisfied(resourcesState, population))
        {
            Satisfaction += 0.05f;
        }
        else
            Satisfaction -= 0.05f;

        Satisfaction = ((int)(Satisfaction * 100f)) / 100f;
    }
    public bool ArePeopleSatisfied(ResourcesState resourcesState, int population)
    {
        foreach(Resources res in resourcesState.resourcesList)
        {
            if(res.Count <= population)
            {
                return false;
            }
        }
        return true;
    }


}
