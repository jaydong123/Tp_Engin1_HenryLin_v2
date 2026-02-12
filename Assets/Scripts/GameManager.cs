using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("References")]
    [SerializeField] private List<GameObject> entityPrefabPool;
    [SerializeField] private GameObject baseGameObject;
    public InputHandler inputHandler;
    private Coroutine coroutine;
    [SerializeField] private Entity testEntity;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }

        //coroutine = SpawnEntity(testEntity);
    }

    private void SpawnEntity(Entity entity)
    {
        Instantiate(entity, baseGameObject.transform.position - Vector3.left * 3f, entity.transform.rotation);
    }
    
    [ContextMenu("Spawn Entity")]
    void SpawnEntity()
    {
        SpawnEntity(testEntity);
    }
}
