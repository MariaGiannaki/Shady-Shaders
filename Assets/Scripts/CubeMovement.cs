using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Transform playerCamera;
    GameObject UIController;
    GameObject movableCube;
    GameObject player;

    private void Start()
    {
        UIController = GameObject.Find("UIController");
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movableCube = UIController.GetComponent<UIControls>().GetSelectedCube();
        if (movableCube)
            MoveCube();
    }

    private void MoveCube()
    {
        // Move on X
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveCubeRightX();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveCubeLeftX();
        // Move on Z
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MoveCubeForwardsZ();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            MoveCubeBackwordsZ();
        // Move on Y
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            MoveCubeUpY();
         if (Input.GetKeyDown(KeyCode.KeypadMinus))
            MoveCubeDownY();
    }

    // Use transale to move relative to the rotation of the camera
    private void MoveCubeForwardsZ()
    {
        movableCube.transform.Translate(Vector3.forward, player.transform);
    }
    private void MoveCubeBackwordsZ()
    {
        movableCube.transform.Translate(Vector3.back, player.transform);
    }
    private void MoveCubeRightX()
    {
        movableCube.transform.Translate(Vector3.right, player.transform);
    }
    private void MoveCubeLeftX()
    {
        movableCube.transform.Translate(Vector3.left, player.transform);
    }
    private void MoveCubeUpY()
    {
        movableCube.transform.Translate(Vector3.up, player.transform);
    }
    private void MoveCubeDownY()
    {
        movableCube.transform.Translate(Vector3.down, player.transform);
        if (movableCube.transform.position.y < 0)
            movableCube.transform.position = new Vector3(movableCube.transform.position.x, 0.0f, movableCube.transform.position.z);
    }



}
