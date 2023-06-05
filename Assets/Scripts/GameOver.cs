using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameoverUI;// used to reference the game over UI I created as a game object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameover()
    {
        gameoverUI.SetActive(true);// this will alwyas be set to true because i disabled the gameover screen at the very start
        // so i don't need to set it to false as soon as the game starts
    }

    public void Restart()
    {
        //this finds the current scene and reloods it since it's absed in the UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
        // let's you quit the game outright but it won't work in the editor
        //it's meant to be used on a built game
    {
        Application.Quit();
        Debug.Log("You Have extied the game");
    }
}
