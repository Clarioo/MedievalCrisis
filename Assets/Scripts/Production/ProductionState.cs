using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionState : MonoBehaviour
{
    
    [SerializeField] List<ResourcesProductor> productorsList;

    public List<ResourcesProductor> GetResourcesProductors()
    {
        return productorsList;
    }
}
