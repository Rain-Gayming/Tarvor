using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class UIManager : MonoBehaviour
{   
    public static UIManager instance;
    
    [BoxGroup("References")]
    public GameObject fpsCounter;
    
    [BoxGroup("Hit Marker")]
    public GameObject hitMarker;
    [BoxGroup("Hit Marker")]
    public float hitMarkerTime;

    private void Awake() {
        if(instance != null){
            Destroy(instance.gameObject);
            instance = this;
        }else{
            instance = this;
        }
    }

    public void ToggleFPSView()
    {
        fpsCounter.SetActive(!fpsCounter.activeInHierarchy);
    }

    public void HitMarker()
    {
        StartCoroutine(HitMarkerCo());
    }
    public IEnumerator HitMarkerCo()
    {
        hitMarker.SetActive(true);
        yield return new WaitForSeconds(hitMarkerTime);
        hitMarker.SetActive(false);
    }
}
