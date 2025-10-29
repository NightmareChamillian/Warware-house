using System.Collections;
using UnityEngine;

public class TeleporterPad : MonoBehaviour
{
    public Room parentRoom;
    public TeleporterPad destination;

    bool readyToTeleport;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        readyToTeleport = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerData player = collision.gameObject.GetComponent<PlayerData>();
        if (player == null || !readyToTeleport)
            return;

        destination.Teleport(player);

        parentRoom.ExitRoom();
    }

    public void Teleport(PlayerData player)
    {
        player.transform.position = gameObject.transform.position + new Vector3(0, 2f, 0);
        readyToTeleport = false;
        StartCoroutine(TeleportCooldownRoutine());

        parentRoom.EnterRoom();
    }

    private IEnumerator TeleportCooldownRoutine()
    {
        yield return new WaitForSeconds(1f);
        readyToTeleport = true;
    }
}
