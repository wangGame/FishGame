using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshMarker : MonoBehaviour
{
    //生成位置
    public Transform[] genPositions;
    public GameObject[] finishPrefabs;
    public Transform fishHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MakeFishes() { 
        //生成鱼的位置        
        int genPosIndex = Random.Range(0, genPositions.Length);
        int fishPreIndex = Random.Range(0,finishPrefabs.Length);
        //鱼的速度
        FinshAttr finshAttr = finishPrefabs[fishPreIndex].GetComponent<FinshAttr>();
        int maxNum = finshAttr.maxNum;
        int maxSpeed = finshAttr.maxSpeed;
        int num = Random.Range((maxNum/2) + 1, maxNum);
        int speed = Random.Range(maxSpeed/2,maxSpeed);
        int moveType = Random.Range(0,2); //移动模式  1 直走  0 拐弯
        int angOffset;
        int angSpeed;

        if (moveType == 0)
        {

        }
        else if (moveType == 1) { 
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
