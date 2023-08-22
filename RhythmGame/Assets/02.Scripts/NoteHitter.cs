using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum HitJudge
{
    None,
    Bad,
    Miss,
    Good,
    Great,
    Cool,
}

public class NoteHitter : MonoBehaviour
{
    public const float HIT_JUDGE_RANCE_COOL = 0.5f;
    public const float HIT_JUDGE_RANCE_GREAT = 1.0f;
    public const float HIT_JUDGE_RANCE_GOOD = 1.8f;
    public const float HIT_JUDGE_RANCE_MISS = 3.0f;


    [SerializeField] private KeyCode _key;
    [SerializeField] private LayerMask _targetMask;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    [SerializeField] private Color _pressedColor;
    [SerializeField] private GameObject _spptLightEffect;
    [SerializeField] private ParticleSystem _hitEffect;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            Hit();
            _spriteRenderer.color = _pressedColor;
            _spptLightEffect.SetActive(true);
            
        }

        if (Input.GetKeyUp(_key))
        {
            _spriteRenderer.color = _originalColor;
            _spptLightEffect.SetActive(false);
        }
    }

    private void Hit()
    {
        HitJudge hitJudge = HitJudge.None;

        Collider2D[] cols =
            Physics2D.OverlapBoxAll(point: transform.position,
                                    size: new Vector2(transform.lossyScale.x / 2.0f,
                                                       HIT_JUDGE_RANCE_MISS),
                                    angle: 0.0f,
                                    layerMask: _targetMask);
        if(cols.Length > 0)
        {
            Transform closestNote =
                cols.OrderBy(x => Mathf.Abs(x.transform.position.y - transform.position.y)).First().transform;

            float distance = Mathf.Abs(closestNote.transform.position.y - transform.position.y);

            if(distance < HIT_JUDGE_RANCE_COOL * 0.05f)
            {

                hitJudge = HitJudge.Cool;
                MusicPlayManager.instance.coolCount++;
                Debug.Log("Cool !!");
            }
            else if (distance < HIT_JUDGE_RANCE_GREAT * 0.05f)
            {
                hitJudge = HitJudge.Great;
                MusicPlayManager.instance.greatCount++;
                Debug.Log("Great !!");
            }
            else if (distance < HIT_JUDGE_RANCE_GOOD * 0.05f)
            {
                hitJudge = HitJudge.Good;
                MusicPlayManager.instance.goodCount++;
                Debug.Log("Good !!");
            }
            else if (distance < HIT_JUDGE_RANCE_MISS * 0.05f)
            {
                hitJudge = HitJudge.Miss;
                MusicPlayManager.instance.missCount++;
                Debug.Log("BAD !!");
            }
            _hitEffect.transform.position = closestNote.transform.position;
            _hitEffect.Play(); 
            Destroy(closestNote.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x * 0.5f,
                                                            HIT_JUDGE_RANCE_MISS,
                                                            0.0f));
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x * 0.5f,
                                                            HIT_JUDGE_RANCE_GOOD,
                                                            0.0f));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x * 0.5f,
                                                            HIT_JUDGE_RANCE_GREAT,
                                                            0.0f));
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.lossyScale.x * 0.5f,
                                                            HIT_JUDGE_RANCE_COOL,
                                                            0.0f));
    }
}
