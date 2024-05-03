namespace TestProject.Data
{
    public class DataModel
    {
        private int[,] _data;
        public int[,] Data => _data;

        public void LoadData(IDataLoader dataLoader, string nameFile)
        {
            _data = dataLoader.LoadData(nameFile);
        }
    }
}