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

    // Start is called before the first frame update
    void Start()
    {
        gameLoading = SceneManager.LoadSceneAsync("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLoading.isDone) SwitchToGame();
    }

    void SwitchToGame() {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));
    }
}
