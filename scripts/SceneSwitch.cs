using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public String varname;
    //public GameObject teleporter;
    // Start is called before the first frame update
    public void NextScene()
    {
        SceneManager.LoadScene(varname);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hit");
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(varname);
        }
        
    }
}
