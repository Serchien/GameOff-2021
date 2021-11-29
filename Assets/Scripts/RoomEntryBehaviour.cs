using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryBehaviour : MonoBehaviour
{
    EncounterManager manager;


    void Start()
    {
        manager = GetComponentInParent<EncounterManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (collision.GetComponent<PlayerHealthManager>())
        {
            manager.OnRoomEnter();
        }
    }

}
