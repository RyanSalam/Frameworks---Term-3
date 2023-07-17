using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorks.Core
{
    public class MoveToMouse : MonoBehaviour
    {
        private void Update()
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit mouseHit, Mathf.Infinity))
            {
                transform.position = mouseHit.point;
            }
        }
    }

}

