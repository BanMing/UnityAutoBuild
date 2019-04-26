//////////////////////////////////////////////////////////////////////////////////////////
//// Dome.cs
//// time:2019/4/26 下午1:59:58			
//// author:BanMing   
//// des:
////////////////////////////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dome : MonoBehaviour
{
    public Text text;
    private int num;
    public void Click()
    {
        num += 1;
        text.text = num.ToString();
    }
}