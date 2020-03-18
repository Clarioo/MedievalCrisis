using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpRequirements : MonoBehaviour
{
    int targetLevel;
    [SerializeField] private int gold;
    [SerializeField] private int wood;
    [SerializeField] private int iron;
    [SerializeField] private int food;
    [SerializeField] private int oil;

    [SerializeField] Text goldText;
    [SerializeField] Text woodText;
    [SerializeField] Text ironText;
    [SerializeField] Text foodText;
    [SerializeField] Text oilText;

    public UpgradeCost upgradeCost;

    private void Start()
    {
        SetRequirements(1);
    }
    public bool CheckRequirements(ResourcesState resourcesState)
    {
        if (!CompareResources(gold, resourcesState.Gold))
            return false;
        if (!CompareResources(wood, resourcesState.Wood))
            return false;
        if (!CompareResources(iron, resourcesState.Iron))
            return false;
        if (!CompareResources(food, resourcesState.Food))
            return false;
        if (!CompareResources(oil, resourcesState.Oil))
            return false;

        return true;
    }
    private bool CompareResources(int requirement, Resources resources)
    {
        if (resources.Count >= requirement)
        {
            return true;
        }
        else
            return false;
    }

    public void SetRequirements(int level)
    {
        upgradeCost.gold = gold * level;
        upgradeCost.wood = wood * level;
        upgradeCost.iron = iron * level;
        upgradeCost.food = food * level;
        upgradeCost.oil = oil * level;

        goldText.text = upgradeCost.gold.ToString();
        woodText.text = upgradeCost.wood.ToString();
        ironText.text = upgradeCost.iron.ToString();
        foodText.text = upgradeCost.food.ToString();
        oilText.text = upgradeCost.oil.ToString();
    }
}
public struct UpgradeCost
{
    public int gold;
    public int wood;
    public int iron;
    public int food;
    public int oil;


}

