using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenItem : MonoBehaviour
{
    public GameObject ItemBox;                                                  //������ �ڽ� ����
    public float checkTime;                                                     //�ð� �˻��� ���� ����
   
    void Update()
    {
        checkTime += Time.deltaTime;                                            //������ �ð��� �׾Ƽ� �ʸ� �˻��Ѵ�.
        if(checkTime >= 2.0f)                                                   //2���� �ð��� �帣��
        {
            checkTime = 0.0f;                                                   //�ð� �ʱ�ȭ�� ��Ų��.
            GameObject temp = Instantiate(ItemBox);                             //������ �ڽ� �������� Instantiate �� �����Ѵ�.
            temp.transform.position = this.gameObject.transform.position;       //�����Ҷ� ��ũ��Ʈ�� �ִ� ������Ʈ ��ġ�� ����
            int RandomNumber = Random.Range(0, 4);                              //0��3������ �������� �޾Ƽ�
            temp.transform.position += new Vector3(0.0f, RandomNumber, 0.0f);   //Y�� ��ġ�� �����ش�.

        }
    }
}
