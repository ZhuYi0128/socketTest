using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace socketTest.NetEditEntity
{
    public class EntityNetNodeInfo
    {
        private string _NetNode_ID;
        private string _NetNode_Name;

        private string _NetConnection_ID;

        private string _NetNode_Type_ID;

        private List<EntityNetNodeInfo> _lConnectionNodes;


        public EntityNetNodeInfo()
        {
            _lConnectionNodes = new List<EntityNetNodeInfo>();
        }


        public string NetNode_ID
        {
            get
            {
                return _NetNode_ID;
            }

            set
            {
                _NetNode_ID = value;
            }
        }

        public string NetNode_Name
        {
            get
            {
                return _NetNode_Name;
            }

            set
            {
                _NetNode_Name = value;
            }
        }

        public string NetConnection_ID
        {
            get
            {
                return _NetConnection_ID;
            }

            set
            {
                _NetConnection_ID = value;
            }
        }

        public string NetNode_Type_ID
        {
            get
            {
                return _NetNode_Type_ID;
            }

            set
            {
                _NetNode_Type_ID = value;
            }
        }

        public List<EntityNetNodeInfo> LConnectionNodes
        {
            get
            {
                return _lConnectionNodes;
            }

            set
            {
                _lConnectionNodes = value;
            }
        }

        public int IsOrNotLogin { get; set; }
    }
}
