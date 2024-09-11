using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioController : MonoBehaviour
{
    private void Start()
    {
        // kita langsung hapus game objectnya setelah 1 detik
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
