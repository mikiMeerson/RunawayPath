using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapObject : MonoBehaviour
{
    public bool isEnemy;
    public bool isPlayer;
    public Image minimapIcon;
    public Camera minimapCamera;
    public Transform[] objectsToInclude;

    private bool isDestroyed = false;

    void Start()
    {
        // Check if the object should start as destroyed
        if (!gameObject.activeSelf)
        {
            isDestroyed = true;
            HideMinimapIcon();
        }
    }

    void Update()
    {
        // Convert the world position of the object to the screen position relative to the minimap camera
        Vector3 screenPosition = minimapCamera.WorldToScreenPoint(transform.position);

        // Calculate the position of the minimap icon relative to the minimap raw image
        Vector2 minimapIconPosition = new Vector2(screenPosition.x - minimapCamera.pixelRect.x, screenPosition.y - minimapCamera.pixelRect.y);

        // Calculate the normalized position within the minimap raw image
        Vector2 normalizedPosition = new Vector2(minimapIconPosition.x / minimapCamera.pixelRect.width, minimapIconPosition.y / minimapCamera.pixelRect.height);

        // Clamp the position within the boundaries of the minimap viewport
        normalizedPosition.x = Mathf.Clamp01(normalizedPosition.x);
        normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);

        // Update the position of the minimap icon based on the object's position
        if (isDestroyed)
        {
            HideMinimapIcon();
        }
        else
        {
            if (isEnemy)
            {
                minimapIcon.color = Color.red;
            }
            else if (isPlayer)
            {
                minimapIcon.color = Color.blue;
            }
            else
            {
                minimapIcon.color = Color.green;
            }

            // Update the anchor position of the minimap icon
            minimapIcon.rectTransform.anchorMin = normalizedPosition;
            minimapIcon.rectTransform.anchorMax = normalizedPosition;
        }
    }


    public void DestroyObject()
    {
        isDestroyed = true;
        HideMinimapIcon();
    }

    private void HideMinimapIcon()
    {
        // Set the position of the minimap icon outside of the minimap viewport
        minimapIcon.rectTransform.anchorMin = new Vector2(2, 2);
        minimapIcon.rectTransform.anchorMax = new Vector2(2, 2);
    }

    //void LateUpdate()
    //{
    //    // Adjust the minimap camera view to include all objects
    //    if (objectsToInclude.Length > 0)
    //    {
    //        Bounds bounds = new Bounds(objectsToInclude[0].position, Vector3.zero);
    //        for (int i = 1; i < objectsToInclude.Length; i++)
    //        {
    //            bounds.Encapsulate(objectsToInclude[i].position);
    //        }

    //        Vector3 center = bounds.center;
    //        Vector3 extents = bounds.extents;

    //        // Calculate the maximum extent along the x and z axes
    //        float maxExtent = Mathf.Max(extents.x, extents.z);

    //        // Calculate the camera position based on the bounds and desired offset
    //        Vector3 cameraPosition = center;
    //        cameraPosition.y = minimapCamera.transform.position.y; // Preserve the camera's original y position
    //        cameraPosition -= minimapCamera.transform.forward * (maxExtent + 1.0f);

    //        // Set the camera position and orthographic size
    //        minimapCamera.transform.position = cameraPosition;
    //        minimapCamera.orthographicSize = maxExtent;
    //    }
    //}

    void LateUpdate()
    {
        // Adjust the minimap camera view to include all objects
        if (objectsToInclude.Length > 0)
        {
            Bounds bounds = new Bounds(objectsToInclude[0].position, Vector3.zero);
            for (int i = 1; i < objectsToInclude.Length; i++)
            {
                bounds.Encapsulate(objectsToInclude[i].position);
            }

            Vector3 center = bounds.center;
            float maxExtent = bounds.extents.magnitude;

            // Calculate the camera position based on the bounds and desired offset
            Vector3 cameraPosition = center - minimapCamera.transform.forward * (maxExtent + 1.0f);

            // Set the camera position and orthographic size
            minimapCamera.transform.position = cameraPosition;
            minimapCamera.orthographicSize = maxExtent;

            // Set the camera's clear flags to Solid Color and background color to black
            minimapCamera.clearFlags = CameraClearFlags.SolidColor;
            minimapCamera.backgroundColor = Color.black;
        }
    }



}
