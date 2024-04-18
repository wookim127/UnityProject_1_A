using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;      //시간값 선언
    private Image image;             //UI Image 에 접근

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
