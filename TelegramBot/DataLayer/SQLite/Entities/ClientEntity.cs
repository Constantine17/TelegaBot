using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.SQLite.Entities
{
    public class ClientEntity : INotifyPropertyChanged
    {

        private long chatId;
        [Key]
        public long ChatId { get { return chatId; } set { chatId = value; OnPropertyChanged("ChatId"); } }

        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; OnPropertyChanged("FirstName"); } }

        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; OnPropertyChanged("LastName"); } }

        private string company;
        public string Company { get { return company; } set { company = value; OnPropertyChanged("Company"); } }

        public string position;
        public string Position { get { return position; } set { position = value; OnPropertyChanged("Position"); } }

        public string memberBefore;
        public string MemberBefore { get { return memberBefore; } set { memberBefore = value; OnPropertyChanged("MemberBefore"); } }

        public string rigistrationDate;
        public string RigistrationDate { get { return rigistrationDate; } set { rigistrationDate = value; OnPropertyChanged("RigistrationDate"); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
