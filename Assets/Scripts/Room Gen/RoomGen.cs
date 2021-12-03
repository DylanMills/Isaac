using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    Transform trans;

    [SerializeField] List<GameObject> roomPrefabs;
    [SerializeField] GameObject roomBoss;
    [SerializeField] GameObject roomStart;

    [SerializeField] GameObject wall;
    [SerializeField] GameObject door;

    public List<Room> rooms;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        rooms = new List<Room>();

        int branches = Random.Range(2, 5);

        rooms.Add(Instantiate(roomStart, trans.position, Quaternion.Euler(Vector3.zero)).GetComponent<Room>()); // start room

        for (int i = 0; i < branches; i++)
        {
            trans.position = Vector3.zero; // reset position
            CreateBranch(Random.Range(4, 8));
        }

        CreateBossRoom();

        foreach (Room room1 in rooms)
        {
            foreach (Room room2 in rooms)
            {
                room1.AutoSetConnected(room2.GetComponent<Transform>()); // after generating all rooms, determine which ones are connected to eachother
            }

            room1.SetWalls(wall, door); // cover up any doors that arent connected to a room
        }
    }

    void CreateBranch(int length)
    {
        int lastDirectionOpp = -1; // -1 so there is no restriction on the first direction
        int nextDirection;

        for (int i = 0; i < length; i++)
        {
            nextDirection = Random.Range(0, 4);

            while (nextDirection == lastDirectionOpp)
            {
                nextDirection = Random.Range(0, 4); // ensure that the next direction is not the opposite direction of the last.
            }

            switch (nextDirection) // move the generator object one space in a random direction
            {
                case 0: trans.position += Vector3.up; lastDirectionOpp = 2; break;
                case 1: trans.position += Vector3.right; lastDirectionOpp = 3; break;
                case 2: trans.position += Vector3.down; lastDirectionOpp = 0; break;
                case 3: trans.position += Vector3.left; lastDirectionOpp = 1; break;
            }

            CreateRoom();
        }
    }

    void CreateRoom()
    {
        bool spaceOpen = true;

        Vector3 adjustedPosition = new Vector3(trans.position.x * Room._width, trans.position.y * Room._height);
        // adjusts the generator position to account for the size of the room objects

        foreach (Room room in rooms)
        {
            Transform roomTrans = room.GetComponent<Transform>();

            if (roomTrans.position == adjustedPosition)
            {
                spaceOpen = false; // do not create a room if there is already one there; still moves the generator
            }
        }

        if (spaceOpen)
        {
            rooms.Add(Instantiate(RandomRoom(), trans.position, Quaternion.Euler(Vector3.zero)).GetComponent<Room>());
        }
    }

    void CreateBossRoom()
    {
        Destroy(rooms[rooms.Count - 1].gameObject);
        rooms.Add(Instantiate(roomBoss, trans.position, Quaternion.Euler(Vector3.zero)).GetComponent<Room>());
    }

    GameObject RandomRoom()
    {
        int rand = Random.Range(0, roomPrefabs.Count);

        return roomPrefabs[rand];
    }
}
