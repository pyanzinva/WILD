using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WILD.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Record> _records;

        public ObservableCollection<Record> Records
        {
            get { return _records; }
            set
            {
                _records = value;
                OnPropertyChanged("Records");
            }
        }

        public ICommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            Records = new ObservableCollection<Record>
        {
            new Record { Id = 1, ProductType = "Товар 1", Quantity = 10, Supplier = "Поставщик 1", Price = 100 },
            new Record { Id = 2, ProductType = "Товар 2", Quantity = 20, Supplier = "Поставщик 2", Price = 200 }
        };

            DeleteCommand = new RelayCommand(DeleteSelectedRecords);
        }

        private void DeleteSelectedRecords(object obj)
        {
            var selectedRecords = Records.Where(r => r.IsSelected).ToList();
            foreach (var record in selectedRecords)
            {
                Records.Remove(record);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

}
