using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList {

    private Action action;
    public static List<Action> actionlist = new List<Action>();

    public List<Action> Actionlist
    {
        get
        {
            return actionlist;
        }

        set
        {
            actionlist = value;
        }
    }

    public List<Action> AddActions(string name,float dopamin, float oxetocin)
    {
        Action a = new Action();
        a.Name = name;
        a.Dopamin = dopamin;
        a.Oxetocin = oxetocin;
        Actionlist.Add(a);
        return Actionlist;

    }
}
