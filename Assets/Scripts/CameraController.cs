using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(MainMenuHandler.selected);
        if (!MainMenuHandler.selected.Equals("")) {
            player = GameObject.Find(MainMenuHandler.selected);
        }
        //this.player = GameObject.Find(MainMenuHandler.selected);

        //transform.position = player.transform.position;

        //offset = transform.position - player.transform.position;
        offset = new Vector3(.1f, .1f, transform.position.z-player.transform.position.z);
        
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        Debug.Log(player.name);
        transform.position = player.transform.position + offset + (player.transform.localScale.x > 0 ? Vector3.zero : Vector3.left);
    }
}
