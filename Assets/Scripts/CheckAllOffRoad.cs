using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllOffRoad : MonoBehaviour
{

    private bool IsRoad;
    //private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if(IsRoad)
        {
            Debug.Log("Raycast");
            Debug.DrawLine(transform.position, transform.forward * -1 * 10f, Color.red);
        }
        Debug.Log(IsRoad);
    }
    private void RayCastToRoad()
    {
        IsRoad = Physics.Raycast(transform.position, transform.forward * -1f, 10f, layerMask);
    }    
}
