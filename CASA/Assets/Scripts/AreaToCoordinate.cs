using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToCoordinate : MonoBehaviour
{
    [SerializeField] GameObject plasticArea;
    [SerializeField] GameObject paperArea;
    [SerializeField] GameObject canArea;
    [SerializeField] GameObject generalArea;

    public List<float[]> wasteCoordinateList = new List<float[]> ();
    
    private float[] PlasticCoordinateArray = new float[5];
    private float[] PaperCoordinateArray = new float[5];
    private float[] CanCoordinateArray = new float[5];
    private float[] GeneralCoordinateArray = new float[5];
    
    
    private void Awake()
    {
        wasteCoordinateList.Add(PlasticCoordinateArray); 
        wasteCoordinateList.Add(PaperCoordinateArray); 
        wasteCoordinateList.Add(CanCoordinateArray); 
        wasteCoordinateList.Add(GeneralCoordinateArray);
    }
    
    private void Start()
    {
        if(plasticArea != null)
        {
            Collider plasticAreaCollider = plasticArea.GetComponent<Collider>();
            PlasticCoordinateArray[0] = plasticAreaCollider.bounds.min.x;
            PlasticCoordinateArray[1] = plasticAreaCollider.bounds.max.x;
            PlasticCoordinateArray[2] = plasticAreaCollider.bounds.min.z;
            PlasticCoordinateArray[3] = plasticAreaCollider.bounds.max.z;
            PlasticCoordinateArray[4] = plasticAreaCollider.bounds.max.y;
        }

        if(paperArea != null)
        {
            Collider paperAreaCollider = paperArea.GetComponent<Collider>();
            PaperCoordinateArray[0] = paperAreaCollider.bounds.min.x;
            PaperCoordinateArray[1] = paperAreaCollider.bounds.max.x;
            PaperCoordinateArray[2] = paperAreaCollider.bounds.min.z;
            PaperCoordinateArray[3] = paperAreaCollider.bounds.max.z;
            PaperCoordinateArray[4] = paperAreaCollider.bounds.max.y;
        }

        if(canArea != null)
        {
            Collider canAreaCollider = canArea.GetComponent<Collider>();
            CanCoordinateArray[0] = canAreaCollider.bounds.min.x;
            CanCoordinateArray[1] = canAreaCollider.bounds.max.x;
            CanCoordinateArray[2] = canAreaCollider.bounds.min.z;
            CanCoordinateArray[3] = canAreaCollider.bounds.max.z;
            CanCoordinateArray[4] = canAreaCollider.bounds.max.y;
        }

        if(generalArea != null)
        {
            Collider generalAreaCollider = generalArea.GetComponent<Collider>();
            GeneralCoordinateArray[0] = generalAreaCollider.bounds.min.x;
            GeneralCoordinateArray[1] = generalAreaCollider.bounds.max.x;
            GeneralCoordinateArray[2] = generalAreaCollider.bounds.min.z;
            GeneralCoordinateArray[3] = generalAreaCollider.bounds.max.z;
            GeneralCoordinateArray[4] = generalAreaCollider.bounds.max.y;
        }
    }
}
