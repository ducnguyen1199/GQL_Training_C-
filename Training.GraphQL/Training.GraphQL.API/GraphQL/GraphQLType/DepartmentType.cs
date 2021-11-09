using GraphQL.Types;
using Training.Data.Models;
using Training.Data.Repository;

namespace Training.GraphQL.API.GraphQL.GraphQLType
{
	public class DepartmentType : ObjectGraphType<Department>
	{
		public DepartmentType(IUserRepository userRepository)
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of Department.");
			Field(x => x.Name).Description("Name of Department.");
			Field<ListGraphType<UserType>>(
				"users",
				Description = "Users in Department",
				resolve: context => userRepository.GetByDepartmentId(context.Source.Id)
			);
		}
	}
}
