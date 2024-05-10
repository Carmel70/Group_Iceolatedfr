using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject Player;
    public GameObject OldYuno;
    public GameObject NewYuno;
    public GameObject OldCam;
    public GameObject OldVCam;
    public GameObject OldCamCol;
    public GameObject NewCam;
    public GameObject NewVCam;
    public GameObject NewCamCol;


    public GameObject oldMusic;
    public GameObject newMusic;
   // public GameObject NightMusic;


    

    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Player.transform.position = new Vector2(x, y);
  
        oldMusic.SetActive(false);

        OldCam.SetActive(false);
        OldVCam.SetActive(false);
        OldCamCol.SetActive(false);

       

        NewCam.SetActive(true);
        NewVCam.SetActive(true);
        NewCamCol.SetActive(true);

        newMusic.SetActive(true);
    }

}
