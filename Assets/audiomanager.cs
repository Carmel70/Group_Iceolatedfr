using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    public GameObject ahhhhhh;
    
    private void Start()
    {
        
           sound = this.GetComponent<AudioSource>();
           

    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.W))
        {
            sound.Play();
            
        }
   
    }
    
}
