using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class myjsonTesting : MonoBehaviour
{

    public string jsondata;
   // public string 
    public Root mydata;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(JsonUtility.ToJson(mydata));
          mydata = new();
          mydata = JsonUtility.FromJson<Root>(jsondata);

        //   { "userData":[{ "email":"usman@gmail","password":"111111","User_Regen":"rwp","User_School":"new"},{ "email":"ali@gmail","password":"222222","User_Regen":"raw","User_School":"use"},{ "email":"imran@gmail","password":"333333","User_Regen":"sdfsd","User_School":"sdfds"},{ "email":"shoaib@gmail","password":"444444","User_Regen":"sdfsdf","User_School":"gfhjyt"},{ "email":"zunaira@gmail","password":"555555","User_Regen":"sdfefw","User_School":"werewr"}]}

        UserDetail mydet = new UserDetail();
        mydet.email = "usman@gmail";
        mydet.password = "111111";

        for (int i = 0; i < mydata.userData.Count; i++)
        {
            if (mydata.userData[i].email == mydet.email)
            {
                print("DataExists Checking PAssword");
                if (mydata.userData[i].password == mydet.password)
                {
                    print("UserRecord Found ");
                    break;
                }
            }
            else
                print("DataDoes not exist");
        }


    }
 public   void Populatedata()
    {

        Debug.Log(JsonUtility.ToJson(mydata));
    }


    void User_Registration()
    {

    }


}


