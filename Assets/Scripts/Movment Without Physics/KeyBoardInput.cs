using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class KeyBoardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private PhysicsJump _jump;
    [SerializeField] private Vector3 _directionJump;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
       
        _movement.Move(new Vector3(horizontal, 0, 0));

        if (Input.GetMouseButtonDown(0) == true)
        {
            _jump.Jump(_directionJump);
        }
    }
}
