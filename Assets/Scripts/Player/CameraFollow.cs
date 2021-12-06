using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform cameraTrans;

    [SerializeField] Player player;
    Transform playerTrans;

    Vector3 prevPos;
    Vector3 nextPos;

    float scrollSpeed = 3f;
    float moveTimer;

    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = GetComponent<Transform>();
        playerTrans = player.GetComponent<Transform>();

        prevPos = cameraTrans.position;
        nextPos = cameraTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTrans.position != nextPos)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            if (playerTrans.position.y > cameraTrans.position.y + (Room._height / 2))
            {
                playerTrans.position += Vector3.up * (Room._scale + 2);

                SetupMove(new Vector3(0, Room._height));
            }
            if (playerTrans.position.y < cameraTrans.position.y - (Room._height / 2))
            {
                playerTrans.position -= Vector3.up * (Room._scale + 2);

                SetupMove(new Vector3(0, -Room._height));
            }
            if (playerTrans.position.x > cameraTrans.position.x + (Room._width / 2))
            {
                playerTrans.position += Vector3.right * (Room._scale + 2);

                SetupMove(new Vector3(Room._width, 0));
            }
            if (playerTrans.position.x < cameraTrans.position.x - (Room._width / 2))
            {
                playerTrans.position -= Vector3.right * (Room._scale + 2);

                SetupMove(new Vector3(-Room._width, 0));
            }
        }
        else
        {
            MoveCam();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GetComponent<Camera>().orthographicSize *= 5f;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            GetComponent<Camera>().orthographicSize /= 5f;
        }
    }

    void SetupMove(Vector3 finalMovement)
    {
        prevPos = cameraTrans.position;
        nextPos = cameraTrans.position + finalMovement;
        moveTimer = 0f;
    }

    void MoveCam()
    {
        moveTimer += Mathf.Clamp01(Time.deltaTime * scrollSpeed);

        cameraTrans.position = Vector3.Lerp(prevPos, nextPos, moveTimer);
    }
}
