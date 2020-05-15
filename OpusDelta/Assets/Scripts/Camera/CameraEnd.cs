using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    public void AnimationEnd()
    {
        AnimationManager.instance.RemoveCamera(gameObject);
    }
}
