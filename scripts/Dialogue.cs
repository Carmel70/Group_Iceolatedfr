using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
   // public GameObject oldDialogue;
    public GameObject newDialogue;
    public GameObject canvas;
    //public GameObject ob;

    public float timeStop;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (timeStop > 0)
            {
                timeStop -= Time.deltaTime;

                if (timeStop <= 0)
                {
                    newDialogue.SetActive(false);
                    canvas.SetActive(false);
                    isOpen = false;
                    timeStop = 5;
                }
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //oldDialogue.SetActive(false);
        newDialogue.SetActive(true);
        canvas.SetActive(true);
        isOpen = true;
        //ob.SetActive(false);
    }
}
