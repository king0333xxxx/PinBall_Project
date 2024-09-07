using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    //reference collider ball
    public Collider ball;

    //multiplier
    public float multiplier;

    // untuk mengatur warna bumper
    public Color color;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        

        // karena material ada pada component Rendered, maka kita ambil renderernya
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        // kita akses materialnya dan kita ubah warna nya saat Start
        renderer.material.color = color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == ball)
        {
            Debug.Log("Hit");

            //get rigidbody then multiplier the ball speed
            Rigidbody bolaRig = ball.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            // saat ditabrak oleh bola, kita tinggal aktifkan trigger Hit
            animator.SetTrigger("Hit");
        }
    }
}
