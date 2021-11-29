using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    List<CheckPointBehaviour> checkpoints = new List<CheckPointBehaviour>();
    CheckPointBehaviour currentCheckpoint;

    private void Start()
    {
        foreach(CheckPointBehaviour checkpoint in GetComponentsInChildren<CheckPointBehaviour>())
        {
            checkpoints.Add(checkpoint);
        }
        currentCheckpoint = checkpoints[0];
    }

    public void OnPlayerDeath()
    {
        PlayerManager.Player.transform.position = currentCheckpoint.transform.position;
    }

    public void ChangeCurrentCheckpoint(CheckPointBehaviour newCheckPoint)
    {
        if (currentCheckpoint == newCheckPoint) return;
        currentCheckpoint.DeActivate();
        currentCheckpoint = newCheckPoint;
    }

}
