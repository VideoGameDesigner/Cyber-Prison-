using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   // this let's me access any scene by simply typing in the scenename itself
   // and laoding the scene based on it's name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    // let's you quit the game outright but it won't work in the editor
    //it's meant to be used on a built game
    {
        Application.Quit();
        Debug.Log("You Have exited the game");
    }

}
