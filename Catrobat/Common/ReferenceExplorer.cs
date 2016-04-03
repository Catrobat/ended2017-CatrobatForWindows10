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
        #endregion

        #region Public properties
        #endregion

        private ReferenceExplorer()
        {
        }

        /// <summary>
        /// The reference concept in the xml is pretty stupid, so we need 
        /// this method to resolve the references.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static program LoadReferences(program p)
        {
            Dictionary<string, look> l0 = new Dictionary<string, look>();
            Dictionary<string, sound> s0 = new Dictionary<string, sound>();
            Dictionary<string, UserVariable> v0 = new Dictionary<string, UserVariable>();

            for (int y = 0; y < p.objectList.Count(); y++)
            {
                var o = p.objectList[y];
                for (int i = 0; i < o.lookList.Count(); i++)
                {
                    l0[string.Format("../../../../../lookList/look{0}", F(i))] = o.lookList[i];
                }

                for (int i = 0; i < o.soundList.Count(); i++)
                {
                    s0[string.Format("../../../../../soundList/sound{0}", F(i))] = o.soundList[i];
                }

                for (int i = 0; i < o.scriptList.Count(); i++)
                {
                    var s = o.scriptList[i];
                    Dictionary<string, UserVariable> v1 = new Dictionary<string, UserVariable>();
                    for (int j = 0; j < s.brickList.Count(); j++)
                    {
                        var b = s.brickList[j];
                        Dictionary<string, UserVariable> v2 = new Dictionary<string, UserVariable>();
                        if (b is VariableBrick)
                        {
                            var v = b as VariableBrick;
                            if (string.IsNullOrEmpty(v.userVariable.reference))
                            {
                                v0[string.Format("../../../../../../object{0}/scriptList/script{1}/brickList/brick{0}/userVariable",
                                    F(y), F(i), F(j))] = v.userVariable;
                                v1[string.Format("../../../../script{0}/brickList/brick{1}/userVariable",
                                    F(i), F(j))] = v.userVariable;
                                v2[string.Format("../../brick{0}/userVariable",
                                    F(j))] = v.userVariable;
                            }
                            else
                            {
                                // TODO: Solve references for UserVariables
                                // TODO: Read variables
                            }
                        }
                    }
                }
            }

            return p;
        }

        static private string F(int i)
        {
            return i == 0 ? string.Empty : string.Format("[{0}]", i + 1);
        }

    }
}
