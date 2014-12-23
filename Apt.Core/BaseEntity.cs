using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apt.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        //public int ID { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        //public override int GetHashCode()
        //{
        //    if (Equals(ID, default(int)))
        //        return base.GetHashCode();
        //    return ID.GetHashCode();
        //}

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }

        //public string GetPrimaryKeyColumnName()
        //{
        //}
    }
}
