using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatStuff : MonoBehaviour
{
    public float maxHP = 100f;
    public float HPRegenRate = 2f;
    public float currentHP;
    public float defense = 100f;

    public HPBar HPBar;
    public LivesUIScript livesUI;
    public MiddleWarning middleWarning;
    public ScoreCounter scoreCounter;

    public int playerLives = 3;

    public float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        HPBar.SetMaxHP(maxHP);
        HPBar.SetHP(currentHP);
        livesUI.updateLives(playerLives);
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = Utils.UpdateEnergyCapped(currentHP, maxHP, HPRegenRate);
        HPBar.SetHP(currentHP);
    }

    public void takeDamage(float attack)
    {
        //Debug.Log("ENEMY BALL COLLIDED WITH PLAYER");
        currentHP -=  attack * 100/defense;
        checkAlive();
    }

    void checkAlive()
    {
        if (currentHP < 0f)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        currentHP = maxHP;
        this.GetComponent<PlayerMovementScript>().resetPlayerPos();
        if (playerLives > 0)
        {
            middleWarning.textForTime("You died", 4f);
            if (playerLives == 1)
            {
                middleWarning.textForTime("You died \n this is your last life", 4f);
            }
            playerLives--;
            livesUI.updateLives(playerLives);
        }
        else
        {
            // You lost
            middleWarning.textForTime("Game over", 10000f);
            this.GetComponent<PlayerMovementScript>().controller.enabled = false;
        }
    }

    public void award(float a)
    {
        score += a;
        scoreCounter.updateScore(score);
    }
}
