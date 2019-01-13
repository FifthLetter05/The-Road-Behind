using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVersion : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Text>().text += Application.version;
    }
}
