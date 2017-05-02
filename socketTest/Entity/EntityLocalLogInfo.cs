using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace socketTest.Entity
{
    class EntityLocalLogInfo
    {
        private string _LocalLog_ID = "0000000001";
        private DateTime _LocalLog_Time;
        private string _LocalLog_UserID = "";
        private string _LocalLog_UserName = "";
        private string _LocalLog_ExecOperation = "";
        private string _LocalLog_ExecResult = "";
        private string _LocalLog_Description = "";


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onpropertychanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string LocalLog_ID
        {
            get
            {
                return _LocalLog_ID;
            }

            set
            {
                _LocalLog_ID = value;
                onpropertychanged("LocalLog_ID");
            }
        }

        public DateTime LocalLog_Time
        {
            get
            {
                return _LocalLog_Time;
            }

            set
            {
                _LocalLog_Time = value;
                onpropertychanged("LocalLog_Time");
            }
        }

        public string LocalLog_UserID
        {
            get
            {
                return _LocalLog_UserID;
            }

            set
            {
                _LocalLog_UserID = value;
                onpropertychanged("LocalLog_UserID");
            }
        }

        public string LocalLog_UserName
        {
            get
            {
                return _LocalLog_UserName;
            }

            set
            {
                _LocalLog_UserName = value;
                onpropertychanged("LocalLog_UserName");
            }
        }

        public string LocalLog_ExecOperation
        {
            get
            {
                return _LocalLog_ExecOperation;
            }

            set
            {
                _LocalLog_ExecOperation = value;
                onpropertychanged("LocalLog_ExecOperation");
            }
        }

        public string LocalLog_ExecResult
        {
            get
            {
                return _LocalLog_ExecResult;
            }

            set
            {
                _LocalLog_ExecResult = value;
                onpropertychanged("LocalLog_ExecResult");
            }
        }

        public string LocalLog_Description
        {
            get
            {
                return _LocalLog_Description;
            }

            set
            {
                _LocalLog_Description = value;
                onpropertychanged("LocalLog_Description");
            }
        }
    }
}
