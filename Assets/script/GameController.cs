using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    [SerializeField]
    private TextMeshProUGUI costText;  
    public GameObject[] gunGos;

    public Transform bulletHolder;


    public GameObject[] bullet1Gos;
    public GameObject[] bullet2Gos;
    public GameObject[] bullet3Gos;
    public GameObject[] bullet4Gos;
    public GameObject[] bullet5Gos;

    public int lv = 0;
    public int gold = 500;
    public int exp = 0;
    public const int bigCountdown = 240;
    public const int smallCountdown = 60;
    public float bigTimer = bigCountdown;
    public float smallTimer = smallCountdown;
    public Color goldColor;



    public TextMeshProUGUI gameCoinText;
    public TextMeshProUGUI lvText;
    public TextMeshProUGUI lvNameText;
    public TextMeshProUGUI smallCountDownText;
    public TextMeshProUGUI bigCountDownText;

    public Button bigCountDownButton;
    public Button backButton;
    public Button settingButton;
    public Slider expSlider;
    public Color coinBaseColor;

    private int costIndex =0;
    private int[] oneShootCosts = {
        5,10,20,30,40,50,60,70,80,90,100,200,300,400,500,600,700,800,900,1000
    };

    private string[] lvName = { 
        "新手","入门","钢铁","青铜","白银","黄金",
        "白金","钻石","大师","宗师"
    };

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinBaseColor = gameCoinText.color;
    }

    public static GameController getInstance() {
        return instance;
    }

    public void OnButtonPDown() {
        gunGos[costIndex/4].SetActive(false);
        costIndex++;
        costIndex %= oneShootCosts.Length;
        gunGos[costIndex / 4].SetActive(true);
        costText.SetText(oneShootCosts[costIndex]+"");
    }

    public void updateUI() {
        bigTimer -= Time.deltaTime;
        smallTimer -= Time.deltaTime;
        if (smallTimer < 0) {
            smallTimer = smallCountdown;
            gold += 50;
        }
        if (bigTimer <= 0 && bigCountDownButton.gameObject.activeSelf == false) { 
            bigCountDownText.gameObject.SetActive(false);
            bigCountDownButton.gameObject.SetActive(true);
        }



        //经验等级换算公式：升级所需要的经验 = 1000+200*当前等级
        while (exp >= 1000 + 200 * lv) {
            lv++;
            exp = exp - (1000 + 200 * lv);
        }
        gameCoinText.text = "$" + gold;
        lvText.text = lv.ToString();
        if ((lv / 9) <= 9)
        {
            lvNameText.text = lvName[lv / 9];
        }
        else { 
            lvNameText.text= lvName[9];
        }
        smallCountDownText.text = " " + (int)smallTimer / 10
            + " " + (int)smallTimer % 10;
        bigCountDownText.text = (int)(bigTimer) + "s";
        expSlider.value = (((float)exp)/(1000+200*lv));
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
        Fire();
        updateUI();
    }

    void ChangeBulletCost() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            //下
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
            if (gold - oneShootCosts[costIndex] >= 0) {
                gold -= oneShootCosts[costIndex];  
                //左键
                switch (costIndex / 4)
                {
                    case 0: useBullets = bullet1Gos; break;
                    case 1: useBullets = bullet2Gos; break;
                    case 2: useBullets = bullet3Gos; break;
                    case 3: useBullets = bullet4Gos; break;
                    case 4: useBullets = bullet5Gos; break;
                }
                bulletIndex = (lv % 10 >= 9) ? 9 : lv % 10;
                GameObject bullet = Instantiate(useBullets[bulletIndex]);
                bullet.transform.SetParent(bulletHolder, false);
                bullet.transform.position =
                    gunGos[costIndex / 4].transform.Find("firpos").transform.position;
                bullet.transform.rotation =
                    gunGos[costIndex / 4].transform.Find("firpos").transform.rotation;
                Ef_AutoMove ef = bullet.AddComponent<Ef_AutoMove>();
                BulletAttr bulletAttr = bullet.GetComponent<BulletAttr>();
                ef.speed = bulletAttr.speed;
                ef.dir = Vector3.up;

            }
            else
            {
                StartCoroutine(GoldNotEnough());
            }

        }
    }

    public void OnBigCountdownDown() {
        gold += 500;
        bigCountDownButton.gameObject.SetActive(false);
        bigCountDownText.gameObject.SetActive(true);
        bigTimer = bigCountdown;
    }

    IEnumerator GoldNotEnough() {
        gameCoinText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        gameCoinText.color = coinBaseColor;
    }
}  
