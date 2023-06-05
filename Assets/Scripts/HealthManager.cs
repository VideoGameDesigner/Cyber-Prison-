using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{


    public Image healthbar; // this let's me access the image I made for the UI
    public float healthamount = 100f; // this si to ste the players health which will be 100
    public GameOver GameOverscript; // this is used to reference the game overscript I made earlier
    private bool isdead; // to check if the player is trully dead
    public GameObject player; // to reference the player
    public PlayerMovement playerfreeze;

    public void Update()
        // so basically when the player has zero or less health and the player is not dead then turn on the game over screen
        // set is dead to true and trun off the player game object that wya th eplayer still cna't movewhen the game is over
    {
        if (healthamount <= 0&& !isdead)
        {
            isdead = true;
            //player.SetActive(false);
            GameOverscript.gameover();
            player.GetComponent<SpriteRenderer>().enabled = false;
            PlayerMovement.MovementSpeed = 0;
            PlayerMovement.JumpForce = 0;
            player.GetComponent<Animator>().enabled = false;
            
        }

        if (isdead == false)

        {
            PlayerMovement.MovementSpeed = 6;
            PlayerMovement.JumpForce = 7;
            
        }
    }


    public void TakeDamage(float damage)
        // this public method let's the player take damage and reduce the health.
        // the float damage let's me decide by how much damage
    {
        healthamount -= damage;
        healthbar.fillAmount = healthamount / 100f;
        
    }

    public void Heal(float healingamount)
        // this public void let's the player heal from damage and restore there health.
        // the float healingamount let's me decide by much healing
    {
        healthamount += healingamount;
        healthamount = Mathf.Clamp(healthamount, 0, 100);

        healthbar.fillAmount = healthamount / 100f;
    }

}
