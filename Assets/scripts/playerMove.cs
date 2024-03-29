using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMove : MonoBehaviour
{
    public bool ShopOpen;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;
    Vector2 lookDirection = new Vector2(1, 0);
    public GameObject Cat;

    Animator animator;
    Animator animator1;

    public int Money;
    public bool HasLatern;
    public bool HasEnergyBar;
    public bool HasIcePick;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //timer = changeTime;
        animator = GetComponent<Animator>();
        animator1 = Cat.GetComponent<Animator>();
        ShopOpen = false;
        HasLatern = false;
        HasEnergyBar = false;
        HasIcePick = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (ShopOpen ==  false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontal, vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);


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
        

        //  if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f);
        //    Debug.Log("Raycast was casted");
        //    Debug.DrawRay(transform.position, new Vector2 (transform.position.x, transform.position.y), Color.green, 10f);
        //   if (hit.collider != null && tag == "NPC")
        //    {
        //        Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
        //    }
        // }

      

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

        if (Input.GetKey(KeyCode.L))
        {
            if (HasLatern == true)
            {

            }
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
            Money -= 10;
        }
    }

    public void BuyEnergyBar()
    {
        if (Money >= 5 && HasEnergyBar == false)
        {
            HasEnergyBar = true;
            Money -= 5;
        }

        //else if (HasEnergyBar == true)
       // {

       // }
    }

    public void BuyIcePick()
    {
        if (Money >= 25 && HasIcePick == false)
        {
            HasIcePick = true;
            Money -= 25;
        }
    }
}


