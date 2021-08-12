using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UfoControl : MonoBehaviour
{

    public int speed = 5, jumpForce;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Sprite deadSprite,idleSprite;
    private bool isRight, isGround, isDeath;
    public byte count;
    public Text scoreLabel;
    void Start()
    {
        isRight = true;
    }

    void FixedUpdate()
    {
        if (!isDeath)
        {
            transform.Translate(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,0);
            if ((Input.GetAxis("Horizontal")>0 && !isRight) || (Input.GetAxis("Horizontal")<0 && isRight))
                Flip();
            if (isGround && Input.GetKey(KeyCode.W))
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
            isGround = Physics2D.OverlapArea(new Vector2(groundCheck.position.x - 0.4f, groundCheck.position.y - 0.2f),
                new Vector2(groundCheck.position.x + 0.4f, groundCheck.position.y + 0.2f),groundLayer);
        }
        else
        {
            gameObject.transform.Find("Ufo").GetComponent<SpriteRenderer>().sprite = deadSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("coin"))
        {
            Destroy(coll.gameObject);
            count++;
            scoreLabel.text = count.ToString();
            if (count == 5)
                SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bomb")
        {
            isDeath=true;
            Invoke("Respawn",2);
            //Respawn();
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void Respawn()
    {
        
        isDeath = false;
        gameObject.transform.Find("Ufo").GetComponent<SpriteRenderer>().sprite = idleSprite;
        transform.position = new Vector2(-9f,-0.7f);
    }
}
