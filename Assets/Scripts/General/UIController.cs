using UnityEngine;

namespace TestProject.General
{
    public enum SelectionState
    {
        None,
        RowSelected,
        BothSelected
    }

    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIView _view;
        [SerializeField] private DataController _dataController;

        private int? _selectedRowIndex;
        private int? _selectedColumnIndex;
        private SelectionState _selectionState = SelectionState.None;

        void Awake()
        {
            Init();
        }

        private void Init()
        {
            RefreshData();
            _view.AddButtonListeners(ChoosValue, RefreshData, ExitApplication);
            _view.SetDisplayText(TextMessages.HELLO_MESSAGE);
        }

        private void ChoosValue(int index)
        {
            switch (_selectionState)
            {
                case SelectionState.None:
                    _selectedRowIndex = index;
                    _selectionState = SelectionState.RowSelected;
                    _view.SetDisplayText(TextMessages.ROW_SELECTED_MESSAGE);
                    break;
                case SelectionState.RowSelected:
                    _selectedColumnIndex = index;
                    _selectionState = SelectionState.BothSelected;
                    ShowValue();
                    break;
            }
        }

        private void ShowValue()
        {
            if (_selectedRowIndex.HasValue && _selectedColumnIndex.HasValue)
            {
                string result = _dataController.Model.Data[_selectedRowIndex.Value, _selectedColumnIndex.Value].ToString();
                _view.SetDisplayText(result);
                ResetSelection();
            }
        }

        private void ResetSelection()
        {
            _selectedRowIndex = null;
            _selectedColumnIndex = null;
            _selectionState = SelectionState.None;
        }

        private void RefreshData()
        {
            ResetSelection();
            _view.SetDisplayText(_dataController.TryLoadData() ? TextMessages.DATA_SUCCESSFULLY : TextMessages.ERROR_LOAD_DATA);
        }

        private void ExitApplication()
        {
            Application.Quit();
        }
    }
}