using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectables : MonoBehaviour, I_Interact
{
    [Header("Item information")]
    public string itemName;

    public GameObject ObjectUI;
    public TextMeshProUGUI nameLabel;

    private Transform _player;

    private void Start()
    {
        nameLabel.text = itemName;
    }

    public void OnClick(GameObject rayCastParent)
    {
        
    }
    public void OnRelease(GameObject rayCastParent)
    {
        P_InventoryMain.Instance.AddItem(gameObject);
        rayCastParent.GetComponent<C_FPSCamera>().RemoveInterface();
        Destroy(gameObject);
    }
    public void OnHit(GameObject rayCastParent)
    {
        _player = rayCastParent.transform;
        if (ObjectUI.activeInHierarchy) return;
        ObjectUI.SetActive(true);
    }
    public void OnLeave()
    {
        if (!ObjectUI.activeInHierarchy) return;
        ObjectUI.SetActive(false);
    }

    private void LateUpdate()
    {
        if (!_player) return;
        ObjectUI.transform.LookAt(_player);
    }
}
