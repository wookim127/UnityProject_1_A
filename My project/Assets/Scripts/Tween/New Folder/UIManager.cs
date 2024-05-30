using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestscoreText;
    // Start is called before the first frame update

    void OnEnable()
    {
        GameManager.OnPointChanged += UpdatePointText;
        
    }

    // Update is called once per frame
    void OnDisable()
    {
        GameManager.OnPointChanged -= UpdatePointText;
        
    }


    void UpdatePointText(int newPoint)
    {
        pointText.text = "Points : " + newPoint;
    }


    void UpdateBestScoreText(int newBestScore)
    {
        bestscoreText.text = "BestScore : " + newBestScore;
    }

}


