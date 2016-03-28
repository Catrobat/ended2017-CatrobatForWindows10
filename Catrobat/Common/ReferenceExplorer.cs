using Catrobat.Models.v098;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catrobat.Common
{
    class ReferenceExplorer
    {
        #region Private fields
        private static ReferenceExplorer _instance = null;
        private Dictionary<program, List<look>> _dictLook = null;
        private Dictionary<program, List<sound>> _dictSound = null;
        private Dictionary<program, List<UserVariable>> _dictUserVariable = null;
        private volatile program _currentProgram = null;
        #endregion

        #region Public properties
        public static ReferenceExplorer Instance
        {
            get
            {
                return _instance = _instance == null ? new ReferenceExplorer() : _instance;
            }
        }

        public List<look> Looks { get { return _dictLook[_currentProgram]; } }

        public List<sound> Sounds { get { return _dictSound[_currentProgram]; } }

        public List<UserVariable> UserVariables { get { return _dictUserVariable[_currentProgram]; } }

        #endregion

        private ReferenceExplorer()
        {
            _dictLook = new Dictionary<program, List<look>>();
            _dictSound = new Dictionary<program, List<sound>>();
            _dictUserVariable = new Dictionary<program, List<UserVariable>>();
        }

        public void SetProgram(program p)
        {
            _currentProgram = p;
            if (!_dictLook.ContainsKey(p))
            {
                _dictLook.Add(p, new List<look>());
            }
            if (!_dictSound.ContainsKey(p))
            {
                _dictSound.Add(p, new List<sound>());
            }
            if (!_dictUserVariable.ContainsKey(p))
            {
                _dictUserVariable.Add(p, new List<UserVariable>());
            }
        }

    }
}
