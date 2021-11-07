using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.Models;
using Training.Data.Repository;

namespace Training.GraphQL.API.GraphQL.GraphQLType
{
	public class DepartmentType : ObjectGraphType<Department>
	{
		public DepartmentType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of Deparment.");
			Field(x => x.Name).Description("Name of Deparment.");
		}
	}
}
