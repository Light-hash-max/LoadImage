namespace LoadImages.Features.ImageLoader
{
    using UnityEngine;
    /// <summary>
    /// Спаунит заданное количество картинок
    /// </summary>
    public class ImageSpawner : MonoBehaviour
    {
        private const string FORMAT = ".jpg";

        [SerializeField]
        private int _count = 66;
        [SerializeField]
        private string _url = "https://data.ikppbb.com/test-task-unity-data/pics/";
        [SerializeField]
        private Transform _parent = default;
        [SerializeField]
        private LoadedImageGallery _prefab = default;

        private LoadedImageGallery _currentLoadedImage = default;

        private void Start() => Spawn();

        private void Spawn()
        {
            for (int i = 1; i < _count; i++)
            {
                _currentLoadedImage = Instantiate(_prefab, _parent);
                _currentLoadedImage.SetId(_url + i + FORMAT);
            }
        }
    }
}