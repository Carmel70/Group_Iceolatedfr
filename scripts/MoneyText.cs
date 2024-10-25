using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyText : MonoBehaviour
{
    private playerMove moneyNum;
    public Text MoneyNum;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        moneyNum = player.GetComponent<playerMove>();
    }
   // public void MoneyChange()
    //{
    //    MoneyNum.text = "-" + moneyNum.Money;
   // }
      
    // Update is called once per frame
    void Update()
    {
        MoneyNum.text = "-" + moneyNum.Money;
    }
}
