using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    protected Transform m_Player;

    void Awake()
    {
        m_Player = Camera.main.transform;
    }

    void Update()
    {
        if (m_Player == null)
            return;

        transform.LookAt(m_Player);
    }
}
