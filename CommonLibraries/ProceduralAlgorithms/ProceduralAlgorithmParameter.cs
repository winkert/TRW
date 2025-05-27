using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public abstract class ProceduralAlgorithmParameter : IComparable<ProceduralAlgorithmParameter>
    {
        public bool Required { get; set; }
        public abstract Type ParameterType { get; }
        public string ParameterName { get; protected set; }
        protected internal int ParameterIndex { get; set; }
        public abstract int CompareTo(ProceduralAlgorithmParameter other);
    }
    public class ProceduralAlgorithmParameter<T> : ProceduralAlgorithmParameter
    {
        public T DefaultValue { get; set; }

        public override Type ParameterType => typeof(T);

        public ProceduralAlgorithmParameter(string name) : this(true, default, name)
        { }

        public ProceduralAlgorithmParameter() : this(true, default)
        { }

        public ProceduralAlgorithmParameter(bool required, T defaultValue, string parameterName = "Default")
        {
            Required = required;
            DefaultValue = defaultValue;
            ParameterName = parameterName;
        }

        public override int CompareTo(ProceduralAlgorithmParameter other)
        {
            if (other == null)
                return 1;

            if (this.Equals(other))
                return 0;

            // very generic way to compare parameters but T will vary in the collection so any kind of "sort" is not valid
            return this.GetHashCode().CompareTo(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return obj is ProceduralAlgorithmParameter<T> parameter &&
                   Required == parameter.Required &&
                   ParameterName == parameter.ParameterName &&
                   EqualityComparer<T>.Default.Equals(DefaultValue, parameter.DefaultValue);
        }

        public override int GetHashCode()
        {
            int hashCode = 1226378207;
            hashCode = hashCode * -1521134295 + Required.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(DefaultValue);
            return hashCode;
        }
    }

    public class ProceduralAlgorithmParameterCollection : ICollection<ProceduralAlgorithmParameter>
    {
        List<ProceduralAlgorithmParameter> _objects;

        public ProceduralAlgorithmParameterCollection(int parameters)
        {
            _objects = new List<ProceduralAlgorithmParameter>(parameters);
        }

        public int Count => ((ICollection<ProceduralAlgorithmParameter>)_objects).Count;

        public int RequiredCount => _objects.Where(i => i.Required).Count();

        public bool IsReadOnly => ((ICollection<ProceduralAlgorithmParameter>)_objects).IsReadOnly;

        public void Clear()
        {
            ((ICollection<ProceduralAlgorithmParameter>)_objects).Clear();
        }

        public void CopyTo(ProceduralAlgorithmParameter[] array, int arrayIndex)
        {
            ((ICollection<ProceduralAlgorithmParameter>)_objects).CopyTo(array, arrayIndex);
        }

        public IEnumerator GetEnumerator()
        {
            return _objects.GetEnumerator();
        }

        public void Add(ProceduralAlgorithmParameter item)
        {
            item.ParameterIndex = _objects.Count;
            ((ICollection<ProceduralAlgorithmParameter>)_objects).Add(item);
        }

        public void Add<T>()
        {
            this.Add(new ProceduralAlgorithmParameter<T>() { ParameterIndex = _objects.Count });
        }

        public void Add<T>(bool required, T defaultValue)
        {
            this.Add(new ProceduralAlgorithmParameter<T>(required, defaultValue) { ParameterIndex = _objects.Count });
        }

        public bool Contains(ProceduralAlgorithmParameter item)
        {
            return ((ICollection<ProceduralAlgorithmParameter>)_objects).Contains(item);
        }

        public T GetParameterValue<T>(object[] args, int index)
        {
            if(args.Length < index || Count < index || index < 0)
                throw new ArgumentOutOfRangeException("index");

            ProceduralAlgorithmParameter matchedParam = _objects[index];
            if (matchedParam.ParameterType != typeof(T))
                throw new ArgumentException("Invalid parameter type", "index");

            return (T)args[index];
        }

        public T GetParameterValue<T>(object[] args, string name)
        {
            if(!_objects.Any(o=> o.ParameterName == name))
                throw new ArgumentException("Unable to find argument", "name");

            return GetParameterValue<T>(args, _objects.Where(o=> o.ParameterName == name).FirstOrDefault().ParameterIndex);
        }

        IEnumerator<ProceduralAlgorithmParameter> IEnumerable<ProceduralAlgorithmParameter>.GetEnumerator()
        {
            return ((IEnumerable<ProceduralAlgorithmParameter>)_objects).GetEnumerator();
        }

        public bool Remove(ProceduralAlgorithmParameter item)
        {
            return ((ICollection<ProceduralAlgorithmParameter>)_objects).Remove(item);
        }

        public bool ParametersMatch(params object[] parameters)
        {
            if (parameters.Length < RequiredCount)
                return false;

            for(int i = 0; i< Count; i++)
            {
                // if we have more expected parameters than provided, fail
                // not full support of required/unrequired parameters but a start
                if(parameters.Length < i) 
                    return false;

                if(parameters[i] == null)
                    return false;

                Type thisParmType = parameters[i].GetType();
                if(thisParmType != _objects[i].ParameterType)
                    return false;
            }

            // all parameters exist and match
            return true;
        }

    }
}
