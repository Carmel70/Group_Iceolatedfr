using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio4 : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    public GameObject ahhhhhh;
    private void Start()
    {

        sound = this.GetComponent<AudioSource>();


    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.D))
        {
            sound.Play();

        }

    }
    
}
