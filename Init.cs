using UnityEngine;

public class Init : MonoBehaviour
{
    void Start()
    {
        MineRoom mine = new MineRoom();
        MineRoom mine2 = new MineRoom();

        GameManager.map.AddEmptyRow();
        GameManager.map.Left[0].AddRoom(mine);
        GameManager.map.Left[0].AddRoom(mine2);
    }
}
