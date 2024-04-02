using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private playerMove bool_script;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        bool_script = player.GetComponent<playerMove>();
       

    }

    // Update is called once per frame
    void Update()
    {
        bool lightStatus = bool_script.LightIsOn;
        bool hasLantern = bool_script.HasLantern;
        int money = bool_script.PlayerMoney;
    }


    
}
