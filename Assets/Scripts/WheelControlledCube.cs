using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WheelControlledCube : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float reverseSpeed = 5f;
    public float turnSpeed 100f;
    public float brakeDrag = 5f;
    private float steeringInput = 0f;
    private Vector3 velocity = Vector3.zero;
    private InputAction joystickThrottle;
    private InputAction keyboardThrottle;
    private InputAction joystickBrake;
    private InputAction keyboardBrake;
    private InputAction steeringAction;


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


        void onEnable()
        {
            // Set up joystick and keyboard as separate actions joystickThrottle = new InputAction(type: InputActionType.Value, binding: "<Joystick>/z"); keyboardThrottle = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/w");
            joystickBrake = new InputAction(type: InputActionType.Value, binding: "<Joystick>/rz"); keyboardBrake = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/s");
            steeringAction = new InputAction(type: InputActionType.Value);
            steeringAction.AddBinding("<Joystick>/stick/x"); steeringAction.AddCompositeBinding("1DAxis")
            .With("negative", "<Keyboard>/a")
            .With("positive", "<Keyboard>/d");
            joystickThrottle.Enable();
            keyboardThrottle.Enable();
            joystickBrake.Enable();
            keyboardBrake.Enable();
            steeringAction.Enable();
        }

        void OnDisable()
        {
            joystick Throttle.Disable();
            keyboardThrottle.Disable();
            joystickBrake.Disable();
            keyboardBrake.Disable();
            steeringAction.Disable();
        }

    }
}
