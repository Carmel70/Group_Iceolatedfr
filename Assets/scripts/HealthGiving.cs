using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthGiving : MonoBehaviour
{

    private playerMove health;
    public GameObject player;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        health.numLives++;
        Debug.Log("Gained a life");
        Destroy(healthbar);

        if (health.numLives > 3)
        {
            health.numLives -= 1;
        }
    }
}