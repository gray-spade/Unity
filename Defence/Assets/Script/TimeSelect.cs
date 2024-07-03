using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSelect : MonoBehaviour
{
    //�ð� ����� ����ϴ� ��ũ��Ʈ

    //���� ����
    Button fastBtn;
    GameObject on;
    bool isFast;
    // Start is called before the first frame update
    void Start()
    {//���� �ʱ�ȭ
        fastBtn = GameObject.Find("Time").GetComponent<Button>();
        on = fastBtn.transform.Find("On").gameObject;
        fastBtn.onClick.AddListener(FastToggle);

    }
    void FastToggle() {
        if (isFast)//��� �����̸�
        {//�ð��� �������� ���̰�
            on.SetActive(false);//��ư �̹��� ����
            Time.timeScale = 0.5f;

        }
        else {//��ӻ��°� �ƴϸ�
            //�̹����� �ٲٰ�
            on.SetActive(true);
            //��ӻ��·� ����
            Time.timeScale = 1f;

        }
        isFast = !isFast;//��ӻ���->�⺻����,�⺻����->��ӻ���

    }
}
