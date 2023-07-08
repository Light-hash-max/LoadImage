namespace LoadImages.Features.ImageLoader
{
    using UnityEngine;
    /// <summary>
    /// �� c id ����������� ��������
    /// </summary>
    [CreateAssetMenu(fileName = "LoadedImageIdSO", menuName = "LoadImages/Features/ImageLoader/Create LoadedImageIdSO")]
    public class LoadedImageIdSO : ScriptableObject
    {
        /// <summary>
        /// id ����������� ��������
        /// </summary>
        public string LoadedImageId
        {
            get => PlayerPrefs.GetString(nameof(LoadedImageIdSO), string.Empty);

            set
            {
                PlayerPrefs.SetString(nameof(LoadedImageIdSO), value);
                PlayerPrefs.Save();
            }
        }
    }
}