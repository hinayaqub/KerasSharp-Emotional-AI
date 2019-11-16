using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAgent : MonoBehaviour {

    public static bool halloDied;
    private static bool halloLive;
    private static bool markoDied;
    private static bool markoLive;
    private static bool laraDied;
    private static bool laraLive;
    int HalloDeadtimeSec;
    float HalloDeadtime;
    int MarkoDeadtimeSec;
    float MarkoDeadtime;
    int LaraDeadtimeSec;
    float LaraDeadtime;

    public GameObject Hallo;
    public GameObject Lara;
    public GameObject Marko;


    public static bool HalloDied
    {
        get
        {
            return halloDied;
        }

        set
        {
            halloDied = value;
        }
    }

    public static bool HalloLive
    {
        get
        {
            return halloLive;
        }

        set
        {
            halloLive = value;
        }
    }

    public static bool MarkoDied
    {
        get
        {
            return markoDied;
        }

        set
        {
            markoDied = value;
        }
    }
    public static bool MarkoLive
    {
        get
        {
            return markoLive;
        }

        set
        {
            markoLive = value;
        }
    }



    public static bool LaraDied
    {
        get
        {
            return laraDied;
        }

        set
        {
            laraDied = value;
        }
    }

    public static bool LaraLive
    {
        get
        {
            return laraLive;
        }

        set
        {
            laraLive = value;
        }
    }

   

    void Start()
    {
        HalloDeadtime = 0;
        HalloDeadtimeSec = 0;
        MarkoDeadtime = 0;
        MarkoDeadtimeSec = 0;
        LaraDeadtime = 0;
        LaraDeadtimeSec = 0;
    }
    
    void Update()
    {
       // Debug.Log("reach in die update");
        if(HalloDied == true)
        {
            HalloDeadtime += Time.deltaTime;
            HalloDeadtimeSec = (int)HalloDeadtime;
        }
        if(HalloDeadtimeSec == 10)
        {
            Hallo.active = true;
            HalloDied = false;
            HalloLive = true;
            HalloDeadtime = 0;
            HalloDeadtimeSec = 0;
        }

        if (MarkoDied == true)
        {
            MarkoDeadtime += Time.deltaTime;
            MarkoDeadtimeSec = (int)MarkoDeadtime;
        }
        if (MarkoDeadtimeSec == 10)
        {
            Marko.active = true;
            MarkoDied = false;
            MarkoLive = true;
            MarkoDeadtime = 0;
            MarkoDeadtimeSec = 0;
        }

        if (LaraDied == true)
        {
            LaraDeadtime += Time.deltaTime;
            LaraDeadtimeSec = (int)LaraDeadtime;
        }
        if (LaraDeadtimeSec == 10)
        {
            Lara.active = true;
            LaraDied = false;
            LaraLive = true;
            LaraDeadtime = 0;
            LaraDeadtimeSec = 0;
        }
    }
}
