using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToCoordinate : MonoBehaviour
{
    BoxCollider plasticAreaCollider;

    [SerializeField] List<GameObject> plasticList = new List<GameObject> ();
    [SerializeField] List<GameObject> PaperList = new List<GameObject> ();
    [SerializeField] List<GameObject> GeneralList = new List<GameObject> ();

    [SerializeField] List<List<float[]>> wasteCoordinateList = new List<List<float[]>> ();
    
    public List<float[]> PlasticCoordinateList = new List<float[]> ();  
    public List<float[]> PaperCoordinateList = new List<float[]> ();
    public List<float[]> GeneralCoordinateList = new List<float[]> ();
    
    
    private void Awake()
    {
        wasteCoordinateList.Add(PlasticCoordinateList);
        wasteCoordinateList.Add(PaperCoordinateList);
        wasteCoordinateList.Add(GeneralCoordinateList);
    }

    private void Start()
    {
        for (int i = 0; i < plasticList.Count; i++)
        {
            GameObject areaObject = plasticList[i];
            Collider area = areaObject.GetComponent<Collider>();
            float[] CoordinateArray = new float[5];
            CoordinateArray[0] = area.bounds.min.x;
            CoordinateArray[1] = area.bounds.max.x;
            CoordinateArray[2] = area.bounds.min.z;
            CoordinateArray[3] = area.bounds.max.z;
            CoordinateArray[4] = area.bounds.max.y;

            PlasticCoordinateList.Add(CoordinateArray);
        }

        for (int i = 0; i < PaperList.Count; i++)
        {
            GameObject areaObject = PaperList[i];
            Collider area = areaObject.GetComponent<Collider>();
            float[] CoordinateArray = new float[5];
            CoordinateArray[0] = area.bounds.min.x;
            CoordinateArray[1] = area.bounds.max.x;
            CoordinateArray[2] = area.bounds.min.z;
            CoordinateArray[3] = area.bounds.max.z;
            CoordinateArray[4] = area.bounds.max.y;

            PaperCoordinateList.Add(CoordinateArray);
        }

        for (int i = 0; i < GeneralList.Count; i++)
        {
            GameObject areaObject = GeneralList[i];
            Collider area = areaObject.GetComponent<Collider>();
            float[] CoordinateArray = new float[5];
            CoordinateArray[0] = area.bounds.min.x;
            CoordinateArray[1] = area.bounds.max.x;
            CoordinateArray[2] = area.bounds.min.z;
            CoordinateArray[3] = area.bounds.max.z;
            CoordinateArray[4] = area.bounds.max.y;

            GeneralCoordinateList.Add(CoordinateArray);
        }
        
    }

    void FixedUpdate()
    {
        
    }
    
}
