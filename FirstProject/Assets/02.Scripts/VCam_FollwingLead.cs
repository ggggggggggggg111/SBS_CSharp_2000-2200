using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam_FollwingLead : MonoBehaviour
{
    private CinemachineVirtualCamera _VCam;

    private void Awake()
    {
        _VCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void LateUpdate()
    {
        Transform lead = RaceManager.instance.lead.transform;
        _VCam.Follow = lead;
        _VCam.LookAt = lead;
    }
}
