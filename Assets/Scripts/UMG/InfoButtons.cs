using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtons : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject boyRef;
    public GameObject girlRef;

    //Виджет прикрепляеться к объекту
    public void SetPosBoy()
    { 
        Vector2 pos = boyRef.transform.position;
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);
        rectTransform.anchorMin = viewportPoint;
        rectTransform.anchorMax = viewportPoint;
    }

    //Виджет прикрепляеться к объекту
    public void SetPosGirl()
    {
        Vector2 pos = girlRef.transform.position;
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);
        rectTransform.anchorMin = viewportPoint;
        rectTransform.anchorMax = viewportPoint;
    }
}
