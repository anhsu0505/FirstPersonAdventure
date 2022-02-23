using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static int Items = 0;

    private void OnGUI()
    {
        GUI.Box(new Rect(50, 100, 100, 100), Items.ToString());
    }
}
