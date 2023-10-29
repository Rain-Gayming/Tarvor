using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemInfo : ScriptableObject
{
    [BoxGroup("Item Info")]
    public Sprite itemIcon;
    [BoxGroup("Item Info")]
    public ItemType itemType;
    
    [BoxGroup("Item Info")]
    public string itemName;
    [BoxGroup("Item Info")]
    public float weight;
    [BoxGroup("Item Info")]
    public float value;
    [BoxGroup("Item Info")]
    public GameObject groundObject;
}
