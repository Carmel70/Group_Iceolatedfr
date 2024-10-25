using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpeak : MonoBehaviour
{
    public float floatHeight;
    public float damping;
    public float rayLength;

    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
