using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SelectionRadial : MonoBehaviour {

    public event Action OnSelectionComplete;                                                // This event is triggered when the bar has filled.


    [SerializeField]
    private float m_SelectionDuration = 2f;                                // How long it takes for the bar to fill.
    [SerializeField]
    private bool m_HideOnStart = true;                                     // Whether or not the bar should be visible at the start.
    [SerializeField]
    private Image m_Selection;                                             // Reference to the image who's fill amount is adjusted to display the bar.

    public float SelectionDuration { get { return m_SelectionDuration; } }

    private void Start()
    {
        // Setup the radial to have no fill at the start and hide if necessary.
        m_Selection.fillAmount = 0f;
    }


    public void SetFill(float percent)
    {
        m_Selection.fillAmount = percent;
    }
}