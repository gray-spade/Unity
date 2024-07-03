using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Slider mpBar;
    public TextMeshProUGUI mpText;

    public Button UpButton;
    public Button mpGenUpBtn;

    public GameObject UPPanel;
    public GameObject OpPanel;
    public TextMeshProUGUI coin;

    public TextMeshProUGUI mpUpText;
    public TextMeshProUGUI mpGenUpText;
    public TextMeshProUGUI magicUpText;
    Tower tower;


    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        deathPanel = GameObject.Find("Canvas").transform.Find("Death").gameObject; ;
        tower = GameObject.Find("BaseTower").GetComponent<Tower>();
        UpButton.onClick.AddListener(UpgradePanelOpen);
    }


    public void UpdateInfo() {
        coin.text = GameManager.instans.coin.ToString();
    }


    //업그레이드
    public void UpgradeMP() {

        if (GameManager.instans.priceMp <= GameManager.instans.coin)
        {
            GameManager.instans.coin -= GameManager.instans.priceMp;
            GameManager.instans.priceMp = (int)(GameManager.instans.priceMp * GameManager.instans.priceScaleMp);
            GameManager.instans.MPLevel++;
            tower.Upgrade();
            mpUpText.text = "Mp Max Upgrade\n\n" + "Mp Max " + tower.maxMp +
                "->" + (tower.maxMp + 1) + "\n\ncoin " + GameManager.instans.priceMp;

            UpdateInfo();
        }
    }
    public void UpgradeMPGen()
    {
        if (GameManager.instans.priceMpGen <= GameManager.instans.coin) {
            GameManager.instans.coin -= GameManager.instans.priceMpGen;
            GameManager.instans.priceMpGen = (int)(GameManager.instans.priceMpGen + GameManager.instans.priceScaleMpGen);
            GameManager.instans.MPRegenLevel++;
            tower.Upgrade();
            mpGenUpText.text = "MpGain Upgrade\n\n" + "MpGain " + (GameManager.instans.MPRegenLevel + 1) +
                    "->" + (GameManager.instans.MPRegenLevel + 2) + "\n\ncoin " + GameManager.instans.priceMpGen;

            if (GameManager.instans.MPRegenLevel == 2)
            {
                mpGenUpText.text = "MpGain Upgrade\n\n" + "MpGain " + (GameManager.instans.MPRegenLevel + 1) +
                    "->" + "MAX" + "\n\ncoin " + GameManager.instans.priceMpGen;
            }
            else if (GameManager.instans.MPRegenLevel == 3)
            {
                mpGenUpText.text = "MpGain Upgrade\n\n" + "MpGain " + "->" + "MAX";
                mpGenUpBtn.interactable = false;
            }

            UpdateInfo();

        }
    }
    public void UpgradeMagic()
    {

        if (GameManager.instans.priceMagicPower <= GameManager.instans.coin)
        {
            GameManager.instans.coin -= GameManager.instans.priceMagicPower;
            GameManager.instans.priceMagicPower = (int)(GameManager.instans.priceMagicPower * GameManager.instans.priceScaleMagicPower);
            GameManager.instans.MagicLevel++;
            tower.Upgrade();
            magicUpText.text = "Magic Power  Upgrade\n\n" + "Level  " + (GameManager.instans.MagicLevel + 1) +
                "->" + (GameManager.instans.MagicLevel + 2) + "\n\ncoin " + GameManager.instans.priceMagicPower;

            UpdateInfo();
        }
    }

    //UI 활성화, 비활성화
    public void UpgradePanelOpen()
    {
        UPPanel.SetActive(true);
    }
    public void UpPanelExit() {
        UPPanel.SetActive(false);
    }
    public void OpPanelOpen()
    {
        OpPanel.SetActive(true);
    }
    public void OpPanelExit()
    {
        OpPanel.SetActive(false);
    }
    //설정의 화면전환기능
    public void GoTitle() {
        SceneManager.LoadScene("TitleScene");
    }
    public void ExitGame(){
        Application.Quit();
    }
}


