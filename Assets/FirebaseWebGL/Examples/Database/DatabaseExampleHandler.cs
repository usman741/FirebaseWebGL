using System;
using System.Collections.Generic;
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using TMPro;
using UnityEngine;

namespace FirebaseWebGL.Examples.Database
{
    public class DatabaseExampleHandler : MonoBehaviour
    {
        public TMP_InputField pathInputField;
        public TMP_InputField valueInputField;
        public string JsonValue;
        public TMP_InputField amountInputField;

        public TextMeshProUGUI outputText;

        private void Start()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
                DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
        }



        // GetData login
        public void GetJSON() =>
            FirebaseDatabase.GetJSON("UserData", gameObject.name, "DisplayData", "DisplayErrorObject");

//        public void PostJSON() => FirebaseDatabase.PostJSON(pathInputField.text, valueInputField.text, gameObject.name,
  //          "DisplayInfo", "DisplayErrorObject");

        public void PostJSON() => FirebaseDatabase.PostJSON(pathInputField.text, JsonValue, gameObject.name,
          "DisplayInfo", "DisplayErrorObject");
        public void PushJSON() => FirebaseDatabase.PushJSON(pathInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");

        public void UpdateJSON() => FirebaseDatabase.UpdateJSON(pathInputField.text, valueInputField.text,
            gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void DeleteJSON() =>
            FirebaseDatabase.DeleteJSON(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForValueChanged() =>
            FirebaseDatabase.ListenForValueChanged(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForValueChanged() => FirebaseDatabase.StopListeningForValueChanged(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForChildAdded() =>
            FirebaseDatabase.ListenForChildAdded(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForChildAdded() => FirebaseDatabase.StopListeningForChildAdded(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForChildChanged() =>
            FirebaseDatabase.ListenForChildChanged(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForChildChanged() => FirebaseDatabase.StopListeningForChildChanged(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForChildRemoved() =>
            FirebaseDatabase.ListenForChildRemoved(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForChildRemoved() => FirebaseDatabase.StopListeningForChildRemoved(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ModifyNumberWithTransaction()
        {
            float.TryParse(amountInputField.text, out var amount);
            FirebaseDatabase.ModifyNumberWithTransaction(pathInputField.text, amount, gameObject.name, "DisplayInfo",
                "DisplayErrorObject");
        }

        public void ToggleBooleanWithTransaction() =>
            FirebaseDatabase.ToggleBooleanWithTransaction(pathInputField.text, gameObject.name, "DisplayInfo",
                "DisplayErrorObject");



        #region Login
        public void LoginUser()
        {
            GetJSON();
        }


        public TMP_InputField userNameInputfield;
        public TMP_InputField passwordInputfield;
        
        public void DisplayData(string data)
        {
            outputText.color = outputText.color == Color.green ? Color.blue : Color.green;
            outputText.text = data;
            
            Debug.Log(data);
            Root getData = new();
            getData = JsonUtility.FromJson<Root>(data);
            Debug.Log(getData.userData.Count + " UserData entries ");

            //Check USerName And PasswordData
            UserDetail mydet = new UserDetail();
          

            for (int i = 0; i < getData.userData.Count; i++)
            {
                if (getData.userData[i].email == userNameInputfield.text)
                {
                    print("DataExists Checking PAssword");
                    if (getData.userData[i].password == passwordInputfield.text)
                    {
                        print("UserRecord Found ");
                        outputText.text = "You are Successfully Logged in ";
                        break;
                    }
                }
                else
                    print("DataDoes not exist Please Register Your Self");
            }

        }

        #endregion

        #region USerRegister
       public void RegisterUser()
        {

        }

        #endregion


        public void DisplayInfo(string info)
        {
            outputText.color = Color.white;
            outputText.text = info;
            Debug.Log(info);

        }

        public void DisplayErrorObject(string error)
        {
            var parsedError = StringSerializationAPI.Deserialize(typeof(FirebaseError), error) as FirebaseError;
            DisplayError(parsedError.message);
        }

        public void DisplayError(string error)
        {
            outputText.color = Color.red;
            outputText.text = error;
            Debug.LogError(error);
        }


       
    

    }



}
[Serializable]
public class Root
{
    public List<UserDetail> userData = new List<UserDetail>();
}
[Serializable]
public class UserDetail
{
    public string email;
    public string password;
    public string User_Regen;
    public string User_School;
}