using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class swap : MonoBehaviour
{
    GameObject h;
    GameObject cl;
    GameObject c2;
    GameObject d1;
    private TrackableBehaviour mTrackableBehaviour;
    public Transform myModelPrefab1;
    public Transform myModelPrefab2;
    public Transform myModelPrefab3;

    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("image2");
        cl = GameObject.Find("image1");
        c2 = GameObject.Find("Clll");
        d1 = GameObject.Find("hcllll");

        mTrackableBehaviour = cl.GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            d1.gameObject.SetActive(false);
            mTrackableBehaviour.RegisterTrackableEventHandler(cl.GetComponent<ITrackableEventHandler>());
        }
    }
    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("entered");
     
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours();
        int i = 0;
        
        /*foreach (TrackableBehaviour tb in tbs)
        {
            Debug.Log("TrackableName: " + tb.name);
            Transform child = tb.transform.GetChild(i);
            i++;
            child.gameObject.SetActive(false);
        }
        */
        
        //Create cube object and parent it to trackable gameObject
        Transform myModel1 = GameObject.Instantiate(myModelPrefab1) as Transform;
        myModel1.transform.parent = mTrackableBehaviour.transform;
        myModel1.transform.localPosition = new Vector3(0.6f, -0.2f, 0f);
        myModel1.transform.localRotation = Quaternion.identity;
        myModel1.transform.localScale = new Vector3(200f,200f,200f);
        myModel1.gameObject.SetActive(true);

        Transform myModel2 = GameObject.Instantiate(myModelPrefab2) as Transform;
        myModel2.transform.parent = mTrackableBehaviour.transform;
        myModel2.transform.localPosition = new Vector3(-0.66f, 0f, 0f);
        myModel2.transform.localRotation = Quaternion.identity;
        myModel2.transform.localScale = new Vector3(0.1246257f, 0.1f, 0.08411401f);
        myModel2.gameObject.SetActive(true);
        
        c2.gameObject.SetActive(false);
        h.gameObject.SetActive(false);


    }

    

    private void OnTriggerExit(Collider other)
    {
        
            Debug.Log("exit");
            h.gameObject.SetActive(true);
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours();
    int i = 0;
    foreach (TrackableBehaviour tb in tbs)
    {
        Debug.Log("TrackableName: " + tb.name);
        Transform child = tb.transform.GetChild(i);
        i++;
        child.gameObject.SetActive(false);
    }


    //Create cube object and parent it to trackable gameObject
    Transform myModel1 = GameObject.Instantiate(myModelPrefab1) as Transform;
    myModel1.transform.parent = mTrackableBehaviour.transform;
    myModel1.transform.localPosition = new Vector3(-0.17f, 0f, 0f);
    myModel1.transform.localRotation = Quaternion.identity;
    myModel1.transform.localScale = new Vector3(500f, 500f, 500f);
    myModel1.gameObject.SetActive(true);

}
}
