using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PythonCommunication : MonoBehaviour
{
 /*   public  List<float> vectorObservation;
    private const int NoAction = 0;  // do nothing!
    private const int Up = 1;
    private const int Down = 2;
    private const int Left = 3;
    private const int Right = 4;
    private const int Share = 5;
   // public static GameObject Cube;
    public  GameObject Cube1;
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
    void Update()
    {
        Vector3 position1 = this.transform.position;
        vectorObservation.Add(position1.x);
        vectorObservation.Add(position1.y);
        vectorObservation.Add(position1.z);
        vectorObservation.Add(Cube1.transform.position.x);
        vectorObservation.Add(Cube1.transform.position.y);
        vectorObservation.Add(Cube1.transform.position.z);
        float var1 = position1.x;
        float var2 = position1.y;
        float var3 = position1.z;
        float var4 = Cube1.transform.position.x;
        float var5 = Cube1.transform.position.y;
        float var6 = Cube1.transform.position.z;


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

        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\Users\Ahmad\AppData\Local\Programs\Python\Python36\python.exe";

        // 2) Provide script and arguments
        var script = @"C:\HinaProgramm\ml-agents\gym-unity\gym_unity\envs\EditCode1.py";
        var start = "2019-1-1";
        int end = 5;
        //int end1 = 7;
       
        psi.Arguments = $"\"{script}\" \"{var1}\" \"{var2}\" \"{var3}\" \"{var4}\" \"{var5}\" \"{var6}\"";

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

        // 5) Display output
        Console.WriteLine("ERRORS:");
        Console.WriteLine(errors);
        Console.WriteLine();
        Console.WriteLine("Results:");
        Console.WriteLine(results);
    } */
}

