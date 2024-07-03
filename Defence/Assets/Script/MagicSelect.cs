using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MagicSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//인터페이스 상속
{
    private Image image;            //표시할 이미지
    private TextMeshProUGUI Cost;   //마나 소모량
    [SerializeField] private int i;  //마법종류

    private void Awake()
    {//변수 초기화
        Cost = GetComponentInChildren<TextMeshProUGUI>();
        Cost.text = GameManager.instans.magicMp[i - 1].ToString(); ;
        image = GetComponent<Image>();
        image.color = Color.white;
    }
    public void OnPointerEnter(PointerEventData eventData)//마우스가 오브젝트 위로 올라오면
    {
        image.color = Color.yellow;//색 변경
        GameManager.instans.i = i;//마법종류 변경
    }

    public void OnPointerExit(PointerEventData eventData)//마우스가 오브젝트 밖으로 나가면
    {
        image.color = Color.white;//색변경
        GameManager.instans.i = 0;//마법종류 초기화
    }
    void OnDisable()//비활성화되면
    {
        image.color = Color.white;//색변경

    }
}
