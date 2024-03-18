using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private float _movementSpeed = 10f;
    private PhotonView _photonView;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_photonView.IsMine)
            return;

        // make a jump button

        Vector2 input = new Vector2(Input.GetAxis(Utils.INPUT_AXIS_HORIZONTAL), Input.GetAxis(Utils.INPUT_AXIS_VERTICAL)).normalized;
        Vector2 movement = input * _movementSpeed * Time.deltaTime;
        transform.position += new Vector3(movement.x, movement.y);
    }
}
