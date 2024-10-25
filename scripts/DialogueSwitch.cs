using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSwitch : MonoBehaviour
{
    public GameObject OldDialogue;
    public GameObject NewDialogue;

    private playerMove PleaseMove;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PleaseMove = player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDialogue()
    {
        OldDialogue.SetActive(false);
        NewDialogue.SetActive(true);
    }

    public void EndDialogue()
    {
        OldDialogue.SetActive(false);
        NewDialogue.SetActive(false);
        PleaseMove.ShopOpen = false;
    }
}
