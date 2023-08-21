using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notets : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * MusicPlayManager.instance.speedGain * Time.fixedDeltaTime);
    }
}
