using UnityEngine;
using UnityEditor;
using System.Collections;

public class Camera_WASD_movement: MonoBehaviour
{
    //Created by Lex4art at 10 June 2018. This script adds free camera controls via WASD/arrows keys + mouse
    //Hold "Shift" to increase movement speed or hold "Space" to decrease it. Hold "E" or "Q" to up/down movement.

    public int MovementSpeed = 50;        //Basic camera movement spee; default is "50".
    public int ShiftKeyBoost = 3;         //Multipler for camera movement speed when "Shift" key is pressed. Default is "3".
    public int SpaceKeySlowdown = 3;      //Slowdown multipler for camera movement when "Space" key is pressed. Default is "3"
    public int MouseSensitivity = 100;    //Than more that value than more sensitive mouse movement; default is "100".

    private float MouseSensitivityNormalized;
    private float MovementSpeedNormalized;
    private float RotationHorizontal = 0.0f;
    private float RotationVertical = 0.0f;

    
    void Start()
    {
        #if (UNITY_EDITOR) //Hide cursor in "Play" mode; only inside Unity editor.
        Cursor.lockState = CursorLockMode.Locked;
        #endif
        RotationHorizontal = this.transform.eulerAngles.y;    //Inhernit camera's horizontal orientation from editor.
    }
    

    void Update()
    {
        #if (UNITY_EDITOR) //Hide cursor in "Play" mode after losing viewport focus and bringing back cursor again; only inside Unity editor.
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endif

        MouseSensitivityNormalized = ((MouseSensitivity / Time.deltaTime) / 100) * Time.deltaTime;
        RotationHorizontal += Input.GetAxis("Mouse X") * MouseSensitivityNormalized;
        RotationVertical += Input.GetAxis("Mouse Y") * MouseSensitivityNormalized;
        RotationVertical = Mathf.Clamp(RotationVertical, -89, 89);
        transform.localRotation = Quaternion.AngleAxis(RotationHorizontal, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(RotationVertical, Vector3.left);

        MovementSpeedNormalized = (MovementSpeed * Time.deltaTime) / 10;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            transform.position += transform.forward * Input.GetAxis("Vertical") * MovementSpeedNormalized * ShiftKeyBoost;
            transform.position += transform.right * Input.GetAxis("Horizontal") * MovementSpeedNormalized * ShiftKeyBoost;
            if (Input.GetKey(KeyCode.Q)) { transform.position -= transform.up * (MovementSpeedNormalized / 3) * ShiftKeyBoost; }
            if (Input.GetKey(KeyCode.E)) { transform.position += transform.up * (MovementSpeedNormalized / 3) * ShiftKeyBoost; }
        }
        else
        {
            transform.position += transform.forward * Input.GetAxis("Vertical") * MovementSpeedNormalized;
            transform.position += transform.right * Input.GetAxis("Horizontal") * MovementSpeedNormalized;
            if (Input.GetKey(KeyCode.Q)) { transform.position -= transform.up * MovementSpeedNormalized / 3; }
            if (Input.GetKey(KeyCode.E)) { transform.position += transform.up * MovementSpeedNormalized / 3; }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.forward * Input.GetAxis("Vertical") * (MovementSpeedNormalized / SpaceKeySlowdown);
            transform.position += transform.right * Input.GetAxis("Horizontal") * (MovementSpeedNormalized / SpaceKeySlowdown);
            if (Input.GetKey(KeyCode.Q)) { transform.position -= transform.up * (MovementSpeedNormalized / 3) / SpaceKeySlowdown; }
            if (Input.GetKey(KeyCode.E)) { transform.position += transform.up * (MovementSpeedNormalized / 3) / SpaceKeySlowdown; }
        }
        else
        {
            transform.position += transform.forward * Input.GetAxis("Vertical") * MovementSpeedNormalized;
            transform.position += transform.right * Input.GetAxis("Horizontal") * MovementSpeedNormalized;
            if (Input.GetKey(KeyCode.Q)) { transform.position -= transform.up * MovementSpeedNormalized / 3; }
            if (Input.GetKey(KeyCode.E)) { transform.position += transform.up * MovementSpeedNormalized / 3; }
        }
        
    }
}