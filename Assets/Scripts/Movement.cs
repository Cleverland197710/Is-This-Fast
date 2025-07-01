using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
     // Joystick pedals: return 1 when idle, when fully pressed float rawJoyThrottle = joystickThrottle. ReadValue<float>(); float rawJoyBrake = joystickBrake. ReadValue<float>();
     // Invert joystick values if the pedal is actually pressed float joyThrottle = rawJoyThrottle < 0.99f? lf - rawJoyThrottle : of; float joyBrake = rawJoyBrake < 0.99f ? lf - rawJoyBrake: of;
     // Keyboard returns or 1
     float keyThrottle = keyboardThrottle.ReadValue<float>(); float keyBrake = keyboardBrake.ReadValue<float>();
     // Combine both - use whichever input is stronger float throttleInput = Mathf. Max(joyThrottle, keyThrottle); float brakeInput = Mathf.Max(joyBrake, keyBrake); steeringInput = steeringAction. ReadValue<float>();
     Vector3 moveDirection = Vector3.zero;
     if (throttleInput > 0.1f)
     {

     }
     moveDirection = transform.forward * throttleInput * moveSpeed;
     else if (brakeInput > 0.1f)
     {

     }
     else
     {
        moveDirection = -transform.forward brakeInput* reverseSpeed;
        // slow down when no input
        velocity = Vector3.Lerp(velocity, Vector3.zero, brakeDrag * Time.deltaTime);
        if (moveDirection != Vector3.zero)
        {
            velocity = moveDirection;
        }
        transform.Translate(velocity * Time.deltaTime, Space.World);
        float turn = steeringInput * turnSpeed * Time.deltaTime; transform.Rotate(ef, turn, ef);
     }

