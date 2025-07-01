using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControlledCube : MonoBehaviour
{
    public float moveSpeed = 10f; public float reverseSpeed = 5f; public float turnSpeed 100f; public float brakeDrag = 5f;
    private float steeringInput = 0f; private Vector3 velocity = Vector3.zero;
    private InputAction joystickThrottle; private InputAction keyboardThrottle; private InputAction joystickBrake; private InputAction keyboardBrake; private InputAction steeringAction;
    C Unity Message | O references
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
