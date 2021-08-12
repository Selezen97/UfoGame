using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    void DestroyParentBomb()
    {
        Destroy(transform.parent.gameObject);
    }
}
