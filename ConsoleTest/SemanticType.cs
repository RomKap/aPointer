using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public class SemanticType<T, S> : IHasValue<T>, IEquatable<S> where S : IHasValue<T>
    {
        public T ObjValue { get; private set; }

        #region with FUNC
        //private static Func<T, bool> _isValid = v => true ;

        //public static Func<T, bool> IsValid
        //{
        //    get { return _isValid; }
        //    protected set { _isValid = value; }
        //}
        #endregion

        #region with delegate
        public delegate bool isValidD(T dVal);
        private static isValidD _isValid = v => true;

        public static isValidD IsValid
        {
            get { return _isValid; }
            protected set { _isValid = value; }
        }
        #endregion

        protected SemanticType(T value)
        {
            //bool ret = IsValid(value);

            if(!IsValid(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", typeof(T), value));
            }

            ObjValue = value;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if ((obj == null) || (!(obj is S)))
            {
                return false;
            }

            return (ObjValue.Equals(((S)obj).ObjValue));
        }

        #region IEquatable<S> Members

        public bool Equals(S other)
        {
            if (other == null) { return false; }

            return (ObjValue.Equals(other.ObjValue));
        }

        #endregion

        public static bool operator ==(SemanticType<T, S> a, SemanticType<T, S> b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            // Have to cast to object, otherwise you recursively call this == operator.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(SemanticType<T, S> a, SemanticType<T, S> b)
        {
            return !(a == b);
        }
    }

    public interface IHasValue<T>
    {
        T ObjValue { get; }
    }


    public class EmailAddress : SemanticType<string, EmailAddress>
    {

        static EmailAddress()
        {
            IsValid = s => Regex.IsMatch(s,
                            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                            RegexOptions.IgnoreCase);
        }    

        public EmailAddress(string emailAddress)  : base(emailAddress)
        {
        }          
    }

    public class BirhtDate : SemanticType<DateTime, BirhtDate>
    {
        const int maxAgeForHumans = 130;
        const int daysPerYear = 365;

        static BirhtDate()
        {
            IsValid = birthDate =>
                {
                    TimeSpan age = DateTime.Now - birthDate;
                    return (age.TotalDays >= 0) && (age.TotalDays < daysPerYear * maxAgeForHumans);
                };

        }

        public BirhtDate(DateTime birhtDate): base(birhtDate)
        {
        }
    }
}
