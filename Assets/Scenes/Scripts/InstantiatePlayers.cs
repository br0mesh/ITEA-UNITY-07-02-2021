using UnityEngine;

public class InstantiatePlayers : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Instantiate(player, player.transform.position, Quaternion.identity);
    }
}
