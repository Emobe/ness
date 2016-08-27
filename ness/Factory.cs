using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Ness
{
    public class Factory
    {
        protected static ConstructorInfo getConstructor(Type type, object[] parameters)
        {
            ConstructorInfo[] constructors = type.GetConstructors();

            List<ConstructorInfo> matches = new List<ConstructorInfo>();

            for(int i = 0; i < constructors.Length; i++)
            {
                if(constructors[i].GetParameters().Length == parameters.Length)
                {
                    matches.Add(constructors[i]);
                }
            }

            ConstructorInfo best = constructors[0];

            if(matches.Count > 0)
            {
                int bestIndex = -1, bestMatches = -1;

                for(int i = 0; i < matches.Count; i++)
                {
                    ParameterInfo[] pi = matches[i].GetParameters();

                    int n = 0;

                    for(int j = 0; j < pi.Length; j++)
                    {
                        if (pi[j].ParameterType.Equals(parameters[j].GetType()))
                        {
                            n++;
                        }
                    }

                    if(n > bestMatches)
                    {
                        bestMatches = n;
                        bestIndex = i;
                    }
                }

                best = matches[bestIndex];
            }
            return best;
        }
    }
}
