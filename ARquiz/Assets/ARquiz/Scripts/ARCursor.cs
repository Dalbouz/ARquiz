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
    public GameObject CurrentSpawn;
    private int CurrentActiveID = 0;
    private int NewSelectedID = 0;
    [SerializeField]
    private GameObject _settingsPanel;
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
    }

    private void Update()
    {
        UpdateCursor();
        CreateObject();
    }
    private void CreateObject()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (!_settingsPanel.activeSelf)
            {
                if(CurrentSpawn != null)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == StringConst.GameObjectTag)
                        {
                            Playsound();
                        }
                        else
                        {
                            if (CurrentActiveID == NewSelectedID)
                                return;
                            else
                            {
                                Destroy(CurrentSpawn.gameObject);
                                InitCurrentSpawn();
                                CurrentActiveID = NewSelectedID;
                            }
                        }
                    }
                }
                else
                {
                    InitCurrentSpawn();
                }
            }
        }
    }

    private void InitCurrentSpawn()
    {
        CurrentSpawn = GameObject.Instantiate(objectToPlace[NewSelectedID], transform.position, Quaternion.identity);
    }

    private void Playsound()
    {
        _audioSource.Play();
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

    public void SetObjectID(int NewID)
    {
        NewSelectedID = NewID;
    }
}
