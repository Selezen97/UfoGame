using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject exp;
    private float expTime, expTimer = 1.5f;
    private bool canExp;
    void Update()
    {
        if (canExp)
            expTime += Time.deltaTime;
        if (expTime>expTimer)
        {
            GetComponent<Renderer>().enabled = false;
            exp.SetActive(true);
        }
        if (expTime>expTimer*2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        canExp = true;
    }
}
