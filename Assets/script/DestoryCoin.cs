using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCoin : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("" + collision.tag);
        if (collision.tag == "gold")
        {
            Destroy(collision.gameObject);
        }

    }
    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(""+collision.tag);
            if (collision.tag == "gold")
            {
                Destroy(collision.gameObject);
            }
        }*/
}
