using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{    
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levels;
    [SerializeField] GameObject towerChange;
    [SerializeField] GameObject towerUpgrade;
    [SerializeField] Tower baseTower;
    [SerializeField] Tower quickshotTower;
    public static Tower selectedTower;

    GameObject activeUI;

    private void Start()
    {
        activeUI = mainMenu;
        TowerFactory.towerPrefarb = baseTower;
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

    public void ChangeTowerToBase()
    {
        TowerFactory.towerPrefarb = baseTower;
    }

    public void ChangeTowerToQuickshot()
    {
        TowerFactory.towerPrefarb = quickshotTower;
    }
}
