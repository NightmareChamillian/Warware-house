using UnityEngine;

public class MouseInputs : MonoBehaviour, IOnMouseDown
{

    public int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown() { //uses an Interface, has to be detailed by manager?
        if (counter == 0)
        {

            counter = 1;
        }
        else
        {

            counter = 0;
        }
    }
    

}
