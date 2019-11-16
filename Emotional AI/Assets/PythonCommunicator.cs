using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
public class PythonCommunicator : MonoBehaviour
{
  /*  // Start is called before the first frame update
    //public MarkoScript Marko;
    //public AgentMove Hallo;
    //public Lara Lara;
    private const int Idle = 0;  // do nothing!
    private const int Left = 1;
    private const int Up = 2;
    private const int Down = 3;
    private const int Right = 4;
    private const int Eat = 5;
    private const int Share = 6;
    private const int Attack = 7;
    public List<float> vectorObservation;
    public int AgentAction;
  
    // public static GameObject Cube;
    // public GameObject Cube1;

    // Start is called before the first frame update
    /* static void Main(string[] args)
     {
         Console.WriteLine("Execute python process...");
         Update();


     }
    void Start()
    {


    }


    // Update is called once per frame
    public void  Communication(int Agentid , GameObject Laraobj, GameObject Markoobj, GameObject Halloobj, MarkoScript Marko , AgentMove Hallo , Lara Lara , float Dopmainlevel , float DopmaninForAgent1 , float DopmaninForAgent2)
    {
        UnityEngine.Debug.Log("Pyhton Communication");
        float Laraposx = Laraobj.transform.position.x;
        float Laraposy = Laraobj.transform.position.y;
        float Laraposz = Laraobj.transform.position.z;
        float Markoposx = Markoobj.transform.position.x;
        float Markoposy = Markoobj.transform.position.y;
        float Markoposz = Markoobj.transform.position.z;
        float Halloposx = Halloobj.transform.position.x;
        float Halloposy = Halloobj.transform.position.y;
        float Halloposz = Halloobj.transform.position.z; 
        float Larafood = Lara.Food;
        float MarkoFood = Marko.Food;
        float HalloFood = Hallo.Food;
        float LaraHealth = Lara.Health;
        float MarkoHealth = Marko.Health;
        float HalloHealth = Hallo.Health;
        //float LaraDop = Lara.Dopamin;
        //float MarkoDop = Marko.Dopamin;
        //float HalloDop = Hallo.Dopamin;
        //float LaraOxetocinForHallo = Lara.OxetocinForHallo;
        //float LaraOxetocinForMarko = Lara.OxetocinForMarko;
        //float MarkoOxetocinForLara = Marko.OxetocinForLara;
        //float MarkoOxetocinForHallo = Marko.OxetocinForHallo;
        //float HalloOxetocinForLara = Hallo.OxetocinForLara;
        //float HalloOxetociForMarko = Hallo.OxetocinForMarko;
        //Vector3 targetPos = this.transform.position; 

        //vectorObservation.Add(Target.position.x);
        //vectorObservation.Add(Target.position.y);
        //vectorObservation.Add(Target.position.z);
        //vectorObservation.Add(Needy.position.x);
        //vectorObservation.Add(Needy.position.y);
        //vectorObservation.Add(Needy.position.z);
        //vectorObservation.Add(Selfish.position.x);
        //vectorObservation.Add(Selfish.position.y);
        //vectorObservation.Add(Selfish.position.z);
        //// Agent velocity
        //vectorObservation.Add(rBody.velocity.x);
        //vectorObservation.Add(rBody.velocity.y);
        //vectorObservation.Add(rBody.velocity.z);

        //switch (action)
        //{
        //    case NoAction:

        //        break;
        //    case Right:
        //        targetPos = transform.position + new Vector3(1f, 0, 0f);
        //        break;
        //    case Left:
        //        targetPos = transform.position + new Vector3(-1f, 0, 0f);
        //        break;
        //    case Up:
        //        targetPos = transform.position + new Vector3(0f, 0, 1f);
        //        break;
        //    case Down:
        //        targetPos = transform.position + new Vector3(0f, 0, -1f);

        //        break;

        //    default:
        //        throw new ArgumentException("Invalid action value");
        bool openfile = false;
        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\HinaProgramm\ml-agents\venv\Scripts\python.exe";

        // 2) Provide script and arguments
        var script = @"C:\HinaProgramm\ml-agents\gym_unity\envs\TestDQNMethod.py";
        // Vector observations
        var vectorobserno = 18;
        var actionno = 8;
        //int end1 = 7;

        //psi.Arguments = $"\"{script}\" \"{var1}\" \"{var2}\" \"{var3}\" \"{var4}\" \"{var5}\" \"{var6}\"";
        psi.Arguments = $"\"{script}\" \"{vectorobserno}\" \"{actionno}\"  \"{Agentid}\" \"{Laraposx}\" \"{Laraposy}\" \"{Laraposz}\" \"{Markoposx}\" \"{Markoposy}\" \"{Markoposz}\"  \"{Halloposx}\" \"{Halloposy}\" \"{Halloposz}\" \"{Larafood}\" \"{MarkoFood}\" \"{HalloFood}\" \"{LaraHealth}\" \"{MarkoHealth }\" \"{HalloHealth}\" \"{Dopmainlevel}\"  \"{DopmaninForAgent1}\" \"{DopmaninForAgent2}\"";

        // 3) Process configuration
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        // 4) Execute process and get output
        var errors = "";
        var results = "";
        using (var process = Process.Start(psi))
        {
            
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();
            openfile = true;


        }

      
        int myInt;
        if (openfile == true)
        {
            var array = results.ToCharArray().Where(x =>
            int.TryParse(x.ToString(), out myInt)).Select(x =>
            int.Parse(x.ToString())).ToArray();

            //result1 = Int32.Parse(results);
            // 5) Display output
            AgentAction = array[0];
        }
        if (agent1act == 1)
        {
            targetPos = this.transform.position + new Vector3(1f, 0, 0f);
        }
        else if (agent1act == 2)
        {
            targetPos = this.transform.position + new Vector3(-1f, 0, 0f);
        }
        else if (agent1act == 3)
        {
            targetPos = this.transform.position + new Vector3(0f, 0, 1f);
        }
        else if (agent1act == 4)
        {
            targetPos = this.transform.position + new Vector3(0f, 0, -1f);
        }
        else
        {
            targetPos = this.transform.position;
        }
       

        Console.WriteLine("ERRORS:");
        Console.WriteLine(errors);
        Console.WriteLine();
        Console.WriteLine("Results:");
        Console.WriteLine(results);
    }
    public void nextState(int id , GameObject Laraobj, GameObject Markoobj, GameObject Halloobj, MarkoScript Marko, AgentMove Hallo, Lara Lara, float Dopmainlevel, float DopmaninForAgent1, float DopmaninForAgent2 , float Reward)
    {
        var psi = new ProcessStartInfo();
        float Laraposx = Laraobj.transform.position.x;
        float Laraposy = Laraobj.transform.position.y;
        float Laraposz = Laraobj.transform.position.z;
        float Markoposx = Markoobj.transform.position.x;
        float Markoposy = Markoobj.transform.position.y;
        float Markoposz = Markoobj.transform.position.z;
        float Halloposx = Halloobj.transform.position.x;
        float Halloposy = Halloobj.transform.position.y;
        float Halloposz = Halloobj.transform.position.z;
        float Larafood = Lara.Food;
        float MarkoFood = Marko.Food;
        float HalloFood = Hallo.Food;
        float LaraHealth = Lara.Health;
        float MarkoHealth = Marko.Health;
        float HalloHealth = Hallo.Health;
        //float LaraDop = Lara.Dopamin;
        //float MarkoDop = Marko.Dopamin;
        //float HalloDop = Hallo.Dopamin;
        //float LaraOxetocinForHallo = Lara.OxetocinForHallo;
        //float LaraOxetocinForMarko = Lara.OxetocinForMarko;
        //float MarkoOxetocinForLara = Marko.OxetocinForLara;
        //float MarkoOxetocinForHallo = Marko.OxetocinForHallo;
        //float HalloOxetocinForLara = Hallo.OxetocinForLara;
        //float HalloOxetociForMarko = Hallo.OxetocinForMarko;
      
        psi.FileName = @"C:\HinaProgramm\ml-agents\venv\Scripts\python.exe";

        // 2) Provide script and arguments
        var script = @"C:\HinaProgramm\ml-agents\gym_unity\envs\NextState.py";
        psi.Arguments = $"\"{script}\" \"{id}\"  \"{Laraposx}\" \"{Laraposy}\" \"{Laraposz}\" \"{Markoposx}\" \"{Markoposy}\" \"{Markoposz}\"  \"{Halloposx}\" \"{Halloposy}\" \"{Halloposz}\" \"{Larafood}\" \"{MarkoFood}\" \"{HalloFood}\" \"{LaraHealth}\" \"{MarkoHealth }\" \"{HalloHealth}\" \"{Dopmainlevel}\"  \"{DopmaninForAgent1}\" \"{DopmaninForAgent2}\" \"{Reward}\" ";
        // 3) Process configuration
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        // 4) Execute process and get output
        var errors = "";
        var results = "";
        using (var process = Process.Start(psi))
        {
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();


        }

    }*/

}
