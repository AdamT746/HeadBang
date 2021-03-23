using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GameObject GunBone;
    public Vector3 Lookat;


    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GunBone.transform.rotation = Quaternion.LookRotation(ray.direction, Lookat);

    }
}
