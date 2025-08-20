using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform camera;

    private void Awake()
    {
        if(camera==null)
        {
            GameObject cameraFree = GameObject.Find("FreeLook Camera");
            if(cameraFree!=null )
            {
                camera = cameraFree.transform;
            }
        }
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
    }
}
