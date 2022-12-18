using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    private static ARCursor _instance;
    public static ARCursor Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject cursorChildObject;
    public ARRaycastManager raycastManager;
    public int ObjectToPlaceID = 0;
    [SerializeField]
    private GameObject _settingsPanel;
    public bool useCursor = true;
    public int PickAnObjMsgDelay = 1;
    private AudioSource _audioSource;
    public List<GameObject> objectToPlace;
    


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        cursorChildObject.SetActive(useCursor);
    }

    private void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }
        CreateOrInteractObject();
    }
    private void CreateOrInteractObject()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (useCursor)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (!_settingsPanel.activeSelf)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "ARObject")
                        {
                            _audioSource.Play();
                        }
                        else
                        {
                            GameObject.Instantiate(objectToPlace[ObjectToPlaceID], transform.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
