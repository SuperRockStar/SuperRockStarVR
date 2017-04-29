using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetPhase
{
    Over,
    Out,
    Activated
}

[RequireComponent(typeof(Collider))]
public class CameraEyeRaycastTarget : MonoBehaviour {

    public TargetPhase currentPhase { private set; get; }

    [SerializeField]
    protected float m_LoadTime;

    private float m_CurrentTime;

    public float loadPercent
    {
        get
        {
            if (m_CurrentTime < 0)
                return 0;
            return m_CurrentTime / m_LoadTime;
        }
    }

    protected virtual void Awake()
    {
        currentPhase = TargetPhase.Out;
        m_CurrentTime = -2;
    }

    protected virtual void Update()
    {
        switch(currentPhase)
        {
            case TargetPhase.Out:
                m_CurrentTime = -2;
                break;
            case TargetPhase.Over:
                m_CurrentTime += Time.deltaTime;
                if (m_CurrentTime > m_LoadTime)
                {
                    m_CurrentTime = m_LoadTime;
                    Activated();
                }
                break;
            case TargetPhase.Activated:
                break;
        }
    }

	public void Over()
    {
        currentPhase = TargetPhase.Over;
        OnOver();
    }

    public void Out()
    {
        currentPhase = TargetPhase.Out;
        OnOut();
    }

    protected void Activated()
    {
        currentPhase = TargetPhase.Activated;
        OnActivated();
    }

    protected virtual void OnOver()
    {

    }

    protected virtual void OnOut()
    {

    }

    protected virtual void OnActivated()
    {

    }
}
