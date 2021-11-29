using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcourManager : MonoBehaviour
{
    [SerializeField] Transform checkpoint;
    public bool parcourActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCheckpoint(GameObject _player)
    {
        _player.transform.position = checkpoint.position;
    }
}
