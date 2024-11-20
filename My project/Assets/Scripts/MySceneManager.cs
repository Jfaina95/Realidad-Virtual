using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void ChangeSceneByNumber(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void QuitGame()
    {
        Debug.Log("Cierro el Juego");
        Application.Quit();
    }

}
