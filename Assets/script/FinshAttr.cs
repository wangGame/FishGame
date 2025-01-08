using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshAttr : MonoBehaviour
{
    private bool isDestory;
    //鱼最大的数量  和  速度
    public int maxNum;
    public int maxSpeed;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestory)return;
        if (collision.tag == "border") { 
            Destroy(gameObject);
            isDestory= true;
        }
    }
}
