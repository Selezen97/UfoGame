using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;
    public int createTimer = 3;
    private float createTime;
    private Vector2 randPos;
    void Update()
    {
        createTime += Time.deltaTime;
        if (createTime>createTimer)
        {
            randPos = new Vector2(Random.Range(-8,8),Random.Range(1,8));
            Instantiate(coin, randPos, transform.rotation);
            createTime = 0;
        }
    }
}
