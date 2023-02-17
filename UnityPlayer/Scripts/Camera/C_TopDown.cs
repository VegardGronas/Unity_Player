using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TopDown : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Camera _camera;
    [SerializeField] private Rigidbody _rigid;
    private bool shouldMove;
    private Vector3 destination;

    private void OnEnable()
    {
        P_PlayerMain.mouseLeftClick += OnCharacterMove;
    }
    private void OnDisable()
    {
        P_PlayerMain.mouseLeftClick -= OnCharacterMove;
    }
    private void OnCharacterMove(bool move)
    {
        shouldMove = move;
    }


    public void FixedUpdate()
    {
        if (shouldMove)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                destination = (hit.point - _rigid.transform.position);
            }
        }

        if(Vector3.Distance(_rigid.transform.position, destination) > .5f)
        {
            _rigid.AddForce(destination, ForceMode.Impulse);
        }
    }
}