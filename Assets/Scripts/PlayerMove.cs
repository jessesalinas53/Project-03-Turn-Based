using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Movement
{
    void Start()
    {
        GetComponent<Movement>().Intitialize();
    }

    private void Update()
    {
        FindSelectableTiles();
    }
}
