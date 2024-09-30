using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArrowController : MonoBehaviour
{
    public float rotateAmount = 0;

    public void SelectArrowLeft()
    {
        rotateAmount = -0.5f;
    }

    public void DeselectArrowLeft()
    {
        rotateAmount = 0;
    }

    public void SelectArrowRight()
    {
        rotateAmount = 0.5f;
    }

    public void DeselectArrowRight()
    {
        rotateAmount = 0;
    }
}
