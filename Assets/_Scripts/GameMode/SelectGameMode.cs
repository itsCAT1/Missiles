using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public PlaneController planeController;
    public GameObject joystick;
    public GameObject buttonArrow;
    public int indexSelect = 0;
    // Update is called once per frame

    void FixedUpdate()
    {
        if (indexSelect == 0)
        {
            planeController.MovingInputJoystickbase();
            buttonArrow.gameObject.SetActive(false);
            joystick.gameObject.SetActive(true);
        }

        else if (indexSelect == 1)
        {
            planeController.MovingInputButtonArrow();
            buttonArrow.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

        else if (indexSelect == 2)
        {
            planeController.MovingInputMoveFinger();
            buttonArrow.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);
        }
    }

    public void Select()
    {
        indexSelect++;
        if(indexSelect > 2)
        {
            indexSelect = 0;
        }
    }
}
