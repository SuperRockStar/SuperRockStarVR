using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : CameraEyeRaycastTarget {

    public string LoadSceneName = "";

    protected override void OnActivated()
    {
        base.OnActivated();

        SceneManager.LoadScene(LoadSceneName);
    }
}
