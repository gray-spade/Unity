using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{
    public float time = 0;                              //Ÿ�̸� ����� ����
    public float Maxtime = 0.5f;                        //�ִ� �ð�
    public Canvas canvas;                               //ǥ���� Ui ĵ����
    public RectTransform rect;                          //ĵ������ rect
    Vector3 pos;                                        //Ŭ������ �� ���콺�� ��ġ
    Vector2 localPoint;                                 //���콺 ��ġ�� UI��ġ�� ��ȯ������ ��ǥ
    [SerializeField] private GameObject panel;          //���������� ǥ�õ� �г�
    [SerializeField] private Image load;                //���콺 ������ �ð��� �˷��� �̹���
    [SerializeField] GameObject[] magicsPrefab;         //�������� ������
        
    Tower tower;                                        //Ÿ��

    // Start is called before the first frame update
    void Start()
    {//���� �ʱ�ȭ
        tower = GameObject.Find("BaseTower").GetComponent<Tower>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rect = canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)//UI�� Ŭ���Ȱ��� �ƴϸ�
        {
           
            if (Input.GetMouseButtonDown(0))//���콺 ��Ŭ���� ������
            {
                pos = Input.mousePosition;//��ǥ������
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pos, null, out localPoint);//UI��ǥ�� ��ȯ

                load.gameObject.GetComponent<RectTransform>().localPosition = localPoint;//��ġ ����

                time = 0;

            }
            if (Input.GetMouseButton(0))//��Ŭ���� ������ �ִ� ����
            {
                time += Time.deltaTime;//Ÿ�̸Ӹ� ������
                if (time > 0.1f)        //0.1�� �̻� ������
                {
                    load.gameObject.SetActive(true);//�̹����� Ȱ��ȭ
                    load.fillAmount = time / Maxtime;//fillAmount�� ���� ä������
                }

                if ((time / Maxtime) > 1)//������ �ð��� �Ǹ�
                {
                    panel.GetComponent<RectTransform>().localPosition = localPoint;//���� ���� UI�� ���� ����
                    panel.SetActive(true);
                    load.gameObject.SetActive(false);//�ε� �̹����� ��Ȱ��ȭ
                }

            }
            
        }
        if (Input.GetMouseButtonUp(0))//���콺 ��Ŭ���� ����
        {
            panel.SetActive(false);             //UI���� ��Ȱ��ȭ�ϰ�
            load.gameObject.SetActive(false);
            Magic(GameManager.instans.i);       //���õ� ��������
            GameManager.instans.i = 0;          //�����ʱ�ȭ
            
           
        }
    }

    void Magic(int i) {//���� ���� 0�̸� �ƹ��͵�����
        switch (i) {
            case 0:
                break;
            case 1:
                SelectMagic(1);
                break;
            case 2:
                SelectMagic(2);
                break;
            case 3:
                SelectMagic(3);
                break;

        }
        
    }

    void SelectMagic(int index) {//���������� �����ϰ� mp�Ҹ�
        if (tower.IsMagic(GameManager.instans.magicMp[index-1]))//������ �����ִ� ��Ȳ�̸�
        {
            GameObject go;
            go = Instantiate(magicsPrefab[index-1]);
            go.GetComponent<Magic>().attackScale = GameManager.instans.MagicLevel;
            go.transform.position = RayCast(pos);//ó�� Ŭ���ߴ� ��ġ�� ����
            tower.Mp -= GameManager.instans.magicMp[index-1];
            
        }
        else { Debug.Log("���� ����"); };
        
    }

    Vector3 RayCast(Vector3 pos1)//����ĳ��Ʈ�� ��ġ ��ȯ
    {
        Vector3 screenPos;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pos1);

        if (Physics.Raycast(ray, out hit))
        {
            screenPos = hit.point;
            return screenPos;
        }

        return Vector3.zero;

    } 
}
