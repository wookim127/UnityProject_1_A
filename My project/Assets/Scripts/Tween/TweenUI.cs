using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;      //�ð��� ����
    private Image image;             //UI Image �� ����

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();   
        image.DOFade(0f, duration);
        image.DOPlay();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
