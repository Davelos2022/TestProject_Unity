namespace TestProject.General
{
    public class TextMessages
    {
        #region Information Message
        public const string HELLO_MESSAGE = "Hello my friend! Please choose number button";
        public const string ROW_SELECTED_MESSAGE = "Please choose number two button";
        public const string DATA_SUCCESSFULLY = "Data refreshed successfully.";
        #endregion

        #region Error Message
        public const string ERROR_LOAD_DATA = "Failed to refresh data. Please check the logs for more information.";
        public const string ERROR_LOAD_JSON = "JSON file not found in Resources folder fileName:";
        public const string ERROR_NAME_FILE = "The file name is missing or there are invalid characters";
        public const string INVALID_JSON = "Invalid JSON";
        public const string NOT_FIND_VALUE = "The requested range was not found in the currently loaded file";
        #endregion
    }
}