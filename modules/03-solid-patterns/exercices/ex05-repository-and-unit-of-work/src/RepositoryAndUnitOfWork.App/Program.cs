using RepositoryAndUnitOfWork.App.Data.Contracts;
using RepositoryAndUnitOfWork.App.Data.InMemory;
using RepositoryAndUnitOfWork.App.Domain;
using RepositoryAndUnitOfWork.App.Services;
using System;

namespace RepositoryAndUnitOfWork.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var issueService = new IssueService();

            var personnes = new List<User>
            {
                new User("Sajed", "mon.email@yahoo.com"),
                new User("Bob", "email.bob@yahoo.com")
            };

            issueService.UserRepository.Add(personnes[0]);
            issueService.UserRepository.Add(personnes[1]);

            issueService.UnitOfWork.SaveChanges();

            var project = new Project("Project 1");

            issueService.ProjectRepository.Add(project);

            issueService.UnitOfWork.SaveChanges();

            Console.WriteLine("Users : ");
            foreach(var item in issueService.UserRepository.ListAll())
            {
                Console.WriteLine($"User name : {item.DisplayName} - User Id : {item.Id} - User email : {item.Email}");
            }

            Console.WriteLine();

            Console.WriteLine("Projects :");
            foreach (var item in issueService.ProjectRepository.ListAll())
            {
                Console.WriteLine($"Project name : {item.Name} - Project Id : {item.Id}");

            }

            var issueId = issueService.CreateIssue(project.Id, "Issue 1", "Problème x with Project 1", personnes[0].Id);

            issueService.AssignIssue(issueId, personnes[0].Id);

            issueService.AdvanceStatus(issueId);
            issueService.AdvanceStatus(issueId);

            issueService.AddComment(issueId, personnes[0].Id, "Fix pushed");

            issueService.Reopen(issueId);

            issueService.AdvanceStatus(issueId);
            issueService.AdvanceStatus(issueId);

            var details = issueService.GetDetails(issueId);

            Console.WriteLine();
            Console.WriteLine("Issues :");
            foreach (var item in issueService.IssueRepository.ListByProject(issueId))
            {
                Console.WriteLine($"Issue Id : {item.Id} - Issue Title {item.Title} - Issue Project Id : {item.ProjectId} - Issue User Id : {item.AssigneeUserId} - Issue Description : {item.Description} - Issue Created at : {item.CreatedAt} - Issue Status : {item.IssueStatus}");
            }
            
            //issueService.IssueRepository.ListByStatus(IssueStatus.Closed);

            //issueService.IssueRepository.ListAssignedTo(personnes[0].Id);

            Console.WriteLine();
            Console.WriteLine("Comments :");

            foreach (var item in issueService.CommentRepository.ListByIssue(issueId))
            {
                Console.WriteLine($"Comment Id : {item.Id} - Comment Issue Id : {item.IssueId} - Comment User Id : {item.AuthorUserId} - Comment Body : {item.Body} - Comment Created at : {item.CreatedAt}");
            }


        }
    }
}