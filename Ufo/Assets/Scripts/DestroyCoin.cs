using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    private float destrTime, destrTimer = 5;
    void Update()
    {
        destrTime += Time.deltaTime;
        if (destrTime>destrTimer)
            Destroy(gameObject);
    }
}
