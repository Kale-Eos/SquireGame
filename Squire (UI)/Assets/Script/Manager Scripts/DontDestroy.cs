using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    void Awake ()
    {
        // Finds music tags and prevents it from stopping
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        // actual command to not destroy
        DontDestroyOnLoad(this.gameObject);
    }

}
