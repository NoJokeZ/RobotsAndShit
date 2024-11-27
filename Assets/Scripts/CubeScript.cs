using TMPro.EditorUtilities;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Color cubeColor;
    private Renderer cubeRenderer;
    bool partyModeActive = false;
    public float ChangeColorSpeed = 0.1f;

    float horizontal;
    float vertical;

    public float turnspeed = 1f;

    private void Awake()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            partyModeActive = !partyModeActive;
        }

        if(partyModeActive)
        {
            PartyMode();
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        transform.Rotate(new Vector3(vertical * turnspeed,horizontal * turnspeed, 0));

    }

    void ChangeColor()
    {
        float redVal = Random.Range(0.0f, 1.0f);
        float greenVal = Random.Range(0.0f, 1.0f);
        float blueVal = Random.Range(0.0f, 1.0f);

        Color randomColor = new Color(redVal, greenVal, blueVal);

        cubeRenderer.material.color = randomColor;
    }

    void PartyMode()
    {
        Color PartyColor;

        PartyColor = Color.HSVToRGB(Mathf.PingPong(Time.time * ChangeColorSpeed, 1f), 1, 1);

        cubeRenderer.material.color = PartyColor;

    }

    void Rotate()
    {
        
    }
}
