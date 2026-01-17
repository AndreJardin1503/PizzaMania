using UnityEngine;

public class HandIntensity : MonoBehaviour
{
    [Header("Configuração de Lançamento")]
    public float intensidade = 10f;
    public float velocityMultiplier = 1.5f;
    
    private Rigidbody rb;
    private Vector3 lastHandPosition;
    private Quaternion lastHandRotation;
    private bool isBeingHeld = false;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Enquanto está a ser segurado, guarda a posição/rotação para calcular velocidade
        if (isBeingHeld && rb.isKinematic)
        {
            lastHandPosition = transform.position;
            lastHandRotation = transform.rotation;
        }
    }

    // Chama isto no SELECT event para começar a rastrear
    public void OnGrabbed(GameObject interactor)
    {
        isBeingHeld = true;
        lastHandPosition = transform.position;
        lastHandRotation = transform.rotation;
    }

    // Chama isto no UNSELECT event para atirar
    public void ApplyThrowForce(GameObject interactor)
    {
        if (rb == null) return;

        isBeingHeld = false;
        rb.isKinematic = false;

        // Pega a transform da mão/controller
        Transform handTransform = interactor.transform;

        // Direção para onde a mão está apontada
        Vector3 throwDirection = handTransform.forward;

        // Calcula velocidade linear baseada no movimento recente
        Vector3 handVelocity = (transform.position - lastHandPosition) / Time.fixedDeltaTime;

        // Calcula velocidade angular
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastHandRotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
        Vector3 angularVelocity = axis * (angle * Mathf.Deg2Rad / Time.fixedDeltaTime);

        // Aplica força na direção da mão
        rb.AddForce(throwDirection * intensidade, ForceMode.Impulse);

        // Adiciona a velocidade calculada
        rb.linearVelocity = handVelocity * velocityMultiplier;
        rb.angularVelocity = angularVelocity;

        // Debug
        Debug.Log($"Atirado! Dir: {throwDirection}, Vel: {handVelocity}, Vel Angular: {angularVelocity}");
    }

    // Versão mais simples (só direção e força)
    public void ApplySimpleThrowForce(GameObject interactor)
    {
        if (rb == null) return;

        isBeingHeld = false;
        rb.isKinematic = false;

        Transform handTransform = interactor.transform;
        Vector3 throwDirection = handTransform.forward;

        rb.AddForce(throwDirection * intensidade, ForceMode.Impulse);
        
        Debug.Log($"Atirado (simples)! Direção: {throwDirection}");
    }
}