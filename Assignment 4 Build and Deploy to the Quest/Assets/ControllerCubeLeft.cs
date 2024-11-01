using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerCubeLeft : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial cube's position in front of user
        transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f - sceneCamera.transform.right * 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Define step value for animation
        step = 5.0f * Time.deltaTime;


        // While user holds the right index trigger, center the cube and turn it to face user
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger)) centerCube();

        // While thumbstick of right controller is currently pressed to the left
        // rotate cube to the left
        //if (OVRInput.Get(OVRInput.RawButton.LThumbstickLeft)) transform.Rotate(0, 5.0f * step, 0);

        //// While thumbstick of right controller is currently pressed to the right
        //// rotate cube to the right
        //if (OVRInput.Get(OVRInput.RawButton.LThumbstickRight)) transform.Rotate(0, -5.0f * step, 0);

        OVRInput.Controller controller = OVRInput.Controller.LTouch; // Select which controller to use (RTouch for right controller)

        Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(controller);
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(controller);

        transform.position = controllerPosition;
        transform.rotation = controllerRotation;


    }

    void centerCube()
    // Places cube smoothly at the center of the user's viewport and rotates it to face the camera
    {
        targetPosition = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f;
        targetRotation = Quaternion.LookRotation(transform.position - sceneCamera.transform.position);

        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
    }
}