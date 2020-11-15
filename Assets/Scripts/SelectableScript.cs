using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableScript : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData) {
        MainMenuHandler.selected = this.gameObject.name;
    }

    public void OnDeselect(BaseEventData eventData) {
        //
    }
}
