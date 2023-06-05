using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PauseManager : MonoBehaviour
{
    // reference the input player
    PlayerInputActions action;

    // help to freeze player movement while game is pause
    public PlayerMovement freeze;

    // helps make the pause screen appear while the game is paused
    public GameObject PauseMenu;
    
    // Used to help other scritps react properly when the game is paused
    public static bool paused = false;

    // so even before start set the actions as new PlayerInputActions so that weay i can add new buttons to it
    private void Awake()
    {
        action = new PlayerInputActions();
    }

    // To activate and deactive the gamepad input
    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    //  if i want erverything to freeze as in pause then this code below will activate
    public void PauseGame()

    {
        Time.timeScale = 0;
        paused = true;
        //Time.timescale doesn't pause everythign so i needed this below to dsiable able the movement script
        freeze.GetComponent<PlayerMovement>().enabled = false;
        PauseMenu.SetActive(true);
        AudioListener.pause = true;
    }

    // when I press the pause button again everythign will unfreeze
    public void Resume()

    {
        Time.timeScale = 1;
        paused = false;
        freeze.GetComponent<PlayerMovement>().enabled = true;
        PauseMenu.SetActive(false);
        AudioListener.pause = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // let's me refernce the specfic button i mapped in the new input screen
        action.Player.Pause_resume.performed += _ => Determinepause();
    }

    // this code is pretty neat it let's the same button do 2 different things
    // when i press the puase button the game will freeze and when I press
    //it again it will unfreeze
    private void Determinepause()
    {
        if (paused)
            Resume();
        else
            PauseGame();
    }

    


    


    // Update is called once per frame
    void Update()
    {
        
    }
}
