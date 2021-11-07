using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.Models;
using Training.Data.Repository;

namespace Training.GraphQL.API.GraphQL.GraphQLType
{
	public class UserType : ObjectGraphType<User>
	{
		public UserType(IDepartmentRepository departmentRepository)
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of User");
			Field(x => x.Name).Description("Name of User");
			Field(x => x.DepartmentId).Description("Id of Department");
			Field<DepartmentType>(
				"departments",
				Description = "Department Obj",
				resolve: context => departmentRepository.GetById(context.Source.DepartmentId)
			);
		}
	}
}
