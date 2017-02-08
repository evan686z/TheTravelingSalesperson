﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    class Salesperson
    {
        #region FIELDS

        private string _firstName;
        private string _lastName;
        private string _accountId;
        private List<string> _citiesVisited;

        #endregion

        #region PROPERTIES

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        public string AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        public List<string> CitiesVisited
        {
            get { return _citiesVisited; }
            set { _citiesVisited = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Salesperson()
        {
            CitiesVisited = new List<string>();
        }

        #endregion

        #region METHODS




        #endregion
    }
}
