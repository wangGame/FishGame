using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshMarker : MonoBehaviour
{
    //����λ��
    public Transform[] genPositions;
    public GameObject[] finishPrefabs;
    public Transform fishHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MakeFishes() { 
        //�������λ��        
        int genPosIndex = Random.Range(0, genPositions.Length);
        int fishPreIndex = Random.Range(0,finishPrefabs.Length);
        //����ٶ�
        FinshAttr finshAttr = finishPrefabs[fishPreIndex].GetComponent<FinshAttr>();
        int maxNum = finshAttr.maxNum;
        int maxSpeed = finshAttr.maxSpeed;
        int num = Random.Range((maxNum/2) + 1, maxNum);
        int speed = Random.Range(maxSpeed/2,maxSpeed);
        int moveType = Random.Range(0,2); //�ƶ�ģʽ  1 ֱ��  0 ����
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
