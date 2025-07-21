using System;
using System.Collections;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        transform.forward =Camera.main.transform.forward;
    }
}