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
        private Dictionary<string, look> _looks;
        private Dictionary<string, sound> _sounds;
        #endregion

        #region Public properties
        #endregion

        private ReferenceExplorer()
        {
            _looks = new Dictionary<string, look>();
            _sounds = new Dictionary<string, sound>();
        }

        public program LoadReferences(program p)
        {
            foreach (var o in p.objectList)
            {
                for (int i = 0; i < o.lookList.Count(); i++)
                {
                    if (i == 0)
                        _looks["lookList/look"] = o.lookList[i];
                    else
                        _looks[string.Format("lookList/look[{0}]", i + 1)] = o.lookList[i];
                }
                for (int i = 0; i < o.soundList.Count(); i++)
                {
                    if (i == 0)
                        _sounds["soundList/sound"] = o.soundList[i];
                    else
                        _sounds[string.Format("soundList/sound[{0}]", i + 1)] = o.soundList[i];
                }
                // TODO: Solve references for UserVariables
            }

            return p;
        }

    }
}
