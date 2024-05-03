using UnityEngine;
using TestProject.Data;

namespace TestProject.General
{
    public class DataController : MonoBehaviour
    {
        [SerializeField] private string _nameJsonFile;

        private DataModel _model;
        private IDataLoader _dataLoader;
        private string _optimizeNameFile;

        public DataModel Model => _model;

        void Awake()
        {
            Init();
        }

        private void Init()
        {
            _model = new DataModel();
            _dataLoader = new DataManager();
            _optimizeNameFile = _nameJsonFile.Replace(" ", "");
        }

        public bool TryLoadData()
        {
            _model.LoadData(_dataLoader, _optimizeNameFile);
            return _model.Data != null;
        }
    }
}