using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.SQLite.Entities
{
    public class EventEntity : INotifyPropertyChanged
    {
        private long id;
        [Key]
        public long Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string eventName;
        public string EventName { get { return eventName; } set { eventName = value; OnPropertyChanged("EventName"); } }

        public string rigistrationDate;
        public string RigistrationDate { get { return rigistrationDate; } set { rigistrationDate = value; OnPropertyChanged("RigistrationDate"); } }

        public string startDate;
        public string StartDate { get { return startDate; } set { startDate = value; OnPropertyChanged("StartDate"); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
