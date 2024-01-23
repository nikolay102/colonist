using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameratarget;
    private Vector3 pos;

    void Update()
    {
        var position = cameratarget.position;
        pos = position;
        pos.z = -10f;
        pos.y = position.y + 2f ;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime + 0.05f);
    }
}
