using UnityEngine;

namespace Source.Data
{
    [CreateAssetMenu(fileName = "ExtractConfig", menuName = Constants.ProjectName + "/Extract Config")]
    public class ExtractConfig : ScriptableObject, IExtractConfig
    {
        [Range(1, 3)] 
        [SerializeField] private float _duractiom = 1;

        public float Duractiom => _duractiom;
    }
}