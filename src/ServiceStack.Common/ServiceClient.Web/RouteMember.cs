using System.Reflection;
using ServiceStack.Text;

namespace ServiceStack.ServiceClient.Web
{
	internal abstract class RouteMember
	{
#if !NETCF
		public abstract object GetValue(object target, bool excludeDefault = false);
#else
		public abstract object GetValue(object target);
		public abstract object GetValue(object target, bool excludeDefault);
#endif
	}

	internal class FieldRouteMember : RouteMember
	{
		private readonly FieldInfo field;

		public FieldRouteMember(FieldInfo field)
		{
			this.field = field;
		}

		public override object GetValue(object target, bool excludeDefault)
		{
			var v = field.GetValue(target);
			if (excludeDefault && Equals(v, field.FieldType.GetDefaultValue())) return null;
			return v;
		}

#if NETCF
        public override object GetValue(object target)
        {
            return GetValue(target, false);
        }
#endif
	}

	internal class PropertyRouteMember : RouteMember
	{
		private readonly PropertyInfo property;

		public PropertyRouteMember(PropertyInfo property)
		{
			this.property = property;
		}

		public override object GetValue(object target, bool excludeDefault)
		{
			var v = property.GetValue(target, null);
			if (excludeDefault && Equals(v, property.PropertyType.GetDefaultValue())) return null;
			return v;
		}
#if NETCF
        public override object GetValue(object target)
        {
            return GetValue(target, false);
        }
#endif

	}
}