using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class SelectableScript : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData) {
        Regex purple = new Regex("PR");
        Regex yellow = new Regex("YE");
        Regex blue = new Regex("BL");
        Regex brown = new Regex("BR");
        GameObject handler = GameObject.Find("MainMenuHandler");
        if (this.gameObject.name.Equals("Purple")&&!purple.IsMatch(handler.GetComponent<TcpLink>().serverOut())){
            MainMenuHandler.selected = this.gameObject.name;
        }
        if (this.gameObject.name.Equals("Yellow") && !yellow.IsMatch(handler.GetComponent<TcpLink>().serverOut())){
            MainMenuHandler.selected = this.gameObject.name;
        }
        if (this.gameObject.name.Equals("Blue") && !blue.IsMatch(handler.GetComponent<TcpLink>().serverOut())){
            MainMenuHandler.selected = this.gameObject.name;
        }
        if (this.gameObject.name.Equals("Brown") && !brown.IsMatch(handler.GetComponent<TcpLink>().serverOut())){
            MainMenuHandler.selected = this.gameObject.name;
        }
        if (!MainMenuHandler.selected.Equals("")) {
            if (MainMenuHandler.selected.Equals("Purple")){
                handler.GetComponent<TcpLink>().sendMessageToServer("PR");
            }
            if (MainMenuHandler.selected.Equals("Yellow"))
            {
                handler.GetComponent<TcpLink>().sendMessageToServer("YE");
            }
            if (MainMenuHandler.selected.Equals("Blue"))
            {
                handler.GetComponent<TcpLink>().sendMessageToServer("BL");
            }
            if (MainMenuHandler.selected.Equals("Brown"))
            {
                handler.GetComponent<TcpLink>().sendMessageToServer("BR");
            }

        }
        
    }

    public void OnDeselect(BaseEventData eventData) {
        //
    }
}
