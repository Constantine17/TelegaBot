using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.SQLite.Entities
{
    public class ClientWithEventsEntity : INotifyPropertyChanged
    {
        private long clientId;
        public long ClientId { get { return clientId; } set { clientId = value; OnPropertyChanged("ClientId"); } }

        private long eventId;
        public long EventId { get { return eventId; } set { eventId = value; OnPropertyChanged("EventId"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
