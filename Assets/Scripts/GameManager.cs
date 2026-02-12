using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("References")]
    [SerializeField] private List<GameObject> entityPrefabPool;
    [SerializeField] private GameObject baseGameObject;
    public InputHandler inputHandler;
    public EntityData entityData;
    private IEnumerator coroutine;
    private int entityCount = 0;
    private int entityCap = 50;
    
    [SerializeField] private Entity testEntity;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
        
        StartCoroutine(nameof(SpawnEntityEndlessly),1f);
    }

    private void SpawnEntity(Entity entity)
    {
        if (entityCount < entityCap)
        {
            Instantiate(entity, baseGameObject.transform.position - Vector3.left * 3f, entity.transform.rotation);
            entityCount++;
        }
    }

    private IEnumerator SpawnEntityEndlessly(float timeInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            SpawnEntity(testEntity);
        }
    }
    
    [ContextMenu("Spawn Entity")]
    void SpawnEntity()
    {
        //Entity e = testEntity;
        SpawnEntity(testEntity);
    }
}
