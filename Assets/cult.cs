using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cult : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ahhhhhh;
    public GameObject ahhhhh;
    public GameObject ahhhh;
    public GameObject ahhh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            ahhhhhh.SetActive(false);
            ahhhhh.SetActive(false);
            ahhhh.SetActive(false);
            ahhh.SetActive(false);


        }
    }
}
