using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance = null;
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //For there to only be one camera. otherwise destroy the other one
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Start next camera when camera count is 0
    /// </summary>
    void StartCamera()
    {
        if(cameras.Count > 0)
        {
            cameras[0].SetActive(true);
        }

    }
        
    /// <summary>
    /// Method to remove a camera from list when used
    /// </summary>
    /// <param name="camera"></param>
    public void RemoveCamera(GameObject camera)
    {
        cameras.RemoveAt(0);
        Destroy(camera);
        StartCamera();
    }

}
