using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftables : MonoBehaviour, I_Interact
{
    public void OnClick(GameObject playerHand)
    {
        transform.SetParent(playerHand.transform);
        transform.position = playerHand.transform.position;
        transform.rotation = playerHand.transform.rotation;
    }
    public void OnRelease(GameObject rayCastParent)
    {
        transform.parent.DetachChildren();
    }
    public void OnHit(GameObject rayCastParent)
    {

    }
    public void OnLeave()
    {

    }
}
