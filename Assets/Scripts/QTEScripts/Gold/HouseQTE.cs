using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseQTE : MonoBehaviour
{
    private bool isGoldAbleToCollect;
    public bool IsGoldAbleToCollect
    {
        get => isGoldAbleToCollect;
        set
        {
            if (value)
            {
                isGoldAbleToCollect = value;
                ShowGoldToCollect();
            }
            else
                isGoldAbleToCollect = value;
        }
    }
    [SerializeField] Image goldImage;
    [SerializeField] Image pitchforkImage;
    IEnumerator statusImageTimer;

   
    public void ShowHouseStatus()
    {
        statusImageTimer = ShowStatusImages(2f);
        if(gameObject.activeSelf)
            StartCoroutine(statusImageTimer);
        if (Random.Range(0, 2).Equals(1))
            IsGoldAbleToCollect = true;
        else
            ShowPitchfork();
    }
    
    public void ShowGoldToCollect()
    {
        goldImage.gameObject.SetActive(true);
    }
    public void ShowPitchfork()
    {
        pitchforkImage.gameObject.SetActive(true);
    }
    public void HideImage()
    {
        IsGoldAbleToCollect = false;
        goldImage.gameObject.SetActive(false);
        pitchforkImage.gameObject.SetActive(false);
    }

    IEnumerator ShowStatusImages(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideImage();
    }

}
