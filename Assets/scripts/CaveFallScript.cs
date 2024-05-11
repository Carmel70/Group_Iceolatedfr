using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using UnityEngine.SceneManagement;

public class CaveFallScript : MonoBehaviour
{
    
    public float x;
    public float y;
    private playerMove health;
    public GameObject player;
    public float timeBetween;
    
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
        player.transform.position = new Vector2(x, y);
        //health.numLives--;
        Debug.Log("Lost a life");
 
    }



    public void time()
    {
        timeBetween -= Time.deltaTime;
    }
}
