using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FirstPersonCamera : MonoBehaviour
{
    [BoxGroup("References")]
    public InputManager inputManager;
    [BoxGroup("References")]
    public Transform playerBody;
    [BoxGroup("References")]
    public Animator cameraAnim;

    [BoxGroup("Sensitivity")]
    public float mouseSensitvityX;
    [BoxGroup("Sensitivity")]
    public float mouseSensitvityY;
    float xRotation = 0f;
    
    bool leaningLeft;
    bool leaningRight;  

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvityY * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvityY * Time.deltaTime;

        if(inputManager.leftLean){
            inputManager.leftLean = false;
            leaningLeft = !leaningLeft;
            leaningRight = false;
        }
        if(inputManager.rightLean){
            inputManager.rightLean = false;
            leaningRight = !leaningRight;
            leaningLeft = false;
        }

        cameraAnim.SetBool("RightLean", leaningRight);
        cameraAnim.SetBool("LeftLean", leaningLeft);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
