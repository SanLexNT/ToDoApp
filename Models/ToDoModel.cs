using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    internal class ToDoModel : INotifyPropertyChanged
    {
        private bool isDone;
        private string text;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public bool IsDone
        {
            get { return isDone; }
            set 
            {
                if (isDone == value)
                    return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string Text
        {
            get { return text; }
            set 
            {
                if (text == value)
                    return;
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
