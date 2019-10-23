using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void Options()
    {

    }

    public void Claustrophobia()
    {
        SceneManager.LoadScene(1);

    }


    public void acrophobia()
    {
        SceneManager.LoadScene(2);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
