namespace Mapbox.Unity.Ar
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Message : MonoBehaviour
    {
        private static Message _instance;
        public static Message Instance { get { return _instance; } }

        [HideInInspector]
        public double latitude;
        [HideInInspector]
        public double longitude;
        [HideInInspector]
        bool gpsInit = false;
        LocationInfo currentGPSPosition;
       
   
        public GameObject messagePrefabAR;
        Camera arCamera;
        List<GameObject> ObjectsList = new List<GameObject>();

        public void LoadAllMessages()
        {
            /*GameObject MessageBubble = Instantiate(messagePrefabAR); //������Ʈ ����
            Message message = MessageBubble.GetComponent<Message>(); // MessageBubble�� ������Ʈ�� �޽��� ��ü�� ��Ʈ�� �� �� �ְ�
            message.latitude = lat; // gps ����
            message.longitude = lon; // ���� 
            ObjectsList.Add(MessageBubble); //������Ʈ ����Ʈ�� ���� ������Ʈ ����
            ARMessageProvider.Instance.LoadARMessages(ObjectsList);*/  
        }
        /*IEnumerator GpsRoutine()
        {
            yield return new WaitForSeconds(15f);
            double lat = ARMessageProvider.Instance.deviceLocation.CurrentLocation.LatitudeLongitude.x;
            double lon = ARMessageProvider.Instance.deviceLocation.CurrentLocation.LatitudeLongitude.y;
            LoadAllMessages(lat, lon);
        }*/
        void Start()
        {
            arCamera = Camera.main;
            GameObject MessageBubble = Instantiate(messagePrefabAR);
            Message message = MessageBubble.GetComponent<Message>();

            //StartCoroutine(GpsRoutine());

            double lat = ARMessageProvider.Instance.deviceLocation.CurrentLocation.LatitudeLongitude.x;
            double lon = ARMessageProvider.Instance.deviceLocation.CurrentLocation.LatitudeLongitude.y;
  
            message.latitude = lat;
            message.longitude = lon;
            //LoadAllMessages(lat, lon);
           
            ARMessageProvider.Instance.LoadARMessages(MessageBubble);
        }

        void Update()
        {
            //make sure the bubble is always facing the camera
            transform.LookAt(Camera.main.transform);
        }
    }
}
