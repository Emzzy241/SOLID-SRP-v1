// Implementing the S in SOLID
// S stands for SRP; Solid Responsibility Principle

// The rule states that a class should only be changed for one reason
// This means that every class or similar structure in your code should only have one job

// Our class should not be like a Swiss knife wherein if one of them needs to be changed, the entire tool needs to be altered. It does not mean that your classes should only contain one method or property. There may be many members as long as they relate to a single responsibility.

// The Single Responsibility Principle gives us a good way of identifying classes at the design phase of an application, and it makes you think of all the ways a class can change. 
// However, a good separation of responsibilities is done only when we have the full picture of how the application should work. Let us check this with an example.