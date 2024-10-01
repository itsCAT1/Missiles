using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArrowController : MonoBehaviour
{
    public float rotateAmount = 0;

    public void SelectArrowLeft()
    {
        rotateAmount = -1f;
    }

    public void DeselectArrowLeft()
    {
        rotateAmount = 0;
    }

    public void SelectArrowRight()
    {
        rotateAmount = 1f;
    }

    public void DeselectArrowRight()
    {
        rotateAmount = 0;
    }
}
