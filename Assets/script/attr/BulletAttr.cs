using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttr : MonoBehaviour
{
    public int speed;
    public int damage;
    public GameObject webPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "border") {
            Destroy(gameObject);
        }

        if (collision.tag == "fish") {
            GameObject web = Instantiate(webPrefab);
            web.transform.SetParent(transform.parent, false);
            web.transform.position = transform.position;
            WebAttr webAttr = web.GetComponent<WebAttr>();
            webAttr.damage = damage;
            Destroy(gameObject);
        }
    }
}
