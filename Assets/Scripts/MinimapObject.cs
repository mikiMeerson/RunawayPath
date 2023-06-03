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

    void Update()
    {
        // Convert the world position of the object to the minimap's local coordinate system
        Vector3 minimapPosition = minimapCamera.WorldToViewportPoint(transform.position);

        // Update the position of the minimap icon based on the object's position
        if (isEnemy)
        {
            minimapIcon.color = Color.red;
        }
        else if (isPlayer)
        {
            minimapIcon.color = Color.blue;
        } else
        {
            minimapIcon.color = Color.green;
        }
        minimapIcon.rectTransform.anchorMin = minimapPosition;
        minimapIcon.rectTransform.anchorMax = minimapPosition;
    }
}
