using System.Runtime.Serialization;
using UnityEngine;

public enum InteractObject
{
    Key,
    Ammo,
    Heal,
    Lock
}
public class InteractRange : MonoBehaviour
{
    [SerializeField] private float rangeInteract;
    [SerializeField] private Transform playerPosition;
    [SerializeField] protected InteractObject interactObject;
    [SerializeField] private NoticeList noticeList;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemySpawn enemySpawn;

    public ManualShooting manual;
    public AutomaticShooting automatic;
    
    private bool isPanelActive = false;


    void Start()
    {
        if (playerPosition == null)
        {
            GameObject player = GameObject.Find("Space_Solider");
            if (player != null)
            {
                playerPosition = player.transform;
                playerData = player.GetComponent<PlayerData>();
                
            }
            
        }
        if(noticeList == null)
        {
            noticeList = GameObject.Find("NoticePanel").GetComponent<NoticeList>();
        }
        if(enemySpawn == null)
        {
            GameObject spawner = GameObject.Find("Enemy Spawn");
            if (spawner != null)
            {
                enemySpawn = spawner.GetComponent<EnemySpawn>();
                enemySpawn.enabled = false;
            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition == null) return;

        float distance = Vector3.Distance(transform.position, playerPosition.position);
        if (distance <= rangeInteract)
        {
            Debug.Log("Player in range to interact");
            //Call notice
            if (interactObject == InteractObject.Key)
            {
                if (!isPanelActive)
                {
                    DisplayPanel();
                    isPanelActive = true;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    playerData.ObtainKey();
                    AudioManager.Instance.OnPickUP();
                    noticeList.AfterInteract(interactObject);
                    Destroy(gameObject);
                }

            }
            else if (interactObject == InteractObject.Lock)
            {
                if (!isPanelActive)
                {
                    DisplayPanel();
                    isPanelActive = true;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    if (playerData.hasKey)
                    {

                        enemySpawn.enabled = true;
                        noticeList.AfterInteract(interactObject);
                        GameObject door = GameObject.Find("LockDoor");
                        door.SetActive(false);
                        AudioManager.Instance.OnUnlock();
                        AudioManager.Instance.PlayBossMussic();

                    }
                    else
                    {
                        noticeList.DontHaveKey();
                    }
                }
            }
            if (interactObject == InteractObject.Ammo)
            {
                if (!isPanelActive)
                {
                    DisplayPanel();
                    isPanelActive = true;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    manual.ReloadAmmo();
                    automatic.ReloadAmmo();
                    AudioManager.Instance.OnPickUP();
                    noticeList.AfterInteract(interactObject);
                    Destroy(gameObject);
                    
                }

            }
            if (interactObject == InteractObject.Heal)
            {
                if (!isPanelActive)
                {
                    DisplayPanel();
                    isPanelActive = true;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    playerData.HealRecover();
                    AudioManager.Instance.OnHeal();
                    noticeList.AfterInteract(interactObject);
                    Destroy(gameObject);
                }

            }
        }
        else
        {
            if (isPanelActive)
            {
                HidePanel();
                isPanelActive = false;
            }
        }
        
    }
    public void DisplayPanel()
    {
        noticeList.gameObject.SetActive(true);
        noticeList.ShowNotice(interactObject);
    }
    public void HidePanel()
    {
        noticeList.gameObject.SetActive(false);
    }
   
}
