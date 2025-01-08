using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI costText;  
    public GameObject[] gunGos;
    private int costIndex =0;
    private int[] oneShootCosts = {
        5,10,20,30,40,50,60,70,80,90,100,200,300,400,500,600,700,800,900,1000
    };

    public void OnButtonPDown() {
        gunGos[costIndex/4].SetActive(false);
        costIndex++;
        costIndex %= oneShootCosts.Length;
        gunGos[costIndex / 4].SetActive(true);
        costText.SetText(oneShootCosts[costIndex]+"");
    }

    public void OnButtonMDown() {
        gunGos[costIndex / 4].SetActive(false);
        costIndex--;
        if (costIndex < 0)
        {
            costIndex += oneShootCosts.Length;
        }
        costIndex %= oneShootCosts.Length;
        gunGos[costIndex / 4].SetActive(true);
        costText.SetText(oneShootCosts[costIndex] + "");
    }

    private void Update()
    {
        ChangeBulletCost();
    }

    void ChangeBulletCost() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            //об
            OnButtonMDown();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //shang
            OnButtonPDown();
        }


    }
}  
