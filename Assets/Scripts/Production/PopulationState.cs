using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationState : MonoBehaviour
{
    [SerializeField] Text populationTxt;

    private int population = 10;
    private const int minPopulation = 0;
    private int maxPopulation = 10;

    public int MaxPopulation
    {
        get => maxPopulation;
        set
        {
            maxPopulation = value;
        }
    }
    public int Population
    {
        get => population;
        set
        {
            if (value < 0)
                population = 0;
            else if (value > MaxPopulation)
                population = maxPopulation;
            else population = value;

            populationTxt.text = population.ToString();
        }
    }

    public void ChangePopulation(float satisfaction)
    {
        if (satisfaction <= 0.2f)
        {
            Population -= (int)(Population * 0.2f);
        }
        else if(satisfaction >= 0.75f)
        {
            Population += (int)(Population * 0.2f);
        }
    }

    public void SetMaxPopulation(int housesLvl)
    {
        MaxPopulation = housesLvl * 10;
    }

}
