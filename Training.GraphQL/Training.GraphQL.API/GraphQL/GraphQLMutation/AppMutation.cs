using GraphQL;
using GraphQL.Types;
using System;
using System.Linq;
using Training.Data.Models;
using Training.Data.Repository;
using Training.GraphQL.API.GraphQL.GraphQLInput;
using Training.GraphQL.API.GraphQL.GraphQLType;

namespace Training.GraphQL.API.GraphQL.GraphQLMutation
{
	public class AppMutation : ObjectGraphType
	{
		public AppMutation(IUserRepository userRepository, IDepartmentRepository departmentRepository)
		{
            Field<UserType>(
            "createUser",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }),
            resolve: context =>
            {
                var input = context.GetArgument<User>("input");

                User user = new User
                {
                    Name = input.Name,
                    DepartmentId = input.DepartmentId,
                };

                return userRepository.CreateUser(user);
            });

            Field<UserType>(
            "updateUser",
            arguments: new QueryArguments
            (
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "input" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<long>("id");
                var input = context.GetArgument<User>("input");

                User user = userRepository.GetById(id);
                user.Name = input.Name;
                user.DepartmentId = input.DepartmentId;

                return userRepository.UpdateUser(user);
            });

            Field<StringGraphType>(
            "deleteUser",
            arguments: new QueryArguments
            (
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "id" }
            ),
            resolve: context =>
            { 
                var id = context.GetArgument<long>("id");

                User user = userRepository.GetById(id);

                if (user == null)
                {
                    context.Errors.Add(new ExecutionError($"Not found User by Id = {id}"));
                    return null;
                }

                return userRepository.DeleteUser(user);
            });

            Field<DepartmentType>(
            "createDepartment",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
            resolve: context =>
            {
                var name = context.GetArgument<string>("name");

                Department department = new Department
                {
                    Name = name,
                };

                return departmentRepository.CreateDepartment(department);
            });

            Field<DepartmentType>(
            "updateDepartment",
            arguments: new QueryArguments
            (
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<long>("id");
                var name = context.GetArgument<string>("name");

                Department department = departmentRepository.GetById(id);
                department.Name = name;

                return departmentRepository.UpdateDepartment(department);
            });

            Field<StringGraphType>(
            "deleteDepartment",
            arguments: new QueryArguments
            (
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<long>("id");

                Department department = departmentRepository.GetById(id);

                if (department == null)
                {
                    context.Errors.Add(new ExecutionError($"Not found Department by Id = {id}"));
                    return null;
                }

                return departmentRepository.DeleteDepartment(department);
            });
        }
	}
}
