using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ef_TurnMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,speed*Time.deltaTime);
    }
}
