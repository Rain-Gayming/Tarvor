using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWorldManager : MonoBehaviour
{
    public static AIWorldManager instance;
    public List<AISpot> movePoints;
    public AISpot[] array;

    private void Awake() {
        instance = this;
        array = GetComponentsInChildren<AISpot>();

        for (int i = 0; i < array.Length; i++)
        {
            movePoints.Add(array[i]);
        }
    }
}
