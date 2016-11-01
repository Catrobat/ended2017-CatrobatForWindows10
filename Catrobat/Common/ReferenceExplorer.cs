using Catrobat.Models.v0992;
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
            Dictionary<string, UserVariable> v0 = new Dictionary<string, UserVariable>();
            Dictionary<string, brick> b0 = new Dictionary<string, brick>();
            Dictionary<string, look> l0 = new Dictionary<string, look>();

            for (int y = 0; y < p.objectList.Count(); y++)
            {
                Dictionary<string, look> l1 = new Dictionary<string, look>();
                Dictionary<string, sound> s1 = new Dictionary<string, sound>();
                Dictionary<string, UserVariable> v1 = new Dictionary<string, UserVariable>();
                Dictionary<string, brick> b1 = new Dictionary<string, brick>();

                var o = p.objectList[y];
                for (int i = 0; i < o.lookList.Count(); i++)
                {
                    if (string.IsNullOrEmpty(o.lookList[i].reference))
                    {
                        l0[string.Format("../../../object{0}/lookList/look{1}", F(y), F(i))] = o.lookList[i];
                        l1[string.Format("../../../../../lookList/look{0}", F(i))] = o.lookList[i];
                    }
                    else
                        o.lookList[i] = l0[o.lookList[i].reference];
                }

                for (int i = 0; i < o.soundList.Count(); i++)
                {
                    if (string.IsNullOrEmpty(o.soundList[i].reference))
                        s1[string.Format("../../../../../soundList/sound{0}", F(i))] = o.soundList[i];
                }

                for (int i = 0; i < o.scriptList.Count(); i++)
                {
                    Dictionary<string, UserVariable> v2 = new Dictionary<string, UserVariable>();
                    Dictionary<string, brick> b2 = new Dictionary<string, brick>();
                    var s = o.scriptList[i];
                    for (int j = 0; j < s.brickList.Count(); j++)
                    {
                        var b = s.brickList[j];

                        if (b is VariableBrick)
                        {
                            var v = b as VariableBrick;
                            if (v.userVariable == null)
                            {
                                // A VariableBrick without a variable is useless. 
                            }
                            else if (string.IsNullOrEmpty(v.userVariable.reference))
                            {
                                v0[string.Format("../../../../../../object{0}/scriptList/script{1}/brickList/brick{2}/userVariable",
                                    F(y), F(i), F(j))] = v.userVariable;
                                v1[string.Format("../../../../script{0}/brickList/brick{1}/userVariable",
                                    F(i), F(j))] = v.userVariable;
                                v2[string.Format("../../brick{0}/userVariable",
                                    F(j))] = v.userVariable;
                            }
                            else
                            {
                                if (v2.ContainsKey(v.userVariable.reference))
                                {
                                    v.userVariable = v2[v.userVariable.reference];
                                }
                                else if (v1.ContainsKey(v.userVariable.reference))
                                {
                                    v.userVariable = v1[v.userVariable.reference];
                                }
                                else if (v0.ContainsKey(v.userVariable.reference))
                                {
                                    v.userVariable = v0[v.userVariable.reference];
                                }
                            }
                        }
                        else if (b is SetLookBrick)
                        {
                            var l = b as SetLookBrick;
                            if (!string.IsNullOrEmpty(l.look.reference) && l1.ContainsKey(l.look.reference))
                                l.look = l1[l.look.reference];
                        }
                        else if (b is PlaySoundBrick)
                        {
                            var l = b as PlaySoundBrick;
                            if (!string.IsNullOrEmpty(l.sound.reference) && s1.ContainsKey(l.sound.reference))
                                l.sound = s1[l.sound.reference];
                        }
                        else if (b is brick)
                        {
                            if (string.IsNullOrEmpty(b.reference))
                            {
                                b0[string.Format("../../../../../object{0}/scriptList/script{1}/brickList/brick{2}",
                                    F(y), F(i), F(j))] = b;
                                b1[string.Format("../../../script{0}/brickList/brick{1}",
                                    F(i), F(j))] = b;
                                b2[string.Format("../brick{0}",
                                    F(j))] = b;
                            }
                            else
                            {
                                if (b2.ContainsKey(b.reference))
                                {
                                    s.brickList[j] = b2[b.reference];
                                }
                                else if (b1.ContainsKey(b.reference))
                                {
                                    s.brickList[j] = b1[b.reference];
                                }
                                else if (b0.ContainsKey(b.reference))
                                {
                                    s.brickList[j] = b0[b.reference];
                                }
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
