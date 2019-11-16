using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float CoinDist1;
    bool check1 = false;
    bool check2 = false;
    bool check3 = false;
    bool check4 = false;

    public int coin_production(int time,GameObject Hallo, GameObject Coin1, GameObject Coin2, GameObject Coin3, GameObject Coin4)
    {
        
        //Debug.Log("Coin-Production called");
        int Collectedcoin = 0;
        CoinDist1 = Vector3.Distance(Hallo.transform.position, Coin1.transform.position);
        float CoinDist2 = Vector3.Distance(Hallo.transform.position, Coin2.transform.position);
        float CoinDist3 = Vector3.Distance(Hallo.transform.position, Coin3.transform.position);
        float CoinDist4 = Vector3.Distance(Hallo.transform.position, Coin4.transform.position);
        if (CoinDist1 < 1.42f && check1 == false)
        {
            Coin1.SetActive(false);
            check1 = true;
            ++Collectedcoin;
        }
        if (CoinDist2 < 1.42f && check2 == false)
        {
            Coin2.SetActive(false);
            check2 = true;
            ++Collectedcoin;
        }
        if (CoinDist3 < 1.42f && check3 == false)
        {
            Coin3.SetActive(false);
            check3 = true;
            ++Collectedcoin;
        }
        if (CoinDist4 < 1.42f && check4 == false)
        {
            Coin4.SetActive(false);
            check4 = true;
            ++Collectedcoin;
        }
    
        if (time == 5)
        {
            check1 = false;
            check2 = false;
            check3 = false;
            check4 = false;
            if (Coin1.active == false)
            {
               Coin1.SetActive(true);
            }
            if (Coin2.active == false)
            {
               Coin2.SetActive(true);
            }
            if (Coin3.active == false)
            {
               Coin3.SetActive(true);
            }
            if (Coin4.active == false)
            {
               Coin4.SetActive(true);
            }
        }
        return Collectedcoin;
      }
}
public class FirstAidKit : MonoBehaviour
{
    int healthlevel;
    bool check1 = false;
    bool check2 = false;
    public int AIDKIT(int time, GameObject Hallo, GameObject AidKit1, GameObject AidKit2)
    {
        healthlevel = 0;
        float KITDist1 = Vector3.Distance(Hallo.transform.position, AidKit1.transform.position);
        float KITDist2 = Vector3.Distance(Hallo.transform.position, AidKit2.transform.position);
        if (KITDist1 < 1 && check1 == false)
        {
            AidKit1.SetActive(false);
            check1 = true;
            ++healthlevel;
        }
        if (KITDist2 < 1 && check2 == false)
        {
            AidKit2.SetActive(false);
            check2 = true;
            ++healthlevel;
        }

        if (time == 5)
        {
             check1 = false;
             check2 = false;
            if (AidKit1.active == false)
            {
                AidKit1.SetActive(true);
            }
            if (AidKit2.active == false)
            {
                AidKit2.SetActive(true);
            }

        }
        return healthlevel;
    }
}
