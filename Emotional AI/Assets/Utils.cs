using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static GameObject CreateInstance(GameObject original, GameObject parent, bool isActive)
    {
        GameObject instance = Object.Instantiate(original, parent.transform, false);
        instance.SetActive(isActive);
        return instance;
    }

}
