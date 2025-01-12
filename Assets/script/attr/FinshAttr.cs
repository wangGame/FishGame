using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshAttr : MonoBehaviour
{
    public int hp;
    private bool isDestory;
    //鱼最大的数量  和  速度
    public int maxNum;
    public int maxSpeed;
    private bool died;
    public GameObject dieObject;
    public int exp;
    public int gold;
    public GameObject goldCoinPrafab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestory)return;
        if (collision.tag == "border") { 
            Destroy(gameObject);
            isDestory= true;
        }
    }

    public void TakeDamage(int value) {
        if (died) { 
            return;
        }
        hp -= value;
        if (hp < 0)
        {
            GameController.getInstance().exp += exp;
            GameController.getInstance().gold += gold;

            died = true;
            Transform die = Instantiate(dieObject).transform;
            die.SetParent(gameObject.transform.parent, false);
            die.position = transform.position;
            die.rotation = transform.rotation;




            Transform goldCoin = Instantiate(goldCoinPrafab).transform;
            goldCoin.SetParent(gameObject.transform.parent, false);
            goldCoin.position = transform.position;
            goldCoin.rotation = transform.rotation;


            Destroy(gameObject);


        }
    }
}
