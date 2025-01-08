using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI costText;  
    public GameObject[] gunGos;

    public Transform bulletHolder;

    public int lv;

    public GameObject[] bullet1Gos;
    public GameObject[] bullet2Gos;
    public GameObject[] bullet3Gos;
    public GameObject[] bullet4Gos;
    public GameObject[] bullet5Gos;

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
        Fire();
        ChangeBulletCost();
    }

    void ChangeBulletCost() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            //ÏÂ
            OnButtonMDown();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //shang
            OnButtonPDown();
        }
    }

    void Fire() {
        GameObject[] useBullets = bullet4Gos;
        int bulletIndex;
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false) {
            //×ó¼ü
            switch (costIndex / 4) { 
                case 0:useBullets = bullet1Gos; break;
                case 1:useBullets = bullet2Gos; break;
                case 2:useBullets = bullet3Gos; break;
                case 3:useBullets = bullet4Gos; break;
                case 4: useBullets = bullet5Gos; break;
            }
            bulletIndex = (lv % 10 >= 9) ? 9 : lv%10;
            GameObject bullet = Instantiate(useBullets[bulletIndex]);
            bullet.transform.SetParent(bulletHolder, false);
            bullet.transform.position =
                gunGos[costIndex / 4].transform.Find("firpos").transform.position;
            bullet.transform.rotation =
                gunGos[costIndex / 4].transform.Find("firpos").transform.rotation;
            Ef_AutoMove ef = bullet.AddComponent<Ef_AutoMove>();
            ef.speed = 10f;
            ef.dir = Vector3.up;
        }
    }
}  
