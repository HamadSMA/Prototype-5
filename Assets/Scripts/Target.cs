using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float minSpeed = 50;
    private float maxSpeed = 70;
    private float maxTorque = 4;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;
    private AudioSource bombClick;
    private AudioSource fruitClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        bombClick = GameObject.Find("Bomb Click").GetComponent<AudioSource>();
        fruitClick = GameObject.Find("Fruit Click").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                bombClick.Play();
                Destroy(gameObject);
                instantiateParticle();
                gameManager.GameOver();
            }
            else
            {
                fruitClick.Play();
                Destroy(gameObject);
                instantiateParticle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void instantiateParticle()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }


}
