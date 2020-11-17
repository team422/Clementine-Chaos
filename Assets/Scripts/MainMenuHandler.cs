using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    public static string selected = "";

    public static bool isBrownSelected = false;
    public static bool isYellowSelected = false;
    public static bool isBlueSelected = false;
    public static bool isPurpleSelected = false;

    private AsyncOperation gameLoading;
    private bool loadingNext;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected.Equals("")) {
            Debug.Log(selected);
            gameObject.GetComponent<TcpLink>().CloseSocket();
            gameLoading = SceneManager.LoadSceneAsync("GameScene");

            

            loadingNext = true;
        }
        if (loadingNext&&gameLoading.isDone)
        {
            Debug.Log(selected);
            SwitchToGame();
        }
    }

    void SwitchToGame() {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
    }
}
