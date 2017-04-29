using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GraphicButton : CameraEyeRaycastTarget
{
    public string LoadSceneName;

    public UnityEvent OnActivate;

    protected void Start()
    {
    }

    protected override void OnActivated()
    {
        base.OnActivated();
        
        if(OnActivate != null)
            OnActivate.Invoke();

        if(LoadSceneName != "")
            SceneManager.LoadScene(LoadSceneName);
    }
}
