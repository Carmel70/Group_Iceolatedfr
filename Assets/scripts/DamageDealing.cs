using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageDealing : MonoBehaviour
{

    private playerMove health;
    public GameObject player;

    
    public bool isInvincible;
    public float invincibleTimer;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<playerMove>();
        isInvincible = false;
        invincibleTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible == true)
        {
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer <= .1) 
            {
                isInvincible = false;
                invincibleTimer = 1;

            }
        }

        if (health.numLives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isInvincible)
        {
            health.numLives--;
            isInvincible = true;
            Debug.Log("Lost a life");
        }
        

    }
}
