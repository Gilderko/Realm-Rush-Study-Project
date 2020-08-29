using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{    
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levels;
    [SerializeField] GameObject towerChange;
    [SerializeField] GameObject towerUpgrade;
    [SerializeField] BaseTower baseTower;
    [SerializeField] QuickShotTower quickShotTower;
    [SerializeField] BurstTower burstTower;

    [SerializeField] Text baseTowerLvlText;
    [SerializeField] Text quickShotTowerLvlText;
    [SerializeField] Text burstTowerLvlText;

    [SerializeField] GoldManager goldManager;

    static bool alreadyLoaded = false;
    public static Tower selectedTower;

    GameObject activeUI;

    private void Start()
    {
        print("Stating");
        activeUI = mainMenu;        
        if (!alreadyLoaded)
        {
            print("Loading again");
            TowerFactory.towerPrefarb = baseTower;
            goldManager = FindObjectOfType<GoldManager>();
            LoadBaseTowerStats();
            LoadBurstTowerStats();
            LoadQuickshotTowerStats();
            alreadyLoaded = true;
        }        
    }

    private void Update()
    {
        baseTowerLvlText.text = "LVL " + BaseTower.towerLvl;
        quickShotTowerLvlText.text = "LVL " + QuickShotTower.towerLvl;
        burstTowerLvlText.text = "LVL " + BurstTower.towerLvl;
    }


    public void UpgradeBaseTowerStats()
    {
        if (BaseTower.towerLvl < 20 && goldManager.GetGold() >= 40)
        {        
            BaseTower.towerLvl += 1;
            BaseTower.attackSpeedUpgrade += 0.2f;
            BaseTower.particleSpeedUpgrade += 20f;
            PlayerPrefs.SetInt("baseTowerLvl", BaseTower.towerLvl);
            PlayerPrefs.SetFloat("baseTowerAttackSpeedUpgrade",BaseTower.attackSpeedUpgrade);
            PlayerPrefs.SetFloat("baseTowerParticleSpeedUpgrade",BaseTower.particleSpeedUpgrade);
            goldManager.RemoveGold(40);
        }
    }

    public void UpgradeQuickshotTowerStats()
    {
        if (QuickShotTower.towerLvl < 20 && goldManager.GetGold() >= 40)
        {
            QuickShotTower.towerLvl += 1;
            QuickShotTower.attackSpeedUpgrade += 0.4f;
            QuickShotTower.accuracyUpgrade += 0.005f;
            PlayerPrefs.SetInt("quickShotTowerLvl", QuickShotTower.towerLvl);
            PlayerPrefs.SetFloat("quickShotTowerAttackSpeedUpgrade",QuickShotTower.attackSpeedUpgrade);
            PlayerPrefs.SetFloat("quickShotTowerAttackSpeedUpgrade",QuickShotTower.accuracyUpgrade);
            goldManager.RemoveGold(40);
        }
    }

    public void UpgradeBurstTowerStats()
    {
        if (BurstTower.towerLvl < 20 && goldManager.GetGold() >= 40)
        {        
            BurstTower.towerLvl += 1;
            BurstTower.burstAttackSpeedUpgrade += 0.5f;
            BurstTower.burstFrequencyUpgrade += 0.02f;
            PlayerPrefs.SetInt("burstTowerLvl", BurstTower.towerLvl);
            PlayerPrefs.SetFloat("burstTowerAttackSpeedUpgrade", BurstTower.burstAttackSpeedUpgrade);
            PlayerPrefs.SetFloat("burstTowerFrequencyUpgrade", BurstTower.burstFrequencyUpgrade);
            goldManager.RemoveGold(40);
        }
    }

    private void LoadBaseTowerStats()
    {
        BaseTower.towerLvl = PlayerPrefs.GetInt("baseTowerLvl");
        BaseTower.attackSpeedUpgrade = PlayerPrefs.GetFloat("baseTowerAttackSpeedUpgrade");
        BaseTower.particleSpeedUpgrade = PlayerPrefs.GetFloat("baseTowerParticleSpeedUpgrade");
    }

    private void LoadQuickshotTowerStats()
    {
        QuickShotTower.towerLvl = PlayerPrefs.GetInt("quickShotTowerLvl");
        QuickShotTower.attackSpeedUpgrade = PlayerPrefs.GetFloat("quickShotTowerAttackSpeedUpgrade");
        QuickShotTower.accuracyUpgrade = PlayerPrefs.GetFloat("quickShotTowerAccuracyUpgrade");
    }

    private void LoadBurstTowerStats()
    {
        BurstTower.towerLvl = PlayerPrefs.GetInt("burstTowerLvl");
        BurstTower.burstAttackSpeedUpgrade = PlayerPrefs.GetFloat("burstTowerAttackSpeedUpgrade");
        BurstTower.burstFrequencyUpgrade = PlayerPrefs.GetFloat("burstTowerFrequencyUpgrade");
    }

    public void ResetAllUpgrades()
    {
        PlayerPrefs.DeleteKey("burstTowerLvl");
        PlayerPrefs.DeleteKey("burstTowerAttackSpeedUpgrade");
        PlayerPrefs.DeleteKey("burstTowerFrequencyUpgrade");
        PlayerPrefs.DeleteKey("quickShotTowerLvl");
        PlayerPrefs.DeleteKey("quickShotTowerAttackSpeedUpgrade");
        PlayerPrefs.DeleteKey("quickShotTowerAccuracyUpgrade");
        PlayerPrefs.DeleteKey("baseTowerLvl");
        PlayerPrefs.DeleteKey("baseTowerAttackSpeedUpgrade");
        PlayerPrefs.DeleteKey("baseTowerParticleSpeedUpgrade");

        BaseTower.attackSpeedUpgrade = 0;
        BaseTower.particleSpeedUpgrade = 0;
        QuickShotTower.attackSpeedUpgrade = 0;
        QuickShotTower.accuracyUpgrade = 0;
        BurstTower.burstAttackSpeedUpgrade = 0;
        BurstTower.burstFrequencyUpgrade = 0;

        BaseTower.towerLvl = 0;
        QuickShotTower.towerLvl = 0;
        BurstTower.towerLvl = 0;
    }
        
    public void ChangeToLevels()
    {
        activeUI.SetActive(false);
        levels.SetActive(true);
        activeUI = levels;
    }

    public void ChangeToTowerChange()
    {
        activeUI.SetActive(false);
        towerChange.SetActive(true);
        activeUI = towerChange;
    }

    public void ChangeToTowerUpgrade()
    {
        activeUI.SetActive(false);
        towerUpgrade.SetActive(true);
        activeUI = towerUpgrade;
    }

    public void ChangeToMainMenu()
    {
        activeUI.SetActive(false);
        mainMenu.SetActive(true);
        activeUI = mainMenu;
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayLevel5()
    {
        SceneManager.LoadScene(5);
    }
    public void PlayLevel6()
    {
        SceneManager.LoadScene(6);
    }
    public void PlayLevel7()
    {
        SceneManager.LoadScene(7);
    }
    public void PlayLevel8()
    {
        SceneManager.LoadScene(8);
    }

    public void ChangeTowerToBase()
    {
        TowerFactory.towerPrefarb = baseTower;
    }

    public void ChangeTowerToQuickshot()
    {
        TowerFactory.towerPrefarb = quickShotTower;
    }

    public void ChangeTowerToBurst()
    {
        TowerFactory.towerPrefarb = burstTower;
    }

    public void ExitApp()
    {
        Application.Quit();
    }

}
