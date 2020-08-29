using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    private static int totalGold = 0;
    private static bool alreadyLoaded = false;
    [SerializeField] Text goldText;

    private void Start()
    {
        if (!alreadyLoaded)
        {
            totalGold = PlayerPrefs.GetInt("totalGold");
            goldText.text = "Gold: " + totalGold.ToString();
        }
    }

    private void SetGoldAndSaveGold()
    {
        PlayerPrefs.SetInt("totalGold", totalGold);
        goldText.text = "Gold: " + totalGold.ToString();
    }

    public void AddGold(int addAmount)
    {
        totalGold += addAmount;
        SetGoldAndSaveGold();
    }

    public void RemoveGold(int removeAmount)
    {
        totalGold -= removeAmount;
        SetGoldAndSaveGold();
    }

    public int GetGold()
    {
        return totalGold;
    }

    public void ResetGold()
    {
        PlayerPrefs.DeleteKey("totalGold");
        goldText.text = "Gold: 0";
    }
}
