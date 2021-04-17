using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NCMB;
using Michsky.UI.ModernUIPack;

public class SignUpScript : MonoBehaviour
{
    //　Userインスタンスの生成
    // NCMBUser user = new NCMBUser();

    public TMP_InputField Mail;
    public NotificationManager Notification,Notification_c;
    public NCMBUser user = new NCMBUser();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SignUp()
    {
        NCMBUser.RequestAuthenticationMailAsync(Mail.text, (NCMBException e) =>
        {
            if (e != null)
            {
                Notification.OpenNotification();
            }
            else
            {
                Notification_c.OpenNotification();
            }
        });

    }
}
