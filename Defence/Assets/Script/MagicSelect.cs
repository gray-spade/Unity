using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MagicSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//�������̽� ���
{
    private Image image;            //ǥ���� �̹���
    private TextMeshProUGUI Cost;   //���� �Ҹ�
    [SerializeField] private int i;  //��������

    private void Awake()
    {//���� �ʱ�ȭ
        Cost = GetComponentInChildren<TextMeshProUGUI>();
        Cost.text = GameManager.instans.magicMp[i - 1].ToString(); ;
        image = GetComponent<Image>();
        image.color = Color.white;
    }
    public void OnPointerEnter(PointerEventData eventData)//���콺�� ������Ʈ ���� �ö����
    {
        image.color = Color.yellow;//�� ����
        GameManager.instans.i = i;//�������� ����
    }

    public void OnPointerExit(PointerEventData eventData)//���콺�� ������Ʈ ������ ������
    {
        image.color = Color.white;//������
        GameManager.instans.i = 0;//�������� �ʱ�ȭ
    }
    void OnDisable()//��Ȱ��ȭ�Ǹ�
    {
        image.color = Color.white;//������

    }
}
