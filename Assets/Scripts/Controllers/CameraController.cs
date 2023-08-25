using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + 4, 0, -10);
    }
}
