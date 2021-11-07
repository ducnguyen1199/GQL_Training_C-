using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.GraphQL.API.GraphQL.GraphQLInput
{
	public class UserInputType : InputObjectGraphType
	{
		public UserInputType()
		{
			Name = "user";
			Field<StringGraphType>("name");
			Field<NonNullGraphType<LongGraphType>>("departmentId");
		}
	}
}
