using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_MoveGoldCollect : MonoBehaviour
{
    private GameObject targetObject;
    private void Start()
    {
        targetObject = GameObject.Find("GoldIcon");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,targetObject.transform.position,50*Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);
    }

}
