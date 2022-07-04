using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppCheck : MonoBehaviour
{
    [SerializeField] private GameObject XRRig;
    [SerializeField] private GameObject EditorRig;
    [SerializeField] private GameObject WebGLRig;

    private void Awake()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                XRRig.SetActive(true);
                EditorRig.SetActive(false);
                WebGLRig.SetActive(false);
                break;
            case RuntimePlatform.WebGLPlayer:
                XRRig.SetActive(false);
                EditorRig.SetActive(false);
                WebGLRig.SetActive(true);
                break;
            case RuntimePlatform.OSXEditor or RuntimePlatform.WindowsEditor:
                XRRig.SetActive(false);
                EditorRig.SetActive(true);
                WebGLRig.SetActive(false);
                break;
        }
    }
}
