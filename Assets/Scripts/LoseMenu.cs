using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoseMenu : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject[] coins;
    public Vector3 playerInitialPosition;
    public Quaternion playerInitialRotation;
    public Canvas uiCanvas;

    void OnEnable()
    {
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startGame = root.Q<Button>("startGame");
        Button quitGame = root.Q<Button>("quitGame");

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
