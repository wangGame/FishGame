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
        InvokeRepeating("MakeFishes",0,0.3f);
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
            angOffset = Random.Range(-22,22);
            StartCoroutine( GenStraightFinsh(genPosIndex, fishPreIndex, num, speed, angOffset));
        }
        else if (moveType == 1) {
            if (Random.Range(0, 2) == 0) { 
                angSpeed = Random.Range(-15, -9);
            }
            else
            {
                angSpeed = Random.Range(+15, +9);

            }
            StartCoroutine(GenTurnFinsh(genPosIndex,fishPreIndex,num,speed,angSpeed));
        }
    }



    IEnumerator GenTurnFinsh(int genPosIndex, int fishPreIndex, int num, int speed, int angSpeed)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(finishPrefabs[fishPreIndex]);
            //值已经算好了，可以不在计算
            fish.transform.SetParent(fishHolder, false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.AddComponent<Ef_TurnMove>().speed = angSpeed;
            yield return new WaitForSeconds(0.8f);
        }
    }

    IEnumerator GenStraightFinsh(int genPosIndex,int fishPreIndex,int num,int speed,int angOffset) {
        for (int i = 0; i < num; i++) {
            GameObject fish = Instantiate(finishPrefabs[fishPreIndex]);
            //值已经算好了，可以不在计算
            fish.transform.SetParent(fishHolder,false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.transform.Rotate(0, 0, angOffset);
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            yield return new WaitForSeconds(0.8f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
