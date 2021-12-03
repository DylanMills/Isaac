using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    Transform trans;

    Door[] doors;
    ItemSpawn[] itemSpawns;
    EnemySpawn[] enemySpawns;

    bool[] isConnectedURDL = new bool[4];

    public static float _height = 40f;
    public static float _width = _height * 1.6f;
    public static float _scale = _height / 10f;

    bool isComplete;

    void Awake()
    {
        trans = GetComponent<Transform>();

        itemSpawns = GetComponentsInChildren<ItemSpawn>();
        enemySpawns = GetComponentsInChildren<EnemySpawn>();

        for (int i = 0; i < 4; i++)
        {
            SetConnected(i, false);
        }
        isComplete = false;

        trans.position = new Vector3(trans.position.x * _width, trans.position.y * _height);
    }

    public void AutoSetConnected(Transform roomTrans)
    {
        Debug.Log("Setting up walls...");

        Debug.Log("Current pos: " + trans.position);
        Debug.Log("Other pos: " + roomTrans.position);

        if (roomTrans.position == new Vector3(trans.position.x, trans.position.y + _height))
        {
            SetConnected(0, true);
        }

        if (roomTrans.position == new Vector3(trans.position.x, trans.position.y - _height))
        {
            SetConnected(2, true);
        }

        if (roomTrans.position == new Vector3(trans.position.x + _width, trans.position.y))
        {
            SetConnected(1, true);
        }

        if (roomTrans.position == new Vector3(trans.position.x - _width, trans.position.y))
        {
            SetConnected(3, true);
        }
    }

    public void SetWalls(GameObject wall, GameObject door)
    {
        if (!GetConnected(0))
        {
            Instantiate(wall, new Vector3(trans.position.x, trans.position.y + 4.25f), Quaternion.Euler(0, 0, 0), trans);
            // create a wall object if there is no adjacent room in this direction
        }
        else
        {
            Instantiate(door, new Vector3(trans.position.x, trans.position.y + 4.25f), Quaternion.Euler(0, 0, 0), trans);
            // otherwise, create a door object.
        }

        if (!GetConnected(1))
        {
            Instantiate(wall, new Vector3(trans.position.x + 7.25f, trans.position.y), Quaternion.Euler(0, 0, -90), trans);
        }
        else
        {
            Instantiate(door, new Vector3(trans.position.x + 7.25f, trans.position.y), Quaternion.Euler(0, 0, -90), trans);
        }

        if (!GetConnected(2))
        {
            Instantiate(wall, new Vector3(trans.position.x, trans.position.y - 4.25f), Quaternion.Euler(0, 0, 180), trans);
        }
        else
        {
            Instantiate(door, new Vector3(trans.position.x, trans.position.y - 4.25f), Quaternion.Euler(0, 0, 180), trans);
        }

        if (!GetConnected(3))
        {
            Instantiate(wall, new Vector3(trans.position.x - 7.25f, trans.position.y), Quaternion.Euler(0, 0, 90), trans);
        }
        else
        {
            Instantiate(door, new Vector3(trans.position.x - 7.25f, trans.position.y), Quaternion.Euler(0, 0, 90), trans);
        }

        FixScale();

        doors = GetComponentsInChildren<Door>(); // adds all doors to the list
    }

    void FixScale()
    {
        trans.localScale *= _scale;
    }

    public bool GetConnected(int direction)
    {
        return isConnectedURDL[direction];
    }

    public void SetConnected(int direction, bool isConnected)
    {
        isConnectedURDL[direction] = isConnected;
    }

    public bool GetComplete()
    {
        return isComplete;
    }

    // sets complete for the room and performs proper actions (opens doors and spawns items)
    public void SetComplete()
    {
        isComplete = true;

        foreach (Door door in doors)
        {
            door.Open();
        }

        foreach (ItemSpawn spawn in itemSpawns)
        {
            spawn.SpawnItem();
        }
    }

    // sets up everything to be done when the player enters the room (shuts doors and spawns enemies)
    public void EnterRoom()
    {
        if (!isComplete)
        {
            foreach (Door door in doors)
            {
                door.Close();
            }

            foreach (EnemySpawn spawn in enemySpawns)
            {
                spawn.SpawnEnemy();
            }
        }
    }
}
