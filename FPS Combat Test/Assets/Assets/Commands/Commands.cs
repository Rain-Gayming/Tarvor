using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

public class Commands : MonoBehaviour
{
    [Command]
    public void ToggleFPSView()
    {
        UIManager.instance.ToggleFPSView();
    }    
    
    [Command]
    public int MaxFPS(int fps)
    {
        return Application.targetFrameRate = fps; 
    }
}
