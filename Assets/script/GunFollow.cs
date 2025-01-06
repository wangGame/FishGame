using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public RectTransform UGUICanvas;
    public Camera mainCamera;
    void Update()
    {
        //得到当前canvas的坐标
        Vector3 mousePos;
        //转换到世界坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            UGUICanvas,
            new Vector2(Input.mousePosition.x,Input.mousePosition.y),
            mainCamera,
            out mousePos
            );
        float z;
        if (mousePos.x > transform.position.x)
        {
            z = -Vector3.Angle(Vector3.up, mousePos - transform.position);
        }
        else {
            z = Vector3.Angle(Vector3.up, mousePos - transform.position);
        }
        transform.localRotation = Quaternion.Euler(0,0,z);
    }
}
