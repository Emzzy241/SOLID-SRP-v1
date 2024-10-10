
// THe D in SOLID 
// DIP
// Dependency Inversion Principle

// The Dependency Inversion Principle (DIP) states that high-level modules/classes should not depend on low-level modules/classes. First, both should depend upon abstractions. Secondly, abstractions should not rely upon details. Finally, details should depend upon abstractions.

// High-level modules/classes implement business rules or logic in a system (application). Low-level modules/classes deal with more detailed operations; in other words, they may write information to databases or pass messages to the operating system or services.

// A high-level module/class that depends on low-level modules/classes or some other class and knows a lot about the other classes it interacts with is said to be tightly coupled. When a class knows explicitly about the design and implementation of another class, it raises the risk that changes to one class will break the other. So we must keep these high-level and low-level modules/classes loosely coupled as much as possible. To do that, we need to make both of them dependent on abstractions instead of knowing each other. Let's start with an example.

// Suppose we need to work on an error-logging module(class) that logs exception stack traces into a file. Simple, isn't it? The following classes provide the functionality to log a stack trace into a file. 


// Client file exports data from many files to a database

// Looks good. We sent our application to the client. But our client wants to store this stack trace in a database if an IO exception occurs. Hmm... OK, no problem. We can implement that too. Here we need to add one more class that provides the functionality to log the stack trace into the database and an extra method in ExceptionLogger to interact with our new class to log the stack trace.


// Looks fine for now. But whenever the client wants to introduce a new logger, we must alter ExceptionLogger by adding a new method. Suppose we continue doing this after some time. In that case, we will see a fat ExceptionLogger class with a large set of practices that provide the functionality to log a message into various targets. Why does this issue occur? Because ExceptionLogger directly contacts the low-level classes FileLogger and DbLogger to log the exception. We need to alter the design so that this ExceptionLogger class can be loosely coupled with those classes. To do that, we need to introduce an abstraction between them so that ExcetpionLogger can contact the abstraction to log the exception instead of directly depending on the low-level classes.

// Now our low-level classes need to implement this interface.


// Now, we move to the low-level class's initiation from the ExceptionLogger class to the DataExporter class to make ExceptionLogger loosely coupled with the low-level classes FileLogger and EventLogger. And by doing that, we are giving provision to DataExporter class to decide what kind of Logger should be called based on the exception that occurs.

// We successfully removed the dependency on low-level classes. This ExceptionLogger doesn't depend on the FileLogger and EventLogger classes to log the stack trace. We no longer need to change the ExceptionLogger's code for the new logging functionality. We must create a new logging class that implements the ILogger interface and adds another catch block to the DataExporter class's ExportDataFromFile method.



// And we need to add a condition in the DataExporter class as in the following:

// Looks good. But we introduced the dependency here in the DataExporter class's catch blocks. So, someone must be responsible for providing the necessary objects to the ExceptionLogger to get the work done.

// Let me explain it with a real-world example. Suppose we want to have a wooden chair with specific measurements and the kind of wood to be used to make that chair. Then we can't leave the decision-making on measures and the wood to the carpenter. Here his job is to make a chair based on our requirements with his tools, and we provide the specifications to him to make a good chair.

// So what is the benefit we get from the design? Yes, we definitely have benefited from it. We need to modify the DataExporter and ExceptionLogger classes whenever we need to introduce a new logging functionality. But in the updated design, we need to add only another catch block for the new exception logging feature. We only need to properly understand the system, requirements, and environment and find areas where DIP should be followed. 
// Coupling is not inherently evil. If you don't have some amount of coupling, your software will not do anything for you.

// Conclusion
// Great, we have gone through all five SOLID principles successfully. And we can conclude that using these principles, we can build an application with tidy, readable, and easily maintainable code.

// Here you may have some doubts. Yes, about the quantity of code. Because of these principles, the code might become larger in our applications. But my dear friends, you need to compare it with the quality we get by following these principles. Hmm, but anyway, 27 lines are much fewer than 200 lines. 

// Conclusion
// Great, we have gone through all five SOLID principles successfully. And we can conclude that using these principles, we can build an application with tidy, readable, and easily maintainable code.

// Here you may have some doubts. Yes, about the quantity of code. Because of these principles, the code might become larger in our applications. But my dear friends, you need to compare it with the quality we get by following these principles. Hmm, but anyway, 27 lines are much fewer than 200 lines. 

// Orale