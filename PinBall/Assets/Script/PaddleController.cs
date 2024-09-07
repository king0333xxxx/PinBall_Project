using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;

    // menyimpan angka target position saat ditekan dan dilepas
    public float targetPressed;
    private float targetRelease;

    //public float baseTarget;
    //public float basePresed;

    private HingeJoint hinge;

    public bool leftPadd = false;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        // saat Start, kita set kedua target tersebut
        //targetPressed = hinge.limits.max;
        targetRelease = hinge.spring.targetPosition;

    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;

        if (Input.GetKey(input))
        {
            
           //disini kita ganti menjadi mengubah target position nya
           jointSpring.targetPosition = targetPressed;
            
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        hinge.spring = jointSpring;
    }   
}
