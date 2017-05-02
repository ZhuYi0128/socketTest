using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace socketTest.NetEditEntity
{
    public class EntityNetFirewallInfo:EntityNetNodeInfo
    {
        private string _NetFirewall_ID;
        private string _NetFirewall_Name;

        private string _NetFirewallDevice_ID;

        private string _IPAddress;
        private string _IPAddressSubnetMask;
        private string _DefaultGateway;
        private string _NetFirewall_DESC;

        private string _ConnectionState;
        private string _NetFirewallRunMode;
        private int _IsOrNotLogin;

        private SocketCommunicate.comExecSocket _ExecSocketCommunicate;

        public EntityNetFirewallInfo()
        {
            _ExecSocketCommunicate = new SocketCommunicate.comExecSocket();
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
            }
        }

        public string NetFirewallDevice_ID
        {
            get
            {
                return _NetFirewallDevice_ID;
            }

            set
            {
                _NetFirewallDevice_ID = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }

            set
            {
                _IPAddress = value;
            }
        }

        public string IPAddressSubnetMask
        {
            get
            {
                return _IPAddressSubnetMask;
            }

            set
            {
                _IPAddressSubnetMask = value;
            }
        }

        public string DefaultGateway
        {
            get
            {
                return _DefaultGateway;
            }

            set
            {
                _DefaultGateway = value;
            }
        }

        public string NetFirewall_DESC
        {
            get
            {
                return _NetFirewall_DESC;
            }

            set
            {
                _NetFirewall_DESC = value;
            }
        }

        public string ConnectionState
        {
            get
            {
                return _ConnectionState;
            }

            set
            {
                _ConnectionState = value;
            }
        }

        public string NetFirewallRunMode
        {
            get
            {
                return _NetFirewallRunMode;
            }

            set
            {
                _NetFirewallRunMode = value;
            }
        }

        public int IsOrNotLogin
        {
            get
            {
                return _IsOrNotLogin; ;
            }

            set
            {
                _IsOrNotLogin = value;
            }
        }

        public SocketCommunicate.comExecSocket ExecSocketCommunicate
        {
            get
            {
                return _ExecSocketCommunicate;
            }

            set
            {
                _ExecSocketCommunicate = value;
            }
        }



    }
}
