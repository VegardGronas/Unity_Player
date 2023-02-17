using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Interact
{
    public void OnClick(GameObject rayCastParent);
    public void OnRelease(GameObject rayCastParent);
    public void OnHit(GameObject rayCastParent);
    public void OnLeave();
}
