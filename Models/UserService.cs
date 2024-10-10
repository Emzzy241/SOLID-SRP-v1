// Implementing the L in SOLID
// The Liskov Substitution Principle (LSP) states, "you should be able to use any derived class instead of a parent class and have it behave in the same manner without modification.". 
// It ensures that a derived class does not affect the behavior of the parent class; in other words, a derived class must be substitutable for its base class.

// This principle is just an extension of the Open Closed Principle, and we must ensure that newly derived classes extend the base classes without changing their behavior. 

// I will explain this with a real-world example that violates LSP.
// A father is a doctor, whereas his son wants to become a cricketer. So here, the son can't replace his father even though they belong to the same family hierarchy.

// Now jump into an example to learn how a design can violate LSP. Suppose we need to build an app to manage data using a group of SQL files text. 
// Here we need to write functionality to load and save the text of a group of SQL files in the application directory. 
// So we need a class that manages the load and keeps the text of a group of SQL files along with the SqlFile Class. 