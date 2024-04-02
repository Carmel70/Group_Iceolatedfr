using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
    private playerMove bool_script;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        bool_script = player.GetComponent<playerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }


    }

    public void DisplayDialog()
    {
        
        Debug.Log("hit success");
        bool_script.ShopOpen = true;
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public void RemoveDialog()
    {
        bool_script.ShopOpen = false;
        dialogBox.SetActive(false);
    }
}
