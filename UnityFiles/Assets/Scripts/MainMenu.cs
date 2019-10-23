using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // player position x: 32.49 y:9.96212 z:10.78383
    public GameObject player;
    public GameObject menu;


    private void Start()
    {
        menu.SetActive(true);
        player.transform.position = new Vector3(32.49f, 71, 121.6f);
    }


    public void playGame(){
        player.transform.position = new Vector3(32.49f, 9.96212f, 10.78383f);
        menu.SetActive(false);
    }

    public void quitGame(){
        Application.Quit();
    }

}