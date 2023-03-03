using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MainMenuButton
{   
    public string startScene;

    public override void doStuff() {
        SceneManager.LoadScene(startScene, LoadSceneMode.Additive);
    }
}
