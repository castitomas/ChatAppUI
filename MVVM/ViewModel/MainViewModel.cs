using ChatApp.Core;
using ChatApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.MVVM.ViewModel
{
    internal class MainViewModel:ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */

        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                _selectedContact = value;
                OnPropertyChange();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { 
                _message = value;
                OnPropertyChange();
                }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();    
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Luciano",
                UsernameColor = "#34b3f4",
                ImageSource = "https://i.ytimg.com/vi/RbD_-cQxBK4/maxresdefault.jpg",
                Message = "Let's play Valorant, come on",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true,

            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Luciano",
                    UsernameColor = "#34b3f4",
                    ImageSource = "https://i.ytimg.com/vi/RbD_-cQxBK4/maxresdefault.jpg",
                    Message = "Let's play Valorant, come on",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,

                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Dalia",
                    UsernameColor = "#34b3f4",
                    ImageSource = "https://i.ytimg.com/vi/RbD_-cQxBK4/maxresdefault.jpg",
                    Message = "Hi",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,

                });
            }

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Luciano {i}",
                    ImageSource = "https://i.pinimg.com/originals/94/c9/22/94c92204f2e39178d92707176ac4087d.jpg",
                    Messages = Messages
                });
            }
        }
    }
}
