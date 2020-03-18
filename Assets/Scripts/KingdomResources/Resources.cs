using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources
{
    private int count;
    private const int minValue = 0;
    private const int maxValue = 999;
    private const int startValue = 15;
    private Text UItext;
    private Image resCountHelper;
    private PopulationState populationState;

    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            if (value >= minValue && value <= maxValue)
            {
                count = value;
                SetOnUI(value);
            }
        }
    }
    
    public void SetPopulation(PopulationState populationState)
    {
        this.populationState = populationState;
    }
    public void SetHelperImage(Image resCountHelper)
    {
        this.resCountHelper = resCountHelper;
    }
    public void SetUIText(Text UIText)
    {
        this.UItext = UIText;
    }
    private void SetOnUI(int value)
    {
        UItext.text = value.ToString();
        if(value >= populationState.Population)
        {
            resCountHelper.color = new Color(0, 255, 0);
        }
        else
        {
            resCountHelper.color = new Color(255, 0, 0);
        }
    }
    public void SetStartValue()
    {

        Count = startValue;
    }
}


