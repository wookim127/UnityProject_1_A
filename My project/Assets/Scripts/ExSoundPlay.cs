using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.instance.PlaySound("BackGround");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.instance.PlaySound("Cannon");
        }
    }
}
     
