using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                  //DoTween�� ����ϱ� ���� �߰�

public class TweenTest : MonoBehaviour
{
    Sequence sequence;
    Tween tween;
    void Start()
    {
        //Tween ����
        //transform.DOMoveX(5, 2);                  //�� �������� 2�ʵ��� X�� 5�� �̵� ��Ų��.   
        //transform.DORotate(new Vector3(0, 0, 180), 2);      //�� ������Ʈ�� 2�ʵ��� Z������ 180�� ȸ�� ��Ų��. 
        //transform.DOScale(new Vector3(2, 2, 2), 2);         //�� ������Ʈ�� 2�ʵ��� Scale�� 2�� �ǵ��� Ű���.

        //��ü �ּ� �� �ּ� ���� Ctrl + K + C , Ctrl + K + U
        //Sequence sequence = DOTween.Sequence();             //Tween�� �̾ ������� ���� �����ִ� ���� 
        //sequence.Append(transform.DOMoveX(5, 1));
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 1));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 1));

        //transform.DOMoveX(5, 2).SetEase(Ease,OutBounce);   //Ease �ɼ��� ����Ͽ� �ٿ ȿ��
        //transform.DOShakeRotation(2f, new Vector3(0, 0, 90), 10, 90); //ȸ���� Z�� 90�� ���� 10, ���� 90���� ���� �ش�.

        //transform.DOmoveX(5, 2f).SetEase(Ease.OutBounce).OnComplete(TweenEnd);   //Ʈ���� �Ϸ�Ǹ� Tween End �Լ��� ȣ�� �Ѵ�

        sequence = DOTween.Sequence();      //Tween�� �̾ ������� ���� �����ִ� ����
        sequence.Append(transform.DOMoveX(5, 1));    //Tween ����
        sequence.SetLoops(-1, LoopType.Yoyo);        //Tween ������·� �ݺ� ��Ų��.


    }

    void TweenEnd()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sequence.Kill();
            //twenn.Kill();
        }
    }
}