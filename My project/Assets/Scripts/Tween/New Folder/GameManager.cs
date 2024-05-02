using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject circleObject;      //��ü �������� �����´�.
    public Transform genTransform;       //���� ��ġ ����
    public float timeCheck;              //���� �ð� ���� ����(float)
    public bool isGen;                   //���� üũ (bool)
    // Start is called before the first frame update
    public void GenObject()              //���� ���� ������ ���� �����ִ� �Լ�
    {
        isGen = false;                   //���� �Ϸ� �Ǿ����� bool �� false ����
        timeCheck = 1.0f;                //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
    }

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }
    //Update is called once per frame
    void Update()
    {
        if (isGen == false)                       //isGen �÷��װ� false �� ���
        {
            timeCheck -= Time.deltaTime;         //�� ������ ���ư��鼭 �ð��� ���� ��Ų��.
            if (timeCheck < 0.0f)                 //0�� ���ϰ� �Ǿ��� ���
            {
                GameObject Temp = Instantiate(circleObject);   //������ ������ Temp ������Ʈ�� �ִ´�.
                Temp.transform.position = genTransform.position; //���� ��ġ�� ���� ��Ų��.
                isGen = true;
            }
        }
    }
}
