using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_WaterWave : MonoBehaviour
{
    public Texture[] textures;
    private Material material;
    private int index;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        InvokeRepeating("ChangeTexture",0,0.1f);
    }

    void ChangeTexture() { 
        material.mainTexture = textures[index];
        index = (index + 1) % textures.Length;
    }
}
