using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    GoldManager goldManager;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);  
    }
}
