using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody _rigid;
    public Vector3 Velocity { get; private set; }

    private void OnEnable()
    {
        P_PlayerMain.moveDirection += OnMoveDirectionChange;
    }

    private void OnDisable()
    {
         P_PlayerMain.moveDirection -= OnMoveDirectionChange;
    }

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void OnMoveDirectionChange(Vector2 dir)
    {
        Velocity = new Vector3(dir.x * speed, 0, dir.y * speed);
    }

    private void FixedUpdate()
    {
        Vector3 forward = transform.forward * Velocity.z;
        Vector3 right = transform.right * Velocity.x;
        Vector3 final = forward + right;

        _rigid.AddForce(final, ForceMode.Impulse);
    }
}
