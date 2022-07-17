using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSliderLeft : MonoBehaviour
{
    private void OnMouseDown() {
        CameraBehavior.slideLeft = true;
        CameraBehavior.isSliding = true;
    }
}
