using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public GameObject startBTN;
    public Player player;
        
    void Start()
    {
        Time.timeScale = 0f;
        
    }   

    public void StartGame()
    {
        Time.timeScale = 1f;
        startBTN.SetActive(false);
    }

    public void RefreshGame()
    {
        SceneManager.LoadScene(0);        
        
    }
}
