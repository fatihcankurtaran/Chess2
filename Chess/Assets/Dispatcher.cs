using System.Collections.Generic;
using UnityEngine;


public class Dispatcher : MonoBehaviour
{
    public List<GameObject> ChessmanPrefabs;
    private static List<GameObject> _activeChessman;
    private static Collider _targetCollider;
    private static GameObject _targetPiece;
    private static GameObject ClearTheNode;
    public static int pieceSelection =0;

    // Start is called before the first frame update
    string[] nodes = {"A1","B1","C1","D1","E1","F1","G1","H1","A2","B2","C2","D2","E2","F2","G2","H2","A3","B3","C3",
        "D3","E3","F3","G3","H3","A4","B4","C4","D4","E4","F4","G4","H4","A5","B5","C5","D5","I5","J5","K5","L5","A6","B6",
        "C6","D6","I6","J6","K6","L6","A7","B7","C7","D7","I7","J7","K7","L7","A8","B8","C8","D8","I8","J8","K8","L8",
        "L9","K9","J9","I9","E9","F9","G9","H9","L10","K10","J10","I10","E10","F10","G10","H10","H11","G11","F11","E11","I11",
        "J11","K11","L11","L12","K12","J12","I12","E12","F12","G12","H12"
    };
    void Start()
    {


        Application.targetFrameRate = 30;
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from screen point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Save the info
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            // Find the direction to move in
            //Vector3 dir = hit.point - transform.position;
            // Make it so that its only in x and y axis
            //dir.y = 0; // No vertical movement
            //Debug.Log(hit.transform.name);
            // Debug.Log(pieceSelection.ToString());
            for (int i = 0; i < nodes.Length; i++)
            {
                if ((hit.transform.name == nodes[i]))
                    {
                    //  Debug.Log(nodes[i]);
                    //Position of the mouse
                    //  Debug.Log( hit.point.x.ToString());
                    //   Debug.Log(hit.point.y.ToString());
                    //Name of the collider
                    //Debug.Log(hit.collider.name);
                    //  _targetCollider = hit.collider;
                    
                         if (pieceSelection == 1)
                        {
                            if (hit.collider != null && _targetPiece != null)
                            {
                                _targetPiece.transform.position = new Vector3(hit.collider.transform.position.x,
                                    hit.collider.transform.position.y,
                                    hit.collider.transform.position.z);
                            }
                            pieceSelection = 0;
                            break;
                        }
                       else if (pieceSelection == 0)
                    {
                        foreach (var item in ChessmanPrefabs)
                        {
                            if (item.transform.position == hit.collider.transform.position)
                            {
                                _targetPiece = item;
                                pieceSelection = 1;
                                i = nodes.Length;
                                break;
                            }
                        }

                    }

                   
                        else
                     {
                         pieceSelection = 0;

                     }
                }
            }
        }
        //foreach (var item in ChessmanPrefabs)
        //{
        //    Debug.Log(item.name);
        //}

        }
    }



    public void SetTargetChessman()

    {

       
    }
}

