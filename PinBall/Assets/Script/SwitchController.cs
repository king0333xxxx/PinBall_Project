using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    // menyimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;

    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;

    // menggantikan isOn
    private SwitchState state;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // memastikan yang menabrak adalah bola
        if (other == bola)
        {
            // kita lakukan debug
            //Debug.Log("Kena Bola");
            if (other == bola)
            {
                Toggle();
            }
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    // blink diubah total
    private IEnumerator Blink(int times)
    {
        // set statenya menjadi blink dulu sebelum mulai proses
        state = SwitchState.Blink;

        // mulai proses blink tanpa mengubah state lagi
        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        // set menjadi off kembali setelah proses blink
        state = SwitchState.Off;
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
