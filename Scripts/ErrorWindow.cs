using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWindow : MonoBehaviour {

    public GameObject window;

    public void Hide()
    {
        window.SetActive(false);
    }
}
