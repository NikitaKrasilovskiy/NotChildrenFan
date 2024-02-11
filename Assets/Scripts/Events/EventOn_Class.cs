using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOn_Class : MonoBehaviour
{
    //Индекс ивента
    protected int eventIndex;
    public int EventIndex { get { return eventIndex; } set { eventIndex = value; } }

    //Спрайт Ивента в облако персонажа
    protected Sprite eventSprite;
    public Sprite EventSprite { get { return eventSprite; } set { eventSprite = value; } }
}
