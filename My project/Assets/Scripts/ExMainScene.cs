using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExMainScene : MonoBehaviour
{

    public void GoToShootGame()
    {
        SceneManager.LoadScene("GameScene_Gun");
    }

    // Start is called before the first frame update
    public void GoToJumeGame()
    {
        SceneManager.LoadScene("GameScene.Jump");
    }

    // Update is called once per frame
    public void GoExit()
    {
        Application.Quit();
    }
}
