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

    [Header("Reference Materials")]
    // menyimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;

    [Header("Reference Object")]
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;

    // menggantikan isOn
    private SwitchState state;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;

    [Header("Reference Score")]
    //add Scrore
    public ScoreManager scoreManager;
    public float score;

    [Header("Reference Sfx/VFx")]
    // tambahkan audio manager untuk mengakses fungsi pada audio managernya
    public AudioManager audioManager;
    // tambahkan vfx manager untuk mengakses fungsi pada audio managernya
    public VFXManager vFxManager;

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
            Debug.Log("Kena Bola");
            Toggle();

            // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
            audioManager.PlaySwitchSFX(other.transform.position);

            // kita jalankan VFX saat tabrakan dengan bola pada posisi tabrakannya
            vFxManager.PlaySwitchVFX(other.transform.position);

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
        //tambah score saat menyalakan atau mematikan switch
        scoreManager.AddScore(score);

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
