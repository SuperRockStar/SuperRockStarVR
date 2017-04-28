using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class CreateVideoPlayer : MonoBehaviour {

    [SerializeField]
    protected VideoSource m_Source;

    [SerializeField]
    protected VideoClip m_Video;

    [SerializeField]
    protected string m_VideoUrl;

    protected VideoPlayer m_VideoPlayer;

    protected AudioSource m_AudioSource;

	void Start()
    {
        StartCoroutine(WaitUntilVideoPrepare());
    }

    IEnumerator WaitUntilVideoPrepare()
    {
        //Add VideoPlayer to the GameObject
        m_VideoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        m_AudioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        m_VideoPlayer.playOnAwake = false;
        m_AudioSource.playOnAwake = false;

        m_VideoPlayer.frame = 250;

        //We want to play from video clip or url
        m_VideoPlayer.source = m_Source;
        
        switch(m_Source)
        {
            case VideoSource.Url:
                m_VideoPlayer.url = m_VideoUrl;
                break;
            case VideoSource.VideoClip:
                m_VideoPlayer.clip = m_Video;
                break;
        }
        
        //Set Audio Output to AudioSource
        m_VideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        m_VideoPlayer.EnableAudioTrack(0, true);
        m_VideoPlayer.SetTargetAudioSource(0, m_AudioSource);

        m_VideoPlayer.Prepare();

        while (!m_VideoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return null;
        }

        Debug.Log("Preparing Video");

        m_VideoPlayer.Play();

        //Play Sound
        m_AudioSource.Play();

        while (m_VideoPlayer.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene("RootScene");
    }
}
