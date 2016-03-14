# Answer

## TL; DR

FakeSqlConnection, FakeSqlCommand, FakeSqlReader should be one “module” that is separate from Yucky. The best part is in commit
d14cdf8debd6081cb86ce67b27865a3dd0221075

## Questions

1.	I actually didn’t finish all the code smell I pointed out in the beginning. And here is some problem I need to ask folks in the group.
2.	How can I test the query? "select * from employee, employee_role inner join employee.Id == employee_role.EmployeeId"; If I really want it other than end to end testing, I have to write a how SQL parser to simulate it?
3.	Do you think the signature GetEmployees(EmployeeFilterType employeeFilterType, string filter) is still weird? Should I just have 2 method GetEmployeeByName and GetExemptOnlyEmployee?
4.	The simulator is too much code. Is it actually helping? It is actually a duplication of logic, have all the problems of duplication – we need to keep them in sync and need to maintain them.
5.	And please point out anything that looks odd to you.

## Main

There is my answer. As last time. I send a pull request.
Apology at the beginning, I completely ignored Eric’s code style and applied the default style of ReSharper on my machine. And this refactor is focuses on how to deal with external dependency. There are several API design I feel odd as well, but I ran out of my afternoon already.
Just look at the whole diff shouldn’t make sense. Please read commit by commit.

### In the beginning

I didn’t feel so wrong about Yucky in the beginning. It looks like a repository for me (my understanding, adapter’s name when it adapts to database)
1.	Shouldn’t pass in database connection when query
2.	No test at all (the void code smell)
3.	Wow raw SQL, but that should be a part of the game
4.	Enum, I think in ideal code, there shouldn’t be any Enum
And I also realize that the program has nearly no business, which need unit test most.
I add characterization test first, which is very useful when the code base has no test and you don’t want to bring down your existing website. I might should remove it after I have other tests.

### The real problem

I did some minor clean up. And I want to add test coverage for the Yucky.cs that I already rename it to Repository. This step helps me point out the true problem. According to the Suck at TDD posts right way is to apply P/A/S pattern is to make it testable. Right now Repository is using external service FakeSql. And I should put interface on it in order to decouple them. 
However, I cannot. I soon realize that FakeSqlConnection, FakeSqlCommand, FakeSqlReader need exactly each other. They don’t want interfaces. I also tried to wrap the all three interface with plain delegate, but it is tedious and useless. In the end, I find out that, since these 3 is so coupled, they should belong to one. So I created FakeSqlDriver.
I should put all the logic involving FakeSql* into SqlDriver class. And put an interface for the driver so that I can separate FakeSql from everything else. And it works well.
There is a detail problem in the refactoring. In the beginning, I try to return a IDisposable to for the Repository to close the connection. However, it is just awkward to return a FakeCommand referenced by IDisposable. And more important, I cannot enforce the order of connect -> run query -> read -> dispose. The programmer writing the repository has to remember the exact sequence -- The answer is move these logics in driver. Actually SQL connection need to dispose is a very low level API detail leaked to the FakeSQL API consumer. It makes sense to put it in driver. By using Lambda, Repository is in charge of how to write query and how to read query result.
The rest is a practice of how to write test for read only Simulator. 

# DesignForTestability

This is an example project with code that exhibits common issues that make it hard to write tests. 


The exercise is to take the current implementation of the Yucky class, refactor it into testable code, and add those tests.

My recommended approach is to look at the code, write down the issues that you have found, and take a try at refactoring. Then, go
and read the "You suck at TDD series", come back, and see if you have any new thoughts. 



<a href="https://social.msdn.microsoft.com/Search/en-US?query=You%20Suck%20At%20TDD&beta=0&rn=Eric+Gunnerson%26%2339%3bs+Compendium&rq=site:blogs.msdn.com/b/ericgu/&ac=5">You Suck at TDD</a>
