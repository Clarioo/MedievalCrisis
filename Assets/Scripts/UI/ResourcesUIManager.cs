using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUIManager : MonoBehaviour
{
    public Text goldText;
    public Text woodText;
    public Text ironText;
    public Text foodText;
    public Text oilText;

    public Image goldInfoHelper;
    public Image woodInfoHelper;
    public Image ironInfoHelper;
    public Image foodInfoHelper;
    public Image oilInfoHelper;

    public List<Text> resTextList = new List<Text>();
    public List<Image> resHelperList = new List<Image>();

    private void Start()
    {
        resTextList.Add(goldText);
        resTextList.Add(woodText);
        resTextList.Add(ironText);
        resTextList.Add(foodText);
        resTextList.Add(oilText);

        resHelperList.Add(goldInfoHelper);
        resHelperList.Add(woodInfoHelper);
        resHelperList.Add(ironInfoHelper);
        resHelperList.Add(foodInfoHelper);
        resHelperList.Add(oilInfoHelper);

    }

}
