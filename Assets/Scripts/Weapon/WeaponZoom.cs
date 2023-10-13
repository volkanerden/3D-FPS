using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    bool isZoomed = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoomed)
            {
                cam.m_Lens.FieldOfView = 20;
                isZoomed = true;
            }
            else 
            {
                cam.m_Lens.FieldOfView = 40;
                isZoomed = false;
            }
        }
    }
}
