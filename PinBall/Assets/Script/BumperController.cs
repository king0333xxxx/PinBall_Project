using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    // Reference collider untuk bola
    public Collider ball;

    // Multiplier untuk kecepatan bola
    public float multiplier;

    // Warna yang ingin diterapkan pada bumper
    public Color baseColor;
    public Color hitColor;


    // Komponen renderer pada object
    private Renderer renderer;
    private Animator animator;

    public bool animClear = false ;

    // Fungsi yang dipanggil pertama kali saat objek aktif
    void Start()
    {
        animClear = false ;

        // Ambil komponen Renderer dari object
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        // Pastikan material dan renderer ada, lalu ubah warnanya
        if (renderer != null && renderer.material != null)
        {
            Debug.Log("Mengubah warna bumper pada Start.");
            renderer.material.color = baseColor;
        }
        else
        {
            Debug.LogWarning("Renderer atau material tidak ditemukan.");
        }
    }

    private void Update()
    {
        if (animClear)
        {
            renderer.material.color = baseColor;
            animClear = false;
        }
    }

    // Fungsi yang dipanggil setiap kali terjadi tabrakan
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == ball)
        {
            Debug.Log("Hit");
            renderer.material.color = hitColor;

            // Ubah kecepatan bola saat menabrak bumper
            Rigidbody bolaRig = ball.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            // Trigger animasi saat tabrakan terjadi
            animator.SetTrigger("Hit");
            animClear = true;
            

        }
    }
}
