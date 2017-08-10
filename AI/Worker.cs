using UnityEngine;

/*
public class Worker : MonoBehaviour
{

    public bool isWorking        { get; private set; }

    Room homeRoom;
    bool isInElevator;

    Pair<int, int> currentPos;
    Pair<int, int> targetPos;

    public Worker(Room homeRoom)
    {
        this.homeRoom = homeRoom;
        currentPos = new Pair<int, int>(0, -1);
        isInElevator = true;
    }

    void Update()
    {
        MoveTowardsTargetRoom();
    }

    Room targetRoom;
    void NavigateToRoom(Room room)
    {
        if (room == targetRoom || room == homeRoom)
            return;

        isWorking = false;
        targetRoom = room;
    }

    void ReachedDestinationRoom()
    {
        // do something related to the room

        // tell the room about it

        isWorking = true;
        targetRoom = null;
        targetPos = null;
    }

    void MoveTowardsTargetRoom()
    {
        if (targetRoom == null) return;

        if
    }

}
*/