using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject bomb;
    public byte createTimer = 5;
    private float createTime;
    private Vector2 randomPos;
    void Update()
    {
        createTime += Time.deltaTime;
        if (createTime>createTimer)
        {
            randomPos = new Vector2(Random.Range(-8,8),10);
            GameObject tempBomb = Instantiate(bomb,randomPos,transform.rotation) as GameObject;
            tempBomb.GetComponent<Rigidbody2D>().mass = Random.Range(1,5);
            createTime = 0;
        }
    }
}
