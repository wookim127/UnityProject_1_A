using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] circleObject;      //��ü �������� �����´�. (�迭�� ����)
    public Transform genTransform;       //���� ��ġ ����
    public float timeCheck;              //���� �ð� ���� ����(float)
    public bool isGen;

    public int Point;
    public static event Action<int> OnPointChanged;//���� üũ (bool)
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
                int RandNumber = UnityEngine.Random.Range(0, 3);
                GameObject Temp = Instantiate(circleObject[RandNumber]); 
                Temp.transform.position = genTransform.position; //���� ��ġ�� ���� ��Ų��.
                isGen = true;
            }
        }
    }


    public void MergeObject(int index, Vector3 position)     //�浹�� ��ü�� index ��ȣ�� ��ġ�� �����´�.
    {
        GameObject Temp = Instantiate(circleObject[index]);   //������ ���� ������Ʈ�� Temp �� �ִ´�.
        Temp.transform.position = position;                   //Temp ������Ʈ�� ��ġ�� �Լ��� �޾ƿ� ��ġ��
        Temp.GetComponent<CircleObject>().Used();

        Point += (int)Mathf.Pow(index, 2) * 10;
        OnPointChanged?.Invoke(Point);//�����Ǿ����� ���Ǿ��ٰ� ǥ�� �������
    }


    public void EndGame()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");

        if (Point > BestScore)
        {
            PlayerPrefs.SetInt("BestScore", Point);
        }      }
    }
