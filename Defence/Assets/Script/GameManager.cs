using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _gm;                     //�̱���
    public int i;                                       //������� ������� �˷��� ����

    [SerializeField] public float MPLevel=0;            //MP�ִ�ġ���׷��̵� ����
    [SerializeField] public float MPRegenLevel = 0;     //MPȸ�����׷��̵� ����
    [SerializeField] public float MagicLevel = 0;       //���� ��������׷��̵� ����
    public int[] magicMp= { 7, 10, 5 };                 //������ ���� �Ҹ�

    public int coin;                                    //���� ��
    public UIManager Um;                                //UIManger

    public int priceMp = 200;                           //MP�ִ�ġ���׷��̵� ����
    public int priceMpGen = 500;                        //MPȸ�����׷��̵� ����
    public int priceMagicPower=100;                     //���� ��������׷��̵� ����

    public float priceScaleMp = 1.2f;                   //MP�ִ�ġ���׷��̵� ���� ������ *
    public float priceScaleMpGen = 500;                 //MPȸ�����׷��̵� ���� ������ +
    public float priceScaleMagicPower = 1.1f;           //���� ��������׷��̵� ���� ������ * 
    public static GameManager instans {                 //�̱���
        get => _gm;
    }

    private void Awake()//�̱���
    {
        if (_gm == null) {
            _gm = this;
        }
        Um = GetComponent<UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {//���� �ʱ�ȭ
        
    }
}
