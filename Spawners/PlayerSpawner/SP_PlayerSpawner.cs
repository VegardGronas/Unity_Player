using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    private void Start()
    {
        Instantiate(_playerPrefab, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}
