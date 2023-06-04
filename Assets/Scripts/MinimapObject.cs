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
        // Convert the world position of the object to the minimap's local coordinate system
        Vector3 minimapPosition = minimapCamera.WorldToViewportPoint(transform.position);

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
            minimapIcon.rectTransform.anchorMin = minimapPosition;
            minimapIcon.rectTransform.anchorMax = minimapPosition;
        }
    }

    public void DestroyObject()
    {
        isDestroyed = true;
        HideMinimapIcon();
    }

    private void HideMinimapIcon()
    {
        minimapIcon.rectTransform.anchorMin = new Vector2(0, 0);
        minimapIcon.rectTransform.anchorMax = new Vector2(0, 0);
    }
}
