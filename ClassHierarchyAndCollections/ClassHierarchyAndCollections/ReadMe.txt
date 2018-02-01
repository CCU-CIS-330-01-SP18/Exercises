Scenario: We are creating an application to manage contacts - individuals and organizations that we know.
The first step is to design and develop our object model to represent the kinds of contacts we can store
and manage.

Instructions:
1.  Create your own branch from master in the Exercises GitHub repository with a name similar to dev/<initials>/week4.
2.  Create the following class hierarchy (or a better one!) for storing contacts. Each class should be defined in its own file.
3.  Define at least two unique properties for each class (ex: Contact.DisplayName, Organization.FormationDate, Association.AnnualDues).
4.  Define at least **one interface** that might be implemented by some classes. An example could be ILocatable, which would provide the
    GPS coordinates for a contact. That is, each class that "has a" location could implemente the ILocatable interface.
5.  Define at least one collection property for one class that should contain instances of another class. For example, the School class
    could have a colleciton of Students (ex: public List<Student> Students { get; }). Or, the Business class could have a list of
    Clients.
6.  Create a test project that contains least one automated test for each class, confirming that you can create an instance of the class, that the 
    instance derives from each super class, and that each property can be written and read. Each class should have its own automated 
    test class, and you should break up the above test cases into discrete tests.
7.  ***Ensure you follow all coding standards. **XML**
8.  Commit your changes and publish your branch to GitHub.
9.  Create a Pull Request to indicate that the changes are ready for grading.
10. Provide your branch name as your Blackboard submission for this exercise.

Sample Class Hierarchy (aka Object Model):
------------------------------------------
$Contact$
 |
 -- $Organization$
 |   |
 |   -- Association
 |   |
 |   -- School
 |   |
 |   -- Business
 |
 -- $Individual$
     |
     -- $Student$
     |
     -- $Member$
     |
     -- $Client$