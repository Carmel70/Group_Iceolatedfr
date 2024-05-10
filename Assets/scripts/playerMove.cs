using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using WorldTime;

public class playerMove : MonoBehaviour
{
    public bool ShopOpen;
    public bool canPlay = false;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;
    Vector2 lookDirection = new Vector2(1, 0);
    public GameObject Cat;
    public float LightTime;
    public float EnergyTime;

    public int numLives;

    Animator animator;
    Animator animator1;

    public GameObject LaternUiOff;
    public GameObject LaternUiOn;
    public GameObject LaternLightSource;
    public GameObject Manager;
    public GameObject EnergyUneaten;
    public GameObject EnergyEaten;

    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject Health0;
    public GameObject lowHealthVillage;
    public GameObject lowHealthShop;
    public GameObject lowHealthCabin;
    // public GameObject lowHealthCave;

    //public GameObject NightMusic;

    public int Money;
    public bool HasLatern;
    public bool HasIcePick;
    public bool LightOn;
    public bool LaternLightOn;
    public bool HasEnergyBar;
    public bool WasEaten;

    private bool gameBeaten;

    public GameObject finishGame;


    private WorldLight musicChange;
    // public GameObject tele;
    public GameObject currentMusic;




    // Start is called before the first frame update
    void Start()
    {
        currentMusic.SetActive(true);
        //musicChange = tele.GetComponent<WorldLight>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        //timer = changeTime;
        animator = GetComponent<Animator>();
        animator1 = Cat.GetComponent<Animator>();
        ShopOpen = false;
        HasLatern = false;
        HasEnergyBar = false;
        HasIcePick = false;
        LightOn = false;
        LaternLightOn = false;
        WasEaten = false;
        gameBeaten = false;

        if (LaternLightOn == false)
        {
            LaternLightSource.SetActive(false);
        }


        LightTime = 0f;
        EnergyTime = 0f;


        LaternUiOff.SetActive(false);
        LaternUiOn.SetActive(false);
        LaternLightSource.SetActive(false);
        EnergyUneaten.SetActive(false);
        EnergyEaten.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

        if (numLives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (ShopOpen == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontal, vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();

                animator.SetFloat("Look X", lookDirection.x);
                animator.SetFloat("Look Y", lookDirection.y);
                animator.SetFloat("Speed", move.magnitude);
            }




            if (Cat != null)
            {
                animator1.SetFloat("Cat Look X", lookDirection.x);
                animator1.SetFloat("Cat Look Y", lookDirection.y);
                animator1.SetFloat("Cat Speed", move.magnitude);
            }
        }



        if (ShopOpen == true)
        {
            animator.SetFloat("Speed", 0f);
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (LightOn == false && LightTime <= 0f)
            {
                LightTurnOn();
                LightTime = .5f;

            }

            else if (LightOn == true && LightTime <= 0f)
            {
                LightTurnOff();
                LightTime = .5f;
                LightTime -= Time.deltaTime;
            }

        }

        if (LightOn == true)
        {
            LightTime -= Time.deltaTime;
        }

        if (LightOn == false)
        {
            LightTime -= Time.deltaTime;
        }



        if (Input.GetKey(KeyCode.E))
        {
            if (EnergyUneaten == true && WasEaten == false && HasEnergyBar == true)
            {
                EnergyUneaten.SetActive(false);
                EnergyEaten.SetActive(true);
                WasEaten = true;
                speed = 5f;
                EnergyTime = 25f;
            }


        }

        if (EnergyEaten == true)
        {
            EnergyTime -= Time.deltaTime;
        }

        if (EnergyTime <= 0f)
        {
            speed = 3f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.1f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            Debug.DrawRay(transform.position, lookDirection, Color.yellow);
            Debug.Log("Raycast was casted");
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }


        if (numLives == 3)
        {
            Health3.SetActive(true);
            Health2.SetActive(false);
            Health1.SetActive(false);
            Health0.SetActive(false);
            lowHealthVillage.SetActive(false);
            lowHealthShop.SetActive(false);
            lowHealthCabin.SetActive(false);
            //lowHealthCave.SetActive(false);


        }

        else if (numLives == 2)
        {
            Health3.SetActive(false);
            Health2.SetActive(true);
            Health1.SetActive(false);
            Health0.SetActive(false);
            lowHealthVillage.SetActive(false);
            lowHealthShop.SetActive(false);
            lowHealthCabin.SetActive(false);
            //lowHealthCave.SetActive(false);

        }

        else if (numLives == 1)
        {
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(true);
            Health0.SetActive(false);
            lowHealthVillage.SetActive(true);
            lowHealthShop.SetActive(true);
            lowHealthCabin.SetActive(true);
            //lowHealthCave.SetActive(true);


        }

        else if (numLives <= 0)
        {
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(false);
            Health0.SetActive(true);
            lowHealthVillage.SetActive(false);
            lowHealthShop.SetActive(false);
            lowHealthCabin.SetActive(false);
            //lowHealthCave.SetActive(false);
        }




    }



    void FixedUpdate()
    {
        if (ShopOpen == false)
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;

            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }

    }

    public void Buylatern()
    {

        if (Money >= 10 && HasLatern == false)
        {
            HasLatern = true;
            LaternUiOff.SetActive(true);
            Money -= 10;
        }
    }

    public void BuyEnergyBar()
    {

        if (Money >= 5 && HasEnergyBar == false)
        {
            HasEnergyBar = true;
            EnergyUneaten.SetActive(true);
            Money -= 5;
        }


    }

    public void BuyIcePick()
    {

        if (Money >= 25 && HasIcePick == false)
        {
            HasIcePick = true;
            Money -= 25;
        }
    }

    public void LightTurnOn()
    {

        if (HasLatern == true)
        {

            LaternUiOn.SetActive(true);
            LaternUiOff.SetActive(false);
            LaternLightSource.SetActive(true);
            LightOn = true;
            LaternLightOn = true;


        }
    }

    public void LightTurnOff()
    {

        if (HasLatern == true)
        {

            if (LightOn == true)
            {

                LaternUiOn.SetActive(false);
                LaternUiOff.SetActive(true);
                LaternLightSource.SetActive(false);
                LightOn = false;
                LaternLightOn = false;

            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }

    public void Endgame()
    {

    }


    public bool LightIsOn
    {
        get { return LightOn; }
    }

    public bool HasLantern
    {
        get { return HasLatern; }
    }

    public int PlayerMoney
    {
        get { return Money; }
    }



}



