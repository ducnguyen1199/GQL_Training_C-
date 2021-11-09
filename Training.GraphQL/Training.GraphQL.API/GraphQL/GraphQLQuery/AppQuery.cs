using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.Models;
using Training.Data.Repository;
using Training.GraphQL.API.GraphQL.GraphQLType;
namespace Training.GraphQL.API.GraphQL.GraphQLQuery
{
	public class AppQuery: ObjectGraphType
    {
        public AppQuery(IUserRepository userRepository,IDepartmentRepository departmentRepository)
        {
            Field<ListGraphType<UserType>>(
               "users",
               resolve: context => userRepository.GetAll()
            );
            Field<UserType>(
              "user",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "Id" }),
              resolve: context =>
              {
                  long id = context.GetArgument<long>("Id");
                  User user = userRepository.GetById(id);

                  if(user == null)
				  {
                      context.Errors.Add(new ExecutionError($"Not found User by Id = {id}"));
                  }

                  return user;
              }
            );

            Field<ListGraphType<DepartmentType>>(
               "departments",
               resolve: context => departmentRepository.GetAll()
            );
            Field<DepartmentType>(
              "department",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "Id"}),
              resolve: context => 
              {
                  long id = context.GetArgument<long>("Id");
                  return departmentRepository.GetById(id);
              }
           );
        }
    }
}
