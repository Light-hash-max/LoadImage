namespace LoadImages.Features.LoadSceneManager
{
    using System;
    using System.Collections;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Менеждер сцен.
    /// </summary>
    public class LoadSceneManager : MonoBehaviour
    {
        public static LoadSceneManager Instance { get; private set; } = default;

        /// <summary>
        /// Время загрузки
        /// </summary>
        public float LoadTime { get; private set; } = 2f;

        private const string LOAD_SCENE_NAME = "Loading";

        [SerializeField]
        private string _firstScene = "Menu";

        private Coroutine _loadSceneInOrderCoroutine = null;
        private Coroutine _loadSceneCoroutine = null;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            DontDestroyOnLoad(gameObject);

            InitializeManager();
        }

        private void InitializeManager()
        {
            if (_loadSceneCoroutine != null)
            {
                StopCoroutine(_loadSceneCoroutine);
                _loadSceneCoroutine = null;
            }
            _loadSceneCoroutine = StartCoroutine(LoadScene(_firstScene));
        }

        /// <summary>
        /// Загрузить сцену.
        /// </summary>
        /// <param name="name"></param>
        public void LoadSceneByName(string nameScene)
        {
            if (_loadSceneInOrderCoroutine != null)
            {
                StopCoroutine(_loadSceneInOrderCoroutine);
                _loadSceneInOrderCoroutine = null;
            }
            _loadSceneInOrderCoroutine = StartCoroutine(LoadScenesInOrder(nameScene));
        }

        private IEnumerator LoadScenesInOrder(string nameScene)
        {
            yield return SceneManager.LoadSceneAsync(LOAD_SCENE_NAME);

            if (_loadSceneCoroutine != null)
            {
                StopCoroutine(_loadSceneCoroutine);
                _loadSceneCoroutine = null;
            }
            yield return _loadSceneCoroutine = StartCoroutine(LoadScene(nameScene));

            _loadSceneInOrderCoroutine = null;
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return new WaitForSecondsRealtime(LoadTime);

            var asyncScene = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncScene.isDone)
            {
                yield return null;
            }

            _loadSceneCoroutine = null;
        }
    }
}