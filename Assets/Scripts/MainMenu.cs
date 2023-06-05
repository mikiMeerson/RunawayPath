using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject[] coins;
    public Canvas uiCanvas;

    private Vector3 playerInitialPosition;
    private Quaternion playerInitialRotation;

    void Start()
    {
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startGame = root.Q<Button>("startGame");
        Button quitGame = root.Q<Button>("quitGame");

        // Store initial positions and rotations
        playerInitialPosition = playerObject.transform.position;
        playerInitialRotation = playerObject.transform.rotation;

        playerObject.SetActive(false);
        uiCanvas.gameObject.SetActive(false);

        startGame.clicked += () => {
            Debug.Log("startGame button");

            gameObject.SetActive(false);

            // Reset player position and rotation
            playerObject.transform.position = playerInitialPosition;
            playerObject.transform.rotation = playerInitialRotation;

            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].SetActive(true);
            }
            
            playerObject.SetActive(true);
            uiCanvas.gameObject.SetActive(true);

            // Hide the cursor when the game starts
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;

        };

        quitGame.clicked += () => Application.Quit();

    }
}
