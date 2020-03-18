using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTradeCount : MonoBehaviour
{
    [SerializeField] Text tradeCountText;
    [SerializeField] TradeManager tradeManager;
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetCurrentTradeCount()
    {
        int value = 0;
        if(tradeManager.currentResourcesToSell != null)
            value = (int)(slider.value * tradeManager.currentResourcesToSell?.Count);
        tradeCountText.text = value.ToString();
    }
    public void Trade(Text text)
    {
        tradeManager.TradeResources(int.Parse(text.text));
    }
}
