using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_DestorySelf : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,1f);
    }
}
