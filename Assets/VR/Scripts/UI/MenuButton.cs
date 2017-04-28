using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshRenderer))]
public class MenuButton : CameraEyeRaycastTarget {

    public string LoadSceneName = "";

    public float updateImageTime = 0.5f;

    [SerializeField]
    protected List<Texture> m_ImageStack;

    protected Material material;

    protected void Start()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            material = GetComponent<MeshRenderer>().material;

            currentIndex = Random.Range(0, m_ImageStack.Count - 1);

            InvokeRepeating("UpdateImage", 0, updateImageTime);
        }
    }

    int currentIndex = 0;

    bool isInc = true;

    protected void UpdateImage()
    {

        if (m_ImageStack == null || m_ImageStack.Count == 0)
            return;

        material.mainTexture = m_ImageStack[currentIndex];

        currentIndex += isInc ? 1 : -1;

        if (currentIndex + 1 >= m_ImageStack.Count || currentIndex - 1 < 0)
        {
            isInc = !isInc;
            currentIndex = isInc ? 0 : m_ImageStack.Count -1 ;
        }
    }

    protected override void OnActivated()
    {
        base.OnActivated();

        SceneManager.LoadScene(LoadSceneName);
    }
}
