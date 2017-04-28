using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraEyeRaycaster : MonoBehaviour {

    public event Action<RaycastHit> OnRaycasthit;                   // This event is called every frame that the user's gaze is over a collider.


    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    private LayerMask m_ExclusionLayers;           // Layers to exclude from the raycast.
    [SerializeField]
    private Reticle m_Reticle;                     // The reticle, if applicable.
    [SerializeField]
    private SelectionRadial m_SelectionRadial;                     // The reticle, if applicable.
    [SerializeField]
    private bool m_ShowDebugRay;                   // Optionally show the debug ray.
    [SerializeField]
    private float m_DebugRayLength = 5f;           // Debug ray length.
    [SerializeField]
    private float m_DebugRayDuration = 1f;         // How long the Debug ray will remain visible.
    [SerializeField]
    private float m_RayLength = 500f;              // How far into the scene the ray is cast.

    private CameraEyeRaycastTarget m_CurrentTarget;                //The current interactive item
    private CameraEyeRaycastTarget m_LastTarger;                   //The last interactive item

    private void Update()
    {
        EyeRaycast();
    }


    private void EyeRaycast()
    {
        // Show the debug ray if required
        if (m_ShowDebugRay)
        {
            Debug.DrawRay(m_Camera.position, m_Camera.forward * m_DebugRayLength, Color.blue, m_DebugRayDuration);
        }

        // Create a ray that points forwards from the camera.
        Ray ray = new Ray(m_Camera.position, m_Camera.forward);
        RaycastHit hit;

        // Do the raycast forweards to see if we hit an interactive item
        if (Physics.Raycast(ray, out hit, m_RayLength, ~m_ExclusionLayers))
        {
            CameraEyeRaycastTarget target = hit.collider.GetComponent<CameraEyeRaycastTarget>(); //attempt to get the VRInteractiveItem on the hit object
            m_CurrentTarget = target;

            // If we hit an interactive item and it's not the same as the last interactive item, then call Over
            if (target && target != m_LastTarger)
                target.Over();

            // Deactive the last interactive item 
            if (target != m_LastTarger)
                DeactiveLastTarget();

            m_LastTarger = target;

            // Something was hit, set at the hit position.
            //if (m_Reticle)
            //    m_Reticle.SetPosition(hit);

            if (OnRaycasthit != null)
                OnRaycasthit(hit);
        }
        else
        {
            // Nothing was hit, deactive the last interactive item.
            DeactiveLastTarget();
            m_CurrentTarget = null;

            // Position the reticle at default distance.
            if (m_Reticle)
                m_Reticle.SetPosition();
        }

        m_SelectionRadial.SetFill(m_CurrentTarget != null ? m_CurrentTarget.loadPercent : 0);
    }


    private void DeactiveLastTarget()
    {
        if (m_LastTarger == null)
            return;

        m_LastTarger.Out();
        m_LastTarger = null;
    }
}
