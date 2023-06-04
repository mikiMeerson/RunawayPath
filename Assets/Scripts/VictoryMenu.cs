using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VictoryMenu : MonoBehaviour
{
    public Transform playerTransform;
    public Transform[] coinTransforms;

    private Vector3 playerInitialPosition;
    private Quaternion playerInitialRotation;
    private Vector3[] coinInitialPositions;

    void OnEnable()
    {
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button restartGame = root.Q<Button>("startGame");
        Button quitGame = root.Q<Button>("quitGame");


        // Store initial positions and rotations
        playerInitialPosition = playerTransform.position;
        playerInitialRotation = playerTransform.rotation;

        coinInitialPositions = new Vector3[coinTransforms.Length];
        for (int i = 0; i < coinTransforms.Length; i++)
        {
            coinInitialPositions[i] = coinTransforms[i].position;
        }

        restartGame.clicked += () => {
            Debug.Log("startGame button");

            gameObject.SetActive(false);

            // Reset player position and rotation
            playerTransform.position = playerInitialPosition;
            playerTransform.rotation = playerInitialRotation;

            // Reset coin positions
            for (int i = 0; i < coinTransforms.Length; i++)
            {
                coinTransforms[i].position = coinInitialPositions[i];
                coinTransforms[i].gameObject.SetActive(true);
            }

            // Hide the cursor when the game starts
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;

        };

        quitGame.clicked += () => Application.Quit();

    }
}
