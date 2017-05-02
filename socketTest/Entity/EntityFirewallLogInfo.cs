using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace socketTest.Entity
{
    class EntityFirewallLogInfo
    {
        private string _FirewallLog_ID = "000000000000001";
        private DateTime _FirewallLog_Time;
        private string _Source_IPAddress = "";
        private int _Source_Port;
        private string _Destination_IPAddress = "";
        private int _Destination_Port;
        private string _FirewallRule_ID = "";
        private string _NetProtocol_ID = "";
        private string _NetProtocol_Name = "";
        private string _FirewallLogType_ID = "";

        private string _NetFirewall_ID;
        private string _NetFirewall_Name;

        private string _NetFirewall_IPAddress;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string FirewallLog_ID
        {
            get
            {
                return _FirewallLog_ID;
            }

            set
            {
                _FirewallLog_ID = value;
                OnPropertyChanged("FirewallLog_ID");
            }
        }

        public DateTime FirewallLog_Time
        {
            get
            {
                return _FirewallLog_Time;
            }

            set
            {
                _FirewallLog_Time = value;
                OnPropertyChanged("FirewallLog_Time");
            }
        }

        public string Source_IPAddress
        {
            get
            {
                return _Source_IPAddress;
            }

            set
            {
                _Source_IPAddress = value;
                OnPropertyChanged("Source_IPAddress");
            }
        }

        public int Source_Port
        {
            get
            {
                return _Source_Port;
            }

            set
            {
                _Source_Port = value;
                OnPropertyChanged("Source_Port");
            }
        }


        public string Destination_IPAddress
        {
            get
            {
                return _Destination_IPAddress;
            }

            set
            {
                _Destination_IPAddress = value;
                OnPropertyChanged("Destination_IPAddress");
            }
        }

        public int Destination_Port
        {
            get
            {
                return _Destination_Port;
            }

            set
            {
                _Destination_Port = value;
                OnPropertyChanged("Destination_Port");
            }
        }

        public string FirewallRule_ID
        {
            get
            {
                return _FirewallRule_ID;
            }

            set
            {
                _FirewallRule_ID = value;
                OnPropertyChanged("FirewallRule_ID");
            }
        }

        public string NetProtocol_ID
        {
            get
            {
                return _NetProtocol_ID;
            }

            set
            {
                _NetProtocol_ID = value;
                OnPropertyChanged("NetProtocol_ID");
            }
        }

        public string NetProtocol_Name
        {
            get
            {
                return _NetProtocol_Name;
            }

            set
            {
                _NetProtocol_Name = value;
                OnPropertyChanged("NetProtocol_Name");
            }
        }

        public string FirewallLogType_ID
        {
            get
            {
                return _FirewallLogType_ID;
            }

            set
            {
                _FirewallLogType_ID = value;
                OnPropertyChanged("FirewallLogType_ID");
            }
        }

        public string NetFirewall_ID
        {
            get
            {
                return _NetFirewall_ID;
            }

            set
            {
                _NetFirewall_ID = value;
                OnPropertyChanged("NetFirewall_ID");
            }
        }

        public string NetFirewall_Name
        {
            get
            {
                return _NetFirewall_Name;
            }

            set
            {
                _NetFirewall_Name = value;
                OnPropertyChanged("NetFirewall_Name");
            }
        }

        public string NetFirewall_IPAddress
        {
            get
            {
                return _NetFirewall_IPAddress;
            }

            set
            {
                _NetFirewall_IPAddress = value;
                OnPropertyChanged("NetFirewall_IPAddress");
            }
        }
    }
}
