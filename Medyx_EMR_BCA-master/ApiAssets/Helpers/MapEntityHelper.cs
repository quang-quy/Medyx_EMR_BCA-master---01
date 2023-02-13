using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using AutoMapper;
using System.Data;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
	public static class MapEntityHelper
	{
		public static T MapEntity<T, Tb>(T entity, Tb obj, bool withEmpty = false)
		{
			Mapper.CreateMap<Tb, T>().ForAllMembers(opt => opt.Condition(
						srs =>
						{
							try
							{
								if (srs.IsSourceValueNull)
								{
									return withEmpty;
								}
								if ((srs.SourceType.FullName == "System.Boolean" || srs.SourceType.FullName == "System.Byte") && withEmpty)
								{
									return true;
								}
								if (srs.SourceType.IsValueType && srs.SourceValue.Equals(Activator.CreateInstance(srs.SourceType)))
								{
									return false;
								}
								return true;
							}
							catch (Exception)
							{
								return false;
							}
						}));
			return Mapper.Map(obj, entity);
		}
	}
}
