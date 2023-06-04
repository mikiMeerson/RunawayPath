using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoseMenu : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject[] coins;

    private Vector3 playerInitialPosition;
    private Quaternion playerInitialRotation;
    private Vector3[] coinInitialPositions;

    void OnEnable()
    {
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startGame = root.Q<Button>("startGame");
        Button quitGame = root.Q<Button>("quitGame");


        // Store initial positions and rotations
        playerInitialPosition = playerTransform.position;
        playerInitialRotation = playerTransform.rotation;

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
        }

        startGame.clicked += () => {
            Debug.Log("startGame button");

            gameObject.SetActive(false);

            // Reset player position and rotation
            playerTransform.position = playerInitialPosition;
            playerTransform.rotation = playerInitialRotation;

            // Hide the cursor when the game starts
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;

        };

        quitGame.clicked += () => Application.Quit();

    }
}
