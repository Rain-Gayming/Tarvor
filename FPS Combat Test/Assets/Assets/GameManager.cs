using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

public class GameManager : MonoBehaviour
{
    public QuantumKeyConfig keyConfig;
    public bool paused;
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
            print("Should Change Pause");
        }

        if(Input.GetKeyDown(keyConfig.ToggleConsoleVisibilityKey.Key)){
            ChangePause();
        }

        if(paused){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void ChangePause()
    {
        paused = !paused;
    }
    public void ChangePause(bool value)
    {
        paused = value;
    }
}
